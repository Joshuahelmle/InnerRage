using System;
using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Talents;
using InnerRage.Core.Managers;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared
{
    internal class RecklessnessAbility : AbilityBase
    {
        public RecklessnessAbility()
            : base(WoWSpell.FromId(SpellBook.SpellRecklessness), false, true)
        {
            base.Category = AbilityCategory.Buff;
            base.Conditions.Add(
                new ConditionAndList( // target is in executerange or above 40% hp to use it again in executerange
                    new ConditionOrList(new TargetInExecuteRangeCondition(MyCurrentTarget),
                        new TargetIsInHealthRangeCondition(MyCurrentTarget, 40)
                        )
                    ));
            base.Conditions.Add(new ConditionSwitchTester(// only on bloodbath? then test if bloodbath is up or not learned
                new BooleanCondition(SettingsManager.Instance.TalentRecklessnessOnBloodBath),
                new BloodBathUpOrNotEnabledCondition(),
                new BooleanCondition(SettingsManager.Instance.TalentRecklessnessAlways)
                ));
        }
    }
}