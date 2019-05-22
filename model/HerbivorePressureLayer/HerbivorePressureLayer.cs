using Mars.Core.SimulationManager.Entities;
using Mars.Interfaces.Layer;
using Mars.Interfaces.Layer.Initialization;
using SavannaTrees;

namespace Bushbuckridge.Agents.Collector
{
    /// <summary>
    /// Reduces the tree wood mass once a year by herbivore influence
    /// </summary>
    public class HerbivorePressureLayer : ISteppedActiveLayer
    {
        private readonly SavannaLayer _savannaLayer;
        private int _dayOfTick;

        private long CurrentTick { get; set; }

        public HerbivorePressureLayer(SavannaLayer savannaLayer)
        {
            _savannaLayer = savannaLayer;
        }

        public void Tick()
        {
            if (_dayOfTick != null && _dayOfTick.Equals(SimulationClock.CurrentTimePoint.Value.Day)) return;
            _dayOfTick = SimulationClock.CurrentTimePoint.Value.Day;
 
            if (!IsNextYearTick()) return;
            fireHerbivorePressureEvent();
        }

        private static bool IsNextYearTick()
        {
            return SimulationClock.CurrentTimePoint.Value.Day == SimulationClock.StartTimePoint.Value.Day &&
                   SimulationClock.CurrentTimePoint.Value.Month == SimulationClock.StartTimePoint.Value.Month &&
                   SimulationClock.CurrentTimePoint.Value.Year > SimulationClock.StartTimePoint.Value.Year;
        }

        private void fireHerbivorePressureEvent()
        {
            foreach (var tree in _savannaLayer._TreeAgents.Values)
            {
                tree.SufferHerbivorePressure();
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