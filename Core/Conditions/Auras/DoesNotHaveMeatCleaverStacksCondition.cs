using Styx;

namespace InnerRage.Core.Conditions.Auras
{
    internal class DoesNotHaveMeatCleaverStacksCondition : ICondition
    {
        public bool Satisfied()
        {
            return !StyxWoW.Me.HasAura(SpellBook.AuraMeatCleaver);
        }
    }
}