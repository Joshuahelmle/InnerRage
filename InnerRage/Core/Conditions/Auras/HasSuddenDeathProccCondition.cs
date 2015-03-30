using System;
using InnerRage.Core.Utilities;
using Styx;

namespace InnerRage.Core.Conditions.Auras
{
    class HasSuddenDeathProccCondition : ICondition
    {
        public bool Satisfied()
        {
            if(Main.Debug) 
            {if (StyxWoW.Me.HasAura(SpellBook.AuraSuddenDeath)) Log.Diagnostics("SuddenDeath up");}
            return StyxWoW.Me.HasAura(SpellBook.AuraSuddenDeath);
        }
    }
}
