using System;
using System.Diagnostics;
using Bushbuckridge.Config;
using Mars.Core.SimulationManager.Entities;
using Mars.Interfaces.Layer;
using Mars.Interfaces.Layer.Initialization;
using SavannaTrees;

namespace Bushbuckridge.Agents.Collector
{
    /// <summary>
    /// If between September and August of the next year, the precipitation is lower than a threshold (in millimeters), then a drought event is generated. 
    /// </summary>
    public class DroughtLayer : ISteppedActiveLayer
    {
        private int _dayOfTick;
        private readonly SavannaLayer _savannaLayer;
        private readonly Precipitation _precipitation;
        private double precipitationWithinYear;
        private double daysSinceLastDroughtTest;

        public bool HasDrought { get; private set; }

        private long CurrentTick { get; set; }

        public DroughtLayer(SavannaLayer savannaLayer, Precipitation precipitation)
        {
            _savannaLayer = savannaLayer;
            _precipitation = precipitation;
            Console.WriteLine(HasDrought);
        }

        public bool InitLayer(TInitData layerInitData, RegisterAgent registerAgentHandle,
            UnregisterAgent unregisterAgentHandle)
        {
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

        public void Tick()
        {
            if (_dayOfTick == null || !_dayOfTick.Equals(SimulationClock.CurrentTimePoint.Value.Day))
            {
                _dayOfTick = SimulationClock.CurrentTimePoint.Value.Day;
                precipitationWithinYear += _precipitation.GetNumberValue(Territory.TOP_LAT, Territory.LEFT_LONG);
                daysSinceLastDroughtTest++;

                if (IsNextYearTick())
                {
                    Console.WriteLine(SimulationClock.CurrentTimePoint.Value.Year);
                    HasDrought = IsDroughtSituationReached();
                    if (HasDrought)
                    {
                        Console.WriteLine("DROUGHT!!!");
                        // fire drought event
                        foreach (var tree in _savannaLayer._TreeAgents.Values)
                        {
                            tree.SufferDrought();
                        }
                    }

                    precipitationWithinYear = 0;
                    daysSinceLastDroughtTest = 0;
                }
            }
        }

        private bool IsNextYearTick()
        {
            return SimulationClock.CurrentTimePoint.Value.Month == 9 &&
                   SimulationClock.CurrentTimePoint.Value.Day == 1 &&
                   daysSinceLastDroughtTest >= 365;
        }

        private bool IsDroughtSituationReached()
        {
            return precipitationWithinYear < 435;
        }

        public void PreTick()
        {
        }

        public void PostTick()
        {
        }
    }
}