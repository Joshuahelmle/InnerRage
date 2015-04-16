using System.Threading.Tasks;
using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Auras;
using Styx;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace InnerRage.Core.Abilities.Shared
{
    public class ExecuteAbility : AbilityBase
    {
        public ExecuteAbility()
            : base(WoWSpell.FromId(SpellBook.SpellExecute), true, false)
        {
            Category = AbilityCategory.Combat;
        }

        public override async Task<bool> CastOnTarget(WoWUnit target)
        {
            Conditions.Clear();
            if (MustWaitForGlobalCooldown) Conditions.Add(new IsOffGlobalCooldownCondition());
            if (MustWaitForSpellCooldown) Conditions.Add(new SpellIsNotOnCooldownCondition(Spell));
            Conditions.Add(new InMeeleRangeCondition());
            Conditions.Add(new TargetInExecuteRangeCondition(Target));
            Conditions.Add(new ConditionSwitchTester(
                new IsInCurrentSpecializationCondition(WoWSpec.WarriorFury),
                new DoesHaveEnrageUpCondition()));
            Conditions.Add(new ConditionSwitchTester(
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