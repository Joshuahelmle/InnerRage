using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Arms
{
    class CollosusSmashAbility : AbilityBase
    {
        public CollosusSmashAbility() 
            : base(WoWSpell.FromId(SpellBook.SpellCollosusSmash), true, true)
        {
            base.Category = AbilityCategory.Combat;
        }
    }
}
