using System;
using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Talents;
using Styx.CommonBot;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Arms
{
    internal class SlamAbility : AbilityBase
    {
        public SlamAbility()
            : base(WoWSpell.FromId(SpellBook.SpellSlam), true, true)
        {
            Category = AbilityCategory.Combat;
            Conditions.Add(new TalentSlamEnabled());
            Conditions.Add(new ConditionAndList(
                new ConditionOrList(
                    new MinRageCondition(20),
                    new CooldownTimeLeftMaxCondition(WoWSpell.FromId(SpellBook.SpellCollosusSmash),
                        SpellManager.GlobalCooldownLeft)),
                new TargetNotInExecuteRangeCondition(MyCurrentTarget),
                new CooldownTimeLeftMaxCondition(WoWSpell.FromId(SpellBook.SpellCollosusSmash), TimeSpan.FromSeconds(1))));
        }
    }
}