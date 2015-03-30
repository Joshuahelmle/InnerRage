using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Arms
{
    class SweepingStrikesAbility : AbilityBase
    {
        public SweepingStrikesAbility() 
            : base(WoWSpell.FromId(SpellBook.SpellSweepingStrikes), false, true)
        {
            base.Category = AbilityCategory.Buff;
            
        }
    }
}
