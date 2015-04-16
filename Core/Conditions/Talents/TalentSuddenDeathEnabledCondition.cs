using InnerRage.Core.Utilities;
using Styx;

namespace InnerRage.Core.Conditions.Talents
{
    internal class TalentSuddenDeathEnabledCondition : ICondition
    {
        public bool Satisfied()
        {
            if (Main.Debug)
            {
                if (StyxWoW.Me.KnowsSpell(SpellBook.SpellSuddenDeath)) Log.Diagnostics("Talent SuddenDeath enabled.");
            }
            return StyxWoW.Me.KnowsSpell(SpellBook.SpellSuddenDeath);
        }
    }
}