﻿using InnerRage.Core.Conditions.Auras;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Protection
{
    public class ShieldSlamAbility : AbilityBase
    {
        public ShieldSlamAbility() 
            : base(WoWSpell.FromId(SpellBook.SpellShieldSlam), true, true)
        {
            base.Category = AbilityCategory.Combat;
            Conditions.Add(new DoesNotHaveAuraUpCondition(Me, WoWSpell.FromId(50227)));
        }
    }
}