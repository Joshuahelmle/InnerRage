using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Auras;
using InnerRage.Core.Conditions.Talents;
using InnerRage.Core.Managers;
using Styx;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared
{
    public class DragonRoarAbility : AbilityBase
    {
        public DragonRoarAbility()
            : base(WoWSpell.FromId(SpellBook.SpellDragonRoar), true, true)
        {
            Category = AbilityCategory.Combat;
            Conditions.Add(new InMeeleRangeCondition());
            Conditions.Add(new BooleanCondition(SettingsManager.Instance.TalentDragonRoar));
            Conditions.Add(new ConditionSwitchTester(
                new BooleanCondition(SettingsManager.Instance.DragonRoarOnlyOnBoss),
                new OnlyOnBossCondition()));
            Conditions.Add(new ConditionSwitchTester(
                new BooleanCondition(SettingsManager.Instance.DragonRoarOnlyOnAoECount),
                new BooleanCondition(UnitManager.Instance.LastKnownSurroundingEnemies.Count >=
                                     SettingsManager.Instance.DragonRoarAoeCount)));
            Conditions.Add(new TalentDragonRoarEnabledCondition());
            Conditions.Add( // Sync with bloodbath
                new ConditionSwitchTester(
                    new BooleanCondition(SettingsManager.Instance.TalentSyncDragonRoar),
                    new BloodBathUpOrNotEnabledCondition()));
            Conditions.Add(new ConditionSwitchTester(
                new IsInCurrentSpecializationCondition(WoWSpec.WarriorArms),
                new DoesNotHaveAuraUpCondition(MyCurrentTarget, WoWSpell.FromId(SpellBook.SpellCollosusSmash))));
        }
    }
}