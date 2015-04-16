﻿using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Auras;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Protection
{
    public class ShieldBarrierAbility : AbilityBase
    {
        public ShieldBarrierAbility() 
            : base(WoWSpell.FromId(SpellBook.SpellShieldBarrier), false, false)
        {
            Category = AbilityCategory.Buff;
            Conditions.Add(new ConditionAndList(
                new DoesNotHaveAuraUpCondition(Me, Spell),
                new ConditionOrList(
                    new DoesNotHaveAuraUpCondition(Me, WoWSpell.FromId(SpellBook.AuraShieldBlock)),
                    new MinRageCondition(85))));
        }
    }
}