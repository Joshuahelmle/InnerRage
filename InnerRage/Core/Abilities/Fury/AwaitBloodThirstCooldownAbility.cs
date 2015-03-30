using System;
using InnerRage.Core.Conditions;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Fury
{
    class AwaitBloodThirstCooldownAbility: AbilityBase
    {
        public AwaitBloodThirstCooldownAbility()
            : base(WoWSpell.FromId(SpellBook.SpellBloodThirst), true, true)
        {
            base.Category = AbilityCategory.Combat;
            base.Conditions.Add(new CooldownTimeLeftMaxCondition(this.Spell, TimeSpan.FromSeconds(0.5)));
            base.Conditions.Add(new MinRageCondition(50));
        }
    }
}
