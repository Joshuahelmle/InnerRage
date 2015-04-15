using Styx;

namespace InnerRage.Core.Conditions
{
    class DoesNotHaveStaminaBuffCondition : ICondition
    {
        public bool Satisfied()
        {
           return !StyxWoW.Me.HasStaminaBuff();
        }
    }
}
