﻿using Styx;

namespace InnerRage.Core.Conditions.Talents
{
    class TalentBloodBathEnabledCondition : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.KnowsSpell(SpellBook.SpellBloodbath);
        }

    }
}
