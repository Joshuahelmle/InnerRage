using Styx;

namespace InnerRage.Core.Conditions
{
    internal class RecklessnessIsUpCondition : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.HasAura(SpellBook.SpellRecklessness);
        }
    }
}