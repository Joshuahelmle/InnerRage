using System.Threading.Tasks;
using InnerRage.Core.Conditions;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace InnerRage.Core.Abilities.Fury
{
    public class WildStrikeWithoutBloodSurgeAbility : AbilityBase
    {
        public WildStrikeWithoutBloodSurgeAbility()
            : base(WoWSpell.FromId(SpellBook.SpellWildStrike), true, false)
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
            Conditions.Add(new DoesHaveEnrageUpCondition());
            Conditions.Add(new TargetNotInExecuteRangeCondition(target));
            return await base.CastOnTarget(target);
        }
    }
}