using Styx;

namespace InnerRage.Core.Conditions
{
    internal class OnlyOnBossCondition : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.CurrentTarget.IsBoss;
        }
    }
}