using Styx;

namespace InnerRage.Core.Conditions.Auras
{
    internal class HasBloodSurgeStacksCondition : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.HasAura(SpellBook.AuraBloodSurge);
        }
    }
}