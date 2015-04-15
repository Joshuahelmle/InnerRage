using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnerRage.Core.Conditions.Auras;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Fury
{
    /// <summary>
    /// Casting Wildtrike to get rid of Bloodsurge stacks
    /// </summary>
    class WildStrikeWithBloodSurgeUpAbility : AbilityBase
    {
        public WildStrikeWithBloodSurgeUpAbility()
            : base(WoWSpell.FromId(SpellBook.SpellWildStrike),true, false)
        {
            base.Category = AbilityCategory.Combat;
            base.Conditions.Add(new HasBloodSurgeStacksCondition());
        }
    }
}
