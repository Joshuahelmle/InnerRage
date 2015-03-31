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
            
        }

    


        public async override Task<bool> CastOnTarget(WoWUnit target)
        {
            base.Conditions.Clear();
            if (MustWaitForGlobalCooldown) this.Conditions.Add(new IsOffGlobalCooldownCondition());
            if (MustWaitForSpellCooldown) this.Conditions.Add(new SpellIsNotOnCooldownCondition(this.Spell));
            base.Conditions.Add(new TargetInExecuteRangeCondition(Target));
            base.Conditions.Add(new ConditionSwitchTester(
                new IsInCurrentSpecializationCondition(WoWSpec.WarriorFury),
                new DoesHaveEnrageUpCondition()));
            base.Conditions.Add(new ConditionSwitchTester(
                new IsInCurrentSpecializationCondition(WoWSpec.WarriorArms),
                new ConditionOrList(
                new MinRageCondition(72),
                new TargetAuraUpCondition(Target, WoWSpell.FromId(SpellBook.SpellCollosusSmash)),
                new TargetIsInHealthRangeCondition(Target, 0, 2)

                        )));
            return await base.CastOnTarget(Target);
        }
    }
}