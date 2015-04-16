﻿using InnerRage.Core.Conditions;
using InnerRage.Core.Managers;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared
{
    public class DieByTheSwordAbility : AbilityBase
    {
        public DieByTheSwordAbility() 
            : base(WoWSpell.FromId(SpellBook.SpellDieByTheSword), false, true)
        {
            Category = AbilityCategory.Buff;
            base.Conditions.Add(new BooleanCondition(SettingsManager.Instance.UseDieByTheSword));
            base.Conditions.Add(new TargetIsInHealthRangeCondition(Me, 0 ,SettingsManager.Instance.UseDieByTheSwordHP));
        }
    }
}