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
            Category = AbilityCategory.Buff;
        }

        public override async Task<bool> CastOnTarget(WoWUnit target)
        {
            Conditions.Clear();
            if (MustWaitForGlobalCooldown) Conditions.Add(new IsOffGlobalCooldownCondition());
            if (MustWaitForSpellCooldown) Conditions.Add(new SpellIsNotOnCooldownCondition(Spell));
            Conditions.Add(new InMeeleRangeCondition());
            Conditions.Add(
                new ConditionOrList(new TargetInExecuteRangeCondition(MyCurrentTarget),
                    new TargetIsInHealthRangeCondition(MyCurrentTarget, 40)
                    ));
            Conditions.Add(new ConditionSwitchTester( // only on bloodbath? then test if bloodbath is up or not learned
                new BooleanCondition(SettingsManager.Instance.TalentRecklessnessOnBloodBath),
                new BloodBathUpOrNotEnabledCondition(),
                new BooleanCondition(SettingsManager.Instance.TalentRecklessnessAlways)
                ));
            Conditions.Add(new ConditionSwitchTester(
                new BooleanCondition(SettingsManager.Instance.RecklessOnlyOnBoss),
                new OnlyOnBossCondition()));
            return await base.CastOnTarget(target);
        }
    }
}