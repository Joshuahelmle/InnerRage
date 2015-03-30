using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Auras;
using InnerRage.Core.Conditions.Talents;
using InnerRage.Core.Managers;
using Styx;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared
{
    public class StormBoltAbility : AbilityBase
    {
        public StormBoltAbility() 
            : base(WoWSpell.FromId(SpellBook.SpellStormBolt),true,true)
        {
            base.Category = AbilityCategory.Combat;
            base.Conditions.Add(new BooleanCondition(SettingsManager.Instance.TalentStormBolt));
            base.Conditions.Add(new TalentStormBoltEnabledCondition());
            base.Conditions.Add(new ConditionSwitchTester(
                new IsInCurrentSpecializationCondition(WoWSpec.WarriorArms),
                new ConditionOrList(
                    new TargetNotInExecuteRangeCondition(MyCurrentTarget),
                    new ConditionAndList(
                        new TargetInExecuteRangeCondition(MyCurrentTarget),
                        new TargetAuraUpCondition(MyCurrentTarget, WoWSpell.FromId(SpellBook.SpellCollosusSmash)))
                    )));


        }
    }
}