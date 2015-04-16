using Styx;

namespace InnerRage.Core.Conditions
{
    internal class DoesHaveEnrageUpCondition : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.HasAura(SpellBook.AuraEnrage);
        }
    }
}