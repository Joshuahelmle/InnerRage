using Styx;

namespace InnerRage.Core.Conditions
{
    class RecklessnessIsUpCondition : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.HasAura(SpellBook.SpellRecklessness);
        }
    }
}
