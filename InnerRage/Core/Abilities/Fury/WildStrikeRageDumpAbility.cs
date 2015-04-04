using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Glyphs;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

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

        }


        public async override Task<bool> CastOnTarget(WoWUnit target)
        {
            base.Conditions.Clear();
            if (MustWaitForGlobalCooldown) this.Conditions.Add(new IsOffGlobalCooldownCondition());
            if (MustWaitForSpellCooldown) this.Conditions.Add(new SpellIsNotOnCooldownCondition(this.Spell));
            base.Conditions.Add(new InMeeleRangeCondition());
            base.Conditions.Add(new BooleanCondition(Target != null));
            base.Conditions.Add(new ConditionOrList(
                new ConditionSwitchTester(
                    new GlyphUnendingRageCondition(),
                    new MaxRageCondition(100),
                    new MaxRageCondition(80)),
                    new TargetNotInExecuteRangeCondition(target)));
            return await base.CastOnTarget(target);
        }
    }
}
