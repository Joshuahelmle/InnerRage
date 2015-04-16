using Styx;

namespace InnerRage.Core.Conditions.Talents
{
    internal class TalentUnquenchableThirstCondition : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.KnowsSpell(SpellBook.SpellUnquenchableThirst);
        }
    }
}