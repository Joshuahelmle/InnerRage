using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnerRage.Core.Conditions;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Arms
{
    class MortalStrikeAbility : AbilityBase
    {
           public MortalStrikeAbility() 
            : base(WoWSpell.FromId(SpellBook.SpellMortalStrike), true, true)
        {
            base.Category = AbilityCategory.Combat;
        }
        
    }
}
