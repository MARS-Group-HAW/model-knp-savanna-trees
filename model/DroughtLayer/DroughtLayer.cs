using System;
using System.Diagnostics;
using System.Linq;
using Bushbuckridge.Config;
using Mars.Core.SimulationManager.Entities;
using Mars.Interfaces.Layer;
using Mars.Interfaces.Layer.Initialization;
using SavannaTrees;

namespace Bushbuckridge.Agents.Collector
{
    /// <summary>
    /// If after a year the precipitation of that year is lower than a precipitationThreshold (in millimeters), then a drought event is fired. 
    /// </summary>
    public class DroughtLayer : ISteppedActiveLayer
    {
        public int PrecipitationThreshold { get; }
        public bool HasDrought { get; private set; }

        private readonly SavannaLayer _savannaLayer;
        private readonly Precipitation _precipitation;

        private int _dayOfTick;
        private double _precipitationWithinYear;
        private readonly Stopwatch _stopWatch;

        private long CurrentTick { get; set; }

        public DroughtLayer(SavannaLayer savannaLayer, Precipitation precipitation, int precipitationThreshold)
        {
            _savannaLayer = savannaLayer;
            _precipitation = precipitation;
            PrecipitationThreshold = precipitationThreshold;
            _stopWatch = new Stopwatch();
            _stopWatch.Restart();
        }

        public void Tick()
        {
            if (_dayOfTick.Equals(SimulationClock.CurrentTimePoint.Value.Day)) return;
            _dayOfTick = SimulationClock.CurrentTimePoint.Value.Day;
            _precipitationWithinYear += _precipitation.GetNumberValue(Territory.TOP_LAT, Territory.LEFT_LONG);

            if (!IsNextYearTick()) return;

            Console.WriteLine(SimulationClock.CurrentTimePoint.Value.Year + " in " + _stopWatch.Elapsed.Minutes + "m " + _stopWatch.Elapsed.Seconds + "s with prec: "+_precipitationWithinYear);
            _stopWatch.Restart();

            HasDrought = _precipitationWithinYear < PrecipitationThreshold;
            if (HasDrought)
            {
                fireDroughtEvent();
            }

            _precipitationWithinYear = 0;
        }

        private static bool IsNextYearTick()
        {
            return SimulationClock.CurrentTimePoint.Value.Day == SimulationClock.StartTimePoint.Value.Day &&
                   SimulationClock.CurrentTimePoint.Value.Month == SimulationClock.StartTimePoint.Value.Month &&
                   SimulationClock.CurrentTimePoint.Value.Year > SimulationClock.StartTimePoint.Value.Year;
        }

        private void fireDroughtEvent()
        {
            Console.WriteLine("DROUGHT!!!");
            foreach (var tree in _savannaLayer._TreeAgents.Values)
            {
                tree.SufferDrought();
            }
        }

        public bool InitLayer(TInitData layerInitData, RegisterAgent registerAgentHandle,
            UnregisterAgent unregisterAgentHandle)
        {
            //do nothing
            return true;
        }

        public long GetCurrentTick()
        {
            return CurrentTick;
        }

        public void SetCurrentTick(long currentStep)
        {
            CurrentTick = currentStep;
        }

        public void PreTick()
        {
            //do nothing
        }

        public void PostTick()
        {
            //do nothing
        }
    }
}