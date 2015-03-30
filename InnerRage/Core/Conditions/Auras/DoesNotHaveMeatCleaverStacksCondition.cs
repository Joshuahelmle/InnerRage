using System;
using Styx;

namespace InnerRage.Core.Conditions.Auras
{
    class DoesNotHaveMeatCleaverStacksCondition : ICondition
    {
        public bool Satisfied()
        {
            return !StyxWoW.Me.HasAura(SpellBook.AuraMeatCleaver);
        }
    }
}
