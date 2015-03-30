using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Glyphs;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Fury
{
    /// <summary>
    /// Casting Wildstrike to not cap rage
    /// </summary>
    class WildStrikeRageDumpAbility : AbilityBase
    {
        public WildStrikeRageDumpAbility() : base(WoWSpell.FromId(SpellBook.SpellWildStrike), true, false)
        {
            base.Category = AbilityCategory.Combat;
            base.Conditions.Add(new ConditionOrList(
                new ConditionSwitchTester(
                    new GlyphUnendingRageCondition(),
                    new MaxRageCondition(100),
                    new MaxRageCondition(80)),
                    new TargetNotInExecuteRangeCondition(MyCurrentTarget)));

        }
    }
}
