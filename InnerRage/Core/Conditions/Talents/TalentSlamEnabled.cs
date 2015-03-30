using System;
using Styx;

namespace InnerRage.Core.Conditions.Talents
{
    class TalentSlamEnabled : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.KnowsSpell(SpellBook.SpellSlam);
        }
    }
}
