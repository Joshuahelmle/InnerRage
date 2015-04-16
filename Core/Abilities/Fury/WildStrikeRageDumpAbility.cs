using System.Threading.Tasks;
using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Glyphs;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace InnerRage.Core.Abilities.Fury
{
    /// <summary>
    ///     Casting Wildstrike to not cap rage
    /// </summary>
    internal class WildStrikeRageDumpAbility : AbilityBase
    {
        public WildStrikeRageDumpAbility() : base(WoWSpell.FromId(SpellBook.SpellWildStrike), true, false)
        {
            Category = AbilityCategory.Combat;
        }

        public override async Task<bool> CastOnTarget(WoWUnit target)
        {
            Conditions.Clear();
            if (MustWaitForGlobalCooldown) Conditions.Add(new IsOffGlobalCooldownCondition());
            if (MustWaitForSpellCooldown) Conditions.Add(new SpellIsNotOnCooldownCondition(Spell));
            Conditions.Add(new InMeeleRangeCondition());
            Conditions.Add(new BooleanCondition(Target != null));
            Conditions.Add(new ConditionOrList(
                new ConditionSwitchTester(
                    new GlyphUnendingRageCondition(),
                    new MaxRageCondition(100),
                    new MaxRageCondition(80)),
                new TargetNotInExecuteRangeCondition(target)));
            return await base.CastOnTarget(target);
        }
    }
}