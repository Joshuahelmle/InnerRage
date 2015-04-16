using Styx;

namespace InnerRage.Core.Conditions.Talents
{
    internal class TalentSiegebreakerEnabled : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.KnowsSpell(SpellBook.SpellSiegeBreaker);
        }
    }
}