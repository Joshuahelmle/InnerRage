using System;
using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Talents;
using InnerRage.Core.Managers;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared
{
    class AvatarAbility : AbilityBase
    {
        public AvatarAbility()
            : base(WoWSpell.FromId(SpellBook.SpellAvatar), false, true)
        {
            base.Category = AbilityCategory.Buff;
            base.Conditions.Add(new BooleanCondition(SettingsManager.Instance.TalentAvatar));
            base.Conditions.Add(new TalentAvatarEnabledCondition());
            base.Conditions.Add(new ConditionOrList(
                new RecklessnessIsUpCondition(),
                new CooldownTimeLeftMaxCondition(WoWSpell.FromId(SpellBook.SpellRecklessness), TimeSpan.FromSeconds(60)),
                new TargetInExecuteRangeCondition(MyCurrentTarget))
                );
            base.Conditions.Add(
                new ConditionSwitchTester(//Sync with bloodbath
                    new BooleanCondition(SettingsManager.Instance.TalentSyncAvatar),
                    new BloodBathUpOrNotEnabledCondition()));
        }
    }
}
