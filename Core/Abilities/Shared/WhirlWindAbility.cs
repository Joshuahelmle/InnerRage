using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Auras;
using InnerRage.Core.Conditions.Talents;
using Styx;
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

        public override async Task<bool> CastOnTarget(WoWUnit target)
        {
            
            base.Conditions.Clear();
            if (MustWaitForGlobalCooldown) this.Conditions.Add(new IsOffGlobalCooldownCondition());
            if (MustWaitForSpellCooldown) this.Conditions.Add(new SpellIsNotOnCooldownCondition(this.Spell));
            base.Conditions.Add(new InMeeleRangeCondition());
            base.Conditions.Add(new BooleanCondition((!Me.KnowsSpell(SpellBook.SpellSlam))));
            base.Conditions.Add( new TargetNotInExecuteRangeCondition(Target));
            base.Conditions.Add(new ConditionOrList(
                new MinRageCondition(40), //i have more than 40 rage or
                new TargetAuraUpCondition(Target, WoWSpell.FromId(SpellBook.SpellCollosusSmash))));
            base.Conditions.Add(new ConditionSwitchTester(
                new IsInCurrentSpecializationCondition(WoWSpec.WarriorArms),
                new CoolDownLeftMinCondition(WoWSpell.FromId(SpellBook.SpellCollosusSmash), TimeSpan.FromSeconds(1))));             //CT hast colossussmash debuff up and
                         //Colossussmash cooldown greater than 1 sec
                       

            return await base.CastOnTarget(Target);
        }
    }
}
