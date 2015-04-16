using System;
using System.Threading.Tasks;
using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Auras;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace InnerRage.Core.Abilities.Shared
{
    internal class ThunderclapAbility : AbilityBase
    {
        public ThunderclapAbility()
            : base(WoWSpell.FromId(SpellBook.SpellThunderClap), true, true)
        {
            Category = AbilityCategory.Combat;
        }

        public override async Task<bool> CastOnTarget(WoWUnit target)
        {
            Conditions.Clear();
            if (MustWaitForGlobalCooldown) Conditions.Add(new IsOffGlobalCooldownCondition());
            if (MustWaitForSpellCooldown) Conditions.Add(new SpellIsNotOnCooldownCondition(Spell));
            Conditions.Add(new InMeeleRangeCondition());
            Conditions.Add(new BooleanCondition(!Me.KnowsSpell(SpellBook.SpellSlam)));
            Conditions.Add(new TargetNotInExecuteRangeCondition(MyCurrentTarget));
            Conditions.Add(new ConditionOrList(
                new MinRageCondition(40),
                new TargetAuraUpCondition(MyCurrentTarget, WoWSpell.FromId(SpellBook.SpellCollosusSmash))));
            Conditions.Add(new BooleanCondition(Me.KnowsSpell(SpellBook.GlyphOfResonatingPower)));
            Conditions.Add(new CoolDownLeftMinCondition(WoWSpell.FromId(SpellBook.SpellCollosusSmash),
                TimeSpan.FromSeconds(1)));
            return await base.CastOnTarget(target);
        }
    }
}