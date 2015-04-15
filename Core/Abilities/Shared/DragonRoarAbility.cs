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
            base.Category = AbilityCategory.Combat;
            base.Conditions.Add(new BooleanCondition(SettingsManager.Instance.TalentDragonRoar));
            base.Conditions.Add(new TalentDragonRoarEnabledCondition());
            base.Conditions.Add(// Sync with bloodbath
                new ConditionSwitchTester(
                    new BooleanCondition(SettingsManager.Instance.TalentSyncDragonRoar),
                    new BloodBathUpOrNotEnabledCondition()));
            base.Conditions.Add(new ConditionSwitchTester(
                new IsInCurrentSpecializationCondition(WoWSpec.WarriorArms),
                new DoesNotHaveAuraUpCondition(MyCurrentTarget, WoWSpell.FromId(SpellBook.SpellCollosusSmash))));
        }
    }
}