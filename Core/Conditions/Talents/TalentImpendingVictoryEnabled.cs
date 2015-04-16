using Styx;

namespace InnerRage.Core.Conditions.Talents
{
    internal class TalentImpendingVictoryEnabledCondition : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.KnowsSpell(SpellBook.SpellImpendingVictory);
        }
    }
}