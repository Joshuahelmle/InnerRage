using InnerRage.Core.Managers;

namespace InnerRage.Core.Conditions
{
    internal class RendIsTickingCondition : ICondition
    {
        public bool Satisfied()
        {
            return UnitManager.Instance.LastKnownBleedingEnemies != null &&
                   UnitManager.Instance.LastKnownBleedingEnemies.Count > 0;
        }
    }
}