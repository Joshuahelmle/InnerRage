using Styx;

namespace InnerRage.Core.Conditions
{
    internal class InMeeleRangeCondition : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.HasAttackableTarget() && StyxWoW.Me.CurrentTarget.IsWithinMeleeRange;
        }
    }
}