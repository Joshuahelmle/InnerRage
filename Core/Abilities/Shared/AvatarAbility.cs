using System;
using System.Threading.Tasks;
using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Talents;
using InnerRage.Core.Managers;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace InnerRage.Core.Abilities.Shared
{
    internal class AvatarAbility : AbilityBase
    {
        public AvatarAbility()
            : base(WoWSpell.FromId(SpellBook.SpellAvatar), false, true)
        {
            Category = AbilityCategory.Buff;
        }

        public override async Task<bool> CastOnTarget(WoWUnit target)
        {
            if (MustWaitForGlobalCooldown) Conditions.Add(new IsOffGlobalCooldownCondition());
            if (MustWaitForSpellCooldown) Conditions.Add(new SpellIsNotOnCooldownCondition(Spell));
            Conditions.Add(new InMeeleRangeCondition());
            Conditions.Add(new BooleanCondition(SettingsManager.Instance.TalentAvatar));
            Conditions.Add(new TalentAvatarEnabledCondition());
            Conditions.Add(new ConditionOrList(
                new RecklessnessIsUpCondition(),
                new CooldownTimeLeftMaxCondition(WoWSpell.FromId(SpellBook.SpellRecklessness), TimeSpan.FromSeconds(60)),
                new TargetInExecuteRangeCondition(MyCurrentTarget))
                );
            Conditions.Add(
                new ConditionSwitchTester( //Sync with bloodbath
                    new BooleanCondition(SettingsManager.Instance.TalentSyncAvatar),
                    new BloodBathUpOrNotEnabledCondition()));
            return await base.CastOnTarget(target);
        }
    }
}