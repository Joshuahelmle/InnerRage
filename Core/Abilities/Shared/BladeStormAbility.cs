using System;
using System.Threading.Tasks;
using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Auras;
using InnerRage.Core.Conditions.Talents;
using InnerRage.Core.Managers;
using Styx;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace InnerRage.Core.Abilities.Shared
{
    public class BladeStormAbility : AbilityBase
    {
        public BladeStormAbility()
            : base(WoWSpell.FromId(SpellBook.SpellBladestorm), true, true)
        {
            base.Category = AbilityCategory.Combat;
            

        }

        public override async Task<bool> CastOnTarget(WoWUnit target)
        {
            base.Conditions.Clear();
            if (MustWaitForGlobalCooldown) this.Conditions.Add(new IsOffGlobalCooldownCondition());
            if (MustWaitForSpellCooldown) this.Conditions.Add(new SpellIsNotOnCooldownCondition(this.Spell));
            base.Conditions.Add(new InMeeleRangeCondition());
            base.Conditions.Add(new ConditionSwitchTester(
                new BooleanCondition(SettingsManager.Instance.BladestormOnlyOnBoss),
                new OnlyOnBossCondition()));
            base.Conditions.Add(new ConditionSwitchTester(
                new BooleanCondition(SettingsManager.Instance.BladestormOnlyOnAoECount),
                new BooleanCondition(UnitManager.Instance.LastKnownSurroundingEnemies.Count >= SettingsManager.Instance.BladestormAoeCount)));
            base.Conditions.Add(new BooleanCondition(SettingsManager.Instance.TalentBladeStorm));
            base.Conditions.Add(new TalentBladeStormEnabledCondition());
            base.Conditions.Add(new ConditionSwitchTester(
                new IsInCurrentSpecializationCondition(WoWSpec.WarriorFury),
                new DoesHaveEnrageUpCondition()));
            base.Conditions.Add( //Sync with Bloodbath
                new ConditionSwitchTester(
                    new BooleanCondition(SettingsManager.Instance.TalentSyncBladeStorm),
                    new BloodBathUpOrNotEnabledCondition()));
            base.Conditions.Add(new ConditionSwitchTester(
                new IsInCurrentSpecializationCondition(WoWSpec.WarriorArms), // if in Arms specc then
                new ConditionOrList(
                    new ConditionAndList(
                        new TargetNotInExecuteRangeCondition(MyCurrentTarget), //target is not in ExecuteRange and
                        new ConditionOrList(
                            new TargetAuraUpCondition(MyCurrentTarget, WoWSpell.FromId(SpellBook.SpellCollosusSmash)), //target has CollosusSmash debuff or
                            new SpellCoolDownLowerThanCondition(WoWSpell.FromId(SpellBook.SpellCollosusSmash), TimeSpan.FromSeconds(3)))), //CollosusSmash Cooldown remains fr more than 3 seconds
                    new ConditionAndList( // or target is in executerange, then
                        new TargetInExecuteRangeCondition(MyCurrentTarget),
                        new MaxRageCondition(30)), //have no more than 30 rage or
                        new SpellCoolDownLowerThanCondition(WoWSpell.FromId(SpellBook.SpellCollosusSmash), TimeSpan.FromSeconds(4))))); //collosussmash cooldown remains for more than 4 seconds
            return await base.CastOnTarget(target);
        }
    }
}