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
            : base(WoWSpell.FromId(SpellBook.SpellStormBolt),true,true)
        {
            base.Category = AbilityCategory.Combat;


        }

        public override async Task<bool> CastOnTarget(WoWUnit target)
        {
            
            base.Conditions.Clear();
            if (MustWaitForGlobalCooldown) base.Conditions.Add(new IsOffGlobalCooldownCondition());
            if (MustWaitForSpellCooldown) base.Conditions.Add(new SpellIsNotOnCooldownCondition(this.Spell));
            base.Conditions.Add(new InMeeleRangeCondition());
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
            base.Conditions.Add(new InMeeleRangeCondition());
            return await base.CastOnTarget(target);
        }
    }
}