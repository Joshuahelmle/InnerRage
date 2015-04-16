using Styx;

namespace InnerRage.Core.Conditions
{
    internal class DoesNotHaveAttackPowerBuffCondition : ICondition
    {
        public bool Satisfied()
        {
            return !StyxWoW.Me.HasAttackPowerBuff();
        }
    }
}