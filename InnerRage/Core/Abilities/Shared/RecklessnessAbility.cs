using System;
using System.Threading.Tasks;
using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Talents;
using InnerRage.Core.Managers;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace InnerRage.Core.Abilities.Shared
{
    internal class RecklessnessAbility : AbilityBase
    {
        public RecklessnessAbility()
            : base(WoWSpell.FromId(SpellBook.SpellRecklessness), false, true)
        {
            base.Category = AbilityCategory.Buff;
            
        }

        public async override Task<bool> CastOnTarget(WoWUnit target)
        {
            base.Conditions.Clear();
            if (MustWaitForGlobalCooldown) this.Conditions.Add(new IsOffGlobalCooldownCondition());
            if (MustWaitForSpellCooldown) this.Conditions.Add(new SpellIsNotOnCooldownCondition(this.Spell));
            base.Conditions.Add(new InMeeleRangeCondition());
            base.Conditions.Add(
                    new ConditionOrList(new TargetInExecuteRangeCondition(MyCurrentTarget),
                        new TargetIsInHealthRangeCondition(MyCurrentTarget, 40)
                    ));
            base.Conditions.Add(new ConditionSwitchTester(// only on bloodbath? then test if bloodbath is up or not learned
                new BooleanCondition(SettingsManager.Instance.TalentRecklessnessOnBloodBath),
                new BloodBathUpOrNotEnabledCondition(),
                new BooleanCondition(SettingsManager.Instance.TalentRecklessnessAlways)
                ));
            return await base.CastOnTarget(target);
        }
    }
}