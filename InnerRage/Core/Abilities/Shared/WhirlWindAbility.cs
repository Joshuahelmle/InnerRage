using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Auras;
using InnerRage.Core.Conditions.Talents;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace InnerRage.Core.Abilities.Shared
{
    class WhirlWindAbility :AbilityBase
    {
        public WhirlWindAbility()
            : base(WoWSpell.FromId(SpellBook.SpellWhirlwind), true, false)
        {
            base.Category = AbilityCategory.Combat;
        }

        public override Task<bool> CastOnTarget(WoWUnit target)
        {
            
            base.Conditions.Clear();
            if (MustWaitForGlobalCooldown) this.Conditions.Add(new IsOffGlobalCooldownCondition());
            if (MustWaitForSpellCooldown) this.Conditions.Add(new SpellIsNotOnCooldownCondition(this.Spell));
            base.Conditions.Add(new ConditionAndList(
                new BooleanCondition((!Me.KnowsSpell(SpellBook.SpellSlam))),  //if Slam not learned
                new ConditionAndList(
                    new TargetNotInExecuteRangeCondition(Target), //target not in executerange and
                    new ConditionOrList(
                        new MinRageCondition(40),  //i have more than 40 rage or
                        new TargetAuraUpCondition(Target, WoWSpell.FromId(SpellBook.SpellCollosusSmash))), //CT hast colossussmash debuff up and
                        new CoolDownLeftMinCondition(WoWSpell.FromId(SpellBook.SpellCollosusSmash), TimeSpan.FromSeconds(1)) //Colossussmash cooldown greater than 1 sec
                        )));

            return base.CastOnTarget(Target);
        }
    }
}
