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
            base.Category = AbilityCategory.Combat;
           
        }


        public async override Task<bool> CastOnTarget(WoWUnit target)
        {
            base.Conditions.Clear();
            if (MustWaitForGlobalCooldown) this.Conditions.Add(new IsOffGlobalCooldownCondition());
            if (MustWaitForSpellCooldown) this.Conditions.Add(new SpellIsNotOnCooldownCondition(this.Spell));
            base.Conditions.Add(new InMeeleRangeCondition());
            base.Conditions.Add(new BooleanCondition(Target != null));
            base.Conditions.Add(new DoesHaveEnrageUpCondition());
            base.Conditions.Add(new TargetNotInExecuteRangeCondition(target));
            return await base.CastOnTarget(target);
        }
    }
}