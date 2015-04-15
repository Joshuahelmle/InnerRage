using System;
using Styx;

namespace InnerRage.Core.Conditions.Talents
{
    class TalentImpendingVictoryEnabledCondition : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.KnowsSpell(SpellBook.SpellImpendingVictory);
        }
    }
}
