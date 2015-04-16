using System;
using System.Threading.Tasks;
using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Auras;
using Styx;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace InnerRage.Core.Abilities.Shared
{
    internal class WhirlWindAbility : AbilityBase
    {
        public WhirlWindAbility()
            : base(WoWSpell.FromId(SpellBook.SpellWhirlwind), true, false)
        {
            Category = AbilityCategory.Combat;
        }

        public override async Task<bool> CastOnTarget(WoWUnit target)
        {
            Conditions.Clear();
            if (MustWaitForGlobalCooldown) Conditions.Add(new IsOffGlobalCooldownCondition());
            if (MustWaitForSpellCooldown) Conditions.Add(new SpellIsNotOnCooldownCondition(Spell));
            Conditions.Add(new InMeeleRangeCondition());
            Conditions.Add(new BooleanCondition((!Me.KnowsSpell(SpellBook.SpellSlam))));
            Conditions.Add(new TargetNotInExecuteRangeCondition(Target));
            Conditions.Add(new ConditionOrList(
                new MinRageCondition(40), //i have more than 40 rage or
                new TargetAuraUpCondition(Target, WoWSpell.FromId(SpellBook.SpellCollosusSmash))));
            Conditions.Add(new ConditionSwitchTester(
                new IsInCurrentSpecializationCondition(WoWSpec.WarriorArms),
                new CoolDownLeftMinCondition(WoWSpell.FromId(SpellBook.SpellCollosusSmash), TimeSpan.FromSeconds(1))));
            //CT hast colossussmash debuff up and
            //Colossussmash cooldown greater than 1 sec


            return await base.CastOnTarget(Target);
        }
    }
}