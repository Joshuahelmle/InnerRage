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
    public class StormBoltAbility : AbilityBase
    {
        public StormBoltAbility()
            : base(WoWSpell.FromId(SpellBook.SpellStormBolt), true, true)
        {
            Category = AbilityCategory.Combat;
        }

        public override async Task<bool> CastOnTarget(WoWUnit target)
        {
            Conditions.Clear();
            if (MustWaitForGlobalCooldown) Conditions.Add(new IsOffGlobalCooldownCondition());
            if (MustWaitForSpellCooldown) Conditions.Add(new SpellIsNotOnCooldownCondition(Spell));
            Conditions.Add(new InMeeleRangeCondition());
            Conditions.Add(new BooleanCondition(SettingsManager.Instance.TalentStormBolt));
            Conditions.Add(new TalentStormBoltEnabledCondition());
            Conditions.Add(new ConditionSwitchTester(
                new IsInCurrentSpecializationCondition(WoWSpec.WarriorArms),
                new ConditionOrList(
                    new TargetNotInExecuteRangeCondition(MyCurrentTarget),
                    new ConditionAndList(
                        new TargetInExecuteRangeCondition(MyCurrentTarget),
                        new TargetAuraUpCondition(MyCurrentTarget, WoWSpell.FromId(SpellBook.SpellCollosusSmash)))
                    )));
            Conditions.Add(new InMeeleRangeCondition());
            return await base.CastOnTarget(target);
        }
    }
}