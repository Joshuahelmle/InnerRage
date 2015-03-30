using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Talents;
using Styx;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared
{
    class ImpendingVictoryAbility : AbilityBase
    {
        public ImpendingVictoryAbility()
            : base(WoWSpell.FromId(SpellBook.SpellImpendingVictory), true, true)
        {
            base.Category = AbilityCategory.Heal;
            base.Conditions.Add(new TalentImpendingVictoryEnabledCondition());
            base.Conditions.Add(new ConditionOrList(
                new BooleanCondition(Me.CurrentHealth < 70), //use as Heal
                new TalentUnquenchableThirstNotEnabledCondition())); //if not needed as a heal never use it in conjunction with unquenchable Thirst. DPS LOSS
            base.Conditions.Add(new ConditionSwitchTester(
                new IsInCurrentSpecializationCondition(WoWSpec.WarriorArms), 
                new ConditionAndList(
                    new MaxRageCondition(40),
                    new CoolDownLeftMinCondition(WoWSpell.FromId(SpellBook.SpellCollosusSmash),
                        TimeSpan.FromSeconds(1)))));
                    
        }
    }
}
