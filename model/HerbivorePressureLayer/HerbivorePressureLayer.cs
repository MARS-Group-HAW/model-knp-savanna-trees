using Mars.Core.SimulationManager.Entities;
using Mars.Interfaces.Layer;
using Mars.Interfaces.Layer.Initialization;
using SavannaTrees;

namespace Bushbuckridge.Agents.Collector
{
    /// <summary>
    /// Reduces the tree wood mass once a year
    /// </summary>
    public class HerbivorePressureLayer : ISteppedActiveLayer
    {
        private readonly SavannaLayer _savannaLayer;

        private long CurrentTick { get; set; }

        public HerbivorePressureLayer(SavannaLayer savannaLayer)
        {
            _savannaLayer = savannaLayer;
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
            if (SimulationClock.CurrentTimePoint.Value.Month != 9 ||
                SimulationClock.CurrentTimePoint.Value.Day != 1) return;
            // fire herbivore pressure event
            foreach (var tree in _savannaLayer._TreeAgents.Values)
            {
                tree.SufferHerbivorePressure();
            }
        }

        public void PreTick()
        {
        }

        public void PostTick()
        {
        }
    }
}