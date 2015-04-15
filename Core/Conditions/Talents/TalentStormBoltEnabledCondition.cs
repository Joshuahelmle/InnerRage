using System;
using Styx;

namespace InnerRage.Core.Conditions.Talents
{
    class TalentStormBoltEnabledCondition : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.KnowsSpell(SpellBook.SpellStormBolt);
        }
    }
}
