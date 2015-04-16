using Styx;

namespace InnerRage.Core.Conditions
{
    internal class DoesNotHaveStaminaBuffCondition : ICondition
    {
        public bool Satisfied()
        {
            return !StyxWoW.Me.HasStaminaBuff();
        }
    }
}