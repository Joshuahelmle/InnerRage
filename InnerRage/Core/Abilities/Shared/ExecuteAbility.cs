using System.Threading.Tasks;
using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Auras;
using Styx;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace InnerRage.Core.Abilities.Shared
{
    public class ExecuteAbility :AbilityBase
    {
        public ExecuteAbility()
            : base(WoWSpell.FromId(SpellBook.SpellExecute), true, false)
        {
            base.Category = AbilityCategory.Combat;
            base.Conditions.Add(new ConditionSwitchTester(
                new IsInCurrentSpecializationCondition(WoWSpec.WarriorFury), 
                new DoesHaveEnrageUpCondition()));
            base.Conditions.Add(new ConditionSwitchTester(
                new IsInCurrentSpecializationCondition(WoWSpec.WarriorArms),
                new ConditionOrList(
                new MinRageCondition(72),
                new TargetAuraUpCondition(MyCurrentTarget, WoWSpell.FromId(SpellBook.SpellCollosusSmash)),
                new TargetIsInHealthRangeCondition(MyCurrentTarget,0,2)
                
                        )));
        }

    


        public async override Task<bool> CastOnTarget(WoWUnit target)
        {
            base.Conditions.Add(new TargetInExecuteRangeCondition(target));
            return await base.CastOnTarget(target);
        }
    }
}