using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Auras;
using InnerRage.Core.Conditions.Talents;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared
{
    class WhirlWindAbility :AbilityBase
    {
        public WhirlWindAbility()
            : base(WoWSpell.FromId(SpellBook.SpellWhirlwind), true, false)
        {
            base.Category = AbilityCategory.Combat;
            base.Conditions.Add(new ConditionSwitchTester(
                new BooleanCondition(! new TalentSlamEnabled().Satisfied()),  //if Slam not learned
                new ConditionAndList(
                    new TargetNotInExecuteRangeCondition(MyCurrentTarget), //target not in executerange and
                    new ConditionOrList(
                        new MinRageCondition(40),  //i have more than 40 rage or
                        new TargetAuraUpCondition(MyCurrentTarget, WoWSpell.FromId(SpellBook.SpellCollosusSmash))), //CT hast colossussmash debuff up and
                        new CoolDownLeftMinCondition(WoWSpell.FromId(SpellBook.SpellCollosusSmash), TimeSpan.FromSeconds(1)) //Colossussmash cooldown greater than 1 sec
                        )));

        }
    }
}
