using Styx.WoWInternals.WoWObjects;

namespace InnerRage.Core.Conditions
{
    internal class TargetInExecuteRangeCondition : ICondition
    {
        private readonly WoWUnit _target;

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