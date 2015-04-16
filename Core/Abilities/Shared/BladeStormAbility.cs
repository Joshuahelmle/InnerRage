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
            Category = AbilityCategory.Combat;
        }

        public override async Task<bool> CastOnTarget(WoWUnit target)
        {
            Conditions.Clear();
            if (MustWaitForGlobalCooldown) Conditions.Add(new IsOffGlobalCooldownCondition());
            if (MustWaitForSpellCooldown) Conditions.Add(new SpellIsNotOnCooldownCondition(Spell));
            Conditions.Add(new InMeeleRangeCondition());
            Conditions.Add(new ConditionSwitchTester(
                new BooleanCondition(SettingsManager.Instance.BladestormOnlyOnBoss),
                new OnlyOnBossCondition()));
            Conditions.Add(new ConditionSwitchTester(
                new BooleanCondition(SettingsManager.Instance.BladestormOnlyOnAoECount),
                new BooleanCondition(UnitManager.Instance.LastKnownSurroundingEnemies.Count >=
                                     SettingsManager.Instance.BladestormAoeCount)));
            Conditions.Add(new BooleanCondition(SettingsManager.Instance.TalentBladeStorm));
            Conditions.Add(new TalentBladeStormEnabledCondition());
            Conditions.Add(new ConditionSwitchTester(
                new IsInCurrentSpecializationCondition(WoWSpec.WarriorFury),
                new DoesHaveEnrageUpCondition()));
            Conditions.Add(new ConditionSwitchTester(
                new IsInCurrentSpecializationCondition(WoWSpec.WarriorArms), // if in Arms specc then
                new ConditionOrList(
                    new ConditionAndList(
                        new TargetNotInExecuteRangeCondition(MyCurrentTarget), //target is not in ExecuteRange and
                        new ConditionOrList(
                            new TargetAuraUpCondition(MyCurrentTarget, WoWSpell.FromId(SpellBook.SpellCollosusSmash)),
                            //target has CollosusSmash debuff or
                            new SpellCoolDownLowerThanCondition(WoWSpell.FromId(SpellBook.SpellCollosusSmash),
                                TimeSpan.FromSeconds(3)))), //CollosusSmash Cooldown remains fr more than 3 seconds
                    new ConditionAndList( // or target is in executerange, then
                        new TargetInExecuteRangeCondition(MyCurrentTarget),
                        new MaxRageCondition(30)), //have no more than 30 rage or
                    new SpellCoolDownLowerThanCondition(WoWSpell.FromId(SpellBook.SpellCollosusSmash),
                        TimeSpan.FromSeconds(4))))); //collosussmash cooldown remains for more than 4 seconds
            return await base.CastOnTarget(target);
        }
    }
}