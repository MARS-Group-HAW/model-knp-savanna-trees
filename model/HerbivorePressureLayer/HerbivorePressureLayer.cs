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
        private readonly int _juvenilesAdditionalDamage;
        private readonly int _ttJuvenileAdditionalDamage;
        private readonly int _caJuvenileAdditionalDamage;

        private long CurrentTick { get; set; }

        public HerbivorePressureLayer(SavannaLayer savannaLayer, int percentageOfTrees, int damageMultiplier, 
            int caAdditionalDamage = -1, int juvenilesAdditionalDamage = -1, int ttJuvenileAdditionalDamage = -1,
            int caJuvenileAdditionalDamage = -1)
        {
            _savannaLayer = savannaLayer;
            _percentageOfTrees = percentageOfTrees;
            _damageMultiplier = damageMultiplier;
            _caAdditionalDamage = caAdditionalDamage;
            _juvenilesAdditionalDamage = juvenilesAdditionalDamage;
            _ttJuvenileAdditionalDamage = ttJuvenileAdditionalDamage;
            _caJuvenileAdditionalDamage = caJuvenileAdditionalDamage;
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
            
            //specifically target juveniles of all tree types
            if (_juvenilesAdditionalDamage != -1)
            {
                foreach (var tree in _savannaLayer._TreeAgents.Values.Where(t => t.MyTreeAgeGroup == TreeAgeGroup.Juvenile))
                {
                    tree.SufferHerbivorePressure(_juvenilesAdditionalDamage, _damageMultiplier);
                }
            }
            
            //specific for skukuza, target CA's only
            if (_caAdditionalDamage != -1)
            {
                foreach (var ca in _savannaLayer._TreeAgents.Values.Where(t => t.Species == "ca"))
                {
                    ca.SufferHerbivorePressure(_caAdditionalDamage, _damageMultiplier);
                }
            }

            if (_ttJuvenileAdditionalDamage != -1)
            {
                foreach (var tree in _savannaLayer._TreeAgents.Values.Where(
                    t => t.Species == "tt" && t.MyTreeAgeGroup == TreeAgeGroup.Juvenile))
                {
                    tree.SufferHerbivorePressure(_ttJuvenileAdditionalDamage, _damageMultiplier);
                }
            }
            
            if (_caJuvenileAdditionalDamage != -1)
            {
                foreach (var tree in _savannaLayer._TreeAgents.Values.Where(
                    t => t.Species == "ca" && t.MyTreeAgeGroup == TreeAgeGroup.Juvenile))
                {
                    tree.SufferHerbivorePressure(_caJuvenileAdditionalDamage, _damageMultiplier);
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