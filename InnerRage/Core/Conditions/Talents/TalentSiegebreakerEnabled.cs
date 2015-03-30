using System;
using Styx;

namespace InnerRage.Core.Conditions.Talents
{
    class TalentSiegebreakerEnabled : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.KnowsSpell(SpellBook.SpellSiegeBreaker);
        }
    }
}
