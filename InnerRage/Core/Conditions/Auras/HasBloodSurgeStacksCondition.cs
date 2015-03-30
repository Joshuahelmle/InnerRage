using System;
using Styx;

namespace InnerRage.Core.Conditions.Auras
{
    class HasBloodSurgeStacksCondition : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.HasAura(SpellBook.AuraBloodSurge);
        }
    }
}
