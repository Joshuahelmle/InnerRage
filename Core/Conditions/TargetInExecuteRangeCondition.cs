using Styx.WoWInternals.WoWObjects;

namespace InnerRage.Core.Conditions
{
    class TargetInExecuteRangeCondition : ICondition
    {
        private WoWUnit _target;

        public TargetInExecuteRangeCondition(WoWUnit target)
        {
            _target = target;
        }

        public bool Satisfied()
        {
            return new TargetIsInHealthRangeCondition(_target, 0, 20).Satisfied();
        }
    }
}
