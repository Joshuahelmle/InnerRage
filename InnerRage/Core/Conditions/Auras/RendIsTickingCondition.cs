using InnerRage.Core.Managers;

namespace InnerRage.Core.Conditions
{
    class RendIsTickingCondition :ICondition
    {
        public bool Satisfied()
        {
            return UnitManager.Instance.LastKnownBleedingEnemies != null && UnitManager.Instance.LastKnownBleedingEnemies.Count > 0;
        }
    }
}
