using System;
using InnerRage.Core.Conditions;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Fury
{
    internal class AwaitBloodThirstCooldownAbility : AbilityBase
    {
        public AwaitBloodThirstCooldownAbility()
            : base(WoWSpell.FromId(SpellBook.SpellBloodThirst), true, true)
        {
            Category = AbilityCategory.Combat;
            Conditions.Add(new CooldownTimeLeftMaxCondition(Spell, TimeSpan.FromSeconds(0.5)));
            Conditions.Add(new MaxRageCondition(50));
        }
    }
}