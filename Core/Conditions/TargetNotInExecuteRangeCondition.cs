using Styx.WoWInternals.WoWObjects;

namespace InnerRage.Core.Conditions
{
    internal class TargetNotInExecuteRangeCondition : ICondition
    {
        private readonly WoWUnit _target;

        public TargetNotInExecuteRangeCondition(WoWUnit target)
        {
            _target = target;
        }

        public bool Satisfied()
        {
            return _target != null && new TargetIsInHealthRangeCondition(_target, 20).Satisfied();
        }
    }
}