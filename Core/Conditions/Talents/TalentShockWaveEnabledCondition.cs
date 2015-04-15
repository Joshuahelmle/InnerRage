using System;
using Styx;

namespace InnerRage.Core.Conditions.Talents
{
    class TalentShockWaveEnabledCondition : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.KnowsSpell(SpellBook.SpellShockwave);
        }
    }
}
