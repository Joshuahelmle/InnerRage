using Styx;

namespace InnerRage.Core.Conditions
{
    class DoesHaveEnrageUpCondition : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.HasAura(SpellBook.AuraEnrage);
        }
    }
}
