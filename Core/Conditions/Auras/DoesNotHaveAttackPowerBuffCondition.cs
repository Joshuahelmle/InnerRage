using Styx;

namespace InnerRage.Core.Conditions
{
    class DoesNotHaveAttackPowerBuffCondition : ICondition
    {
        public bool Satisfied()
        {
           return !StyxWoW.Me.HasAttackPowerBuff();
        }
    }
}
