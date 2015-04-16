using System.Threading.Tasks;
using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Auras;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace InnerRage.Core.Abilities.Fury
{
    internal class WhirlWindToGetMeatCleaverStacksAbility : AbilityBase
    {
        public WhirlWindToGetMeatCleaverStacksAbility()
            : base(WoWSpell.FromId(SpellBook.SpellWhirlwind), true, false)
        {
            Category = AbilityCategory.Combat;
        }

        public override async Task<bool> CastOnTarget(WoWUnit target)
        {
            Conditions.Clear();
            if (MustWaitForGlobalCooldown) Conditions.Add(new IsOffGlobalCooldownCondition());
            if (MustWaitForSpellCooldown) Conditions.Add(new SpellIsNotOnCooldownCondition(Spell));
            Conditions.Add(new InMeeleRangeCondition());
            Conditions.Add(new DoesNotHaveMeatCleaverStacksCondition());
            Conditions.Add(new TargetNotInExecuteRangeCondition(Target));
            return await base.CastOnTarget(Target);
        }
    }
}