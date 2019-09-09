using System.Linq;
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
        private readonly int _percentageOfTrees;
        private readonly int _damageMultiplier;
        private readonly int _caAdditionalDamage;
        private int _dayOfTick;

        private long CurrentTick { get; set; }

        public HerbivorePressureLayer(SavannaLayer savannaLayer, int percentageOfTrees, int damageMultiplier, 
            int caAdditionalDamage = -1)
        {
            _savannaLayer = savannaLayer;
            _percentageOfTrees = percentageOfTrees;
            _damageMultiplier = damageMultiplier;
            _caAdditionalDamage = caAdditionalDamage;
        }

        public void Tick()
        {
            if (_dayOfTick.Equals(SimulationClock.CurrentTimePoint.Value.Day)) return;
            _dayOfTick = SimulationClock.CurrentTimePoint.Value.Day;
 
            if (!IsNextYearTick()) 
                return;
            
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
                tree.SufferHerbivorePressure(_percentageOfTrees, _damageMultiplier);
            }
            
            //specific for skukuza, target CA's only
            if (_caAdditionalDamage != -1)
            {
                foreach (var ca in _savannaLayer._TreeAgents.Values.Where(t => t.Species == "ca"))
                {
                    ca.SufferHerbivorePressure(_caAdditionalDamage, _damageMultiplier);
                }
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