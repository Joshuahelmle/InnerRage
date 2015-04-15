using Styx;

namespace InnerRage.Core.Conditions.Talents
{
    /// <summary>
    /// determines if Ravager Talent chosen.
    /// </summary>
    class TalentRavagerEnabledCondition : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.KnowsSpell(SpellBook.SpellRavager);
        }
    }
}
