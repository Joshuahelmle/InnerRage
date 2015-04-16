using System;
using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Talents;
using Styx;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared
{
    internal class ImpendingVictoryAbility : AbilityBase
    {
        public ImpendingVictoryAbility()
            : base(WoWSpell.FromId(SpellBook.SpellImpendingVictory), true, true)
        {
            Category = AbilityCategory.Heal;
            Conditions.Add(new TalentImpendingVictoryEnabledCondition());
            Conditions.Add(new ConditionOrList(
                new BooleanCondition(Me.CurrentHealth < 70), //use as Heal
                new TalentUnquenchableThirstNotEnabledCondition()));
            //if not needed as a heal never use it in conjunction with unquenchable Thirst. DPS LOSS
            Conditions.Add(new ConditionSwitchTester(
                new IsInCurrentSpecializationCondition(WoWSpec.WarriorArms),
                new ConditionAndList(
                    new MaxRageCondition(40),
                    new CoolDownLeftMinCondition(WoWSpell.FromId(SpellBook.SpellCollosusSmash),
                        TimeSpan.FromSeconds(1)))));
        }
    }
}