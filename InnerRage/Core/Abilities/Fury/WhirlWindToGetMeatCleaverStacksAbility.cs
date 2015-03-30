using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Auras;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Fury
{
    class WhirlWindToGetMeatCleaverStacksAbility : AbilityBase
    {
        public WhirlWindToGetMeatCleaverStacksAbility()
            : base(WoWSpell.FromId(SpellBook.SpellWhirlwind), true, false)
        {
            base.Category = AbilityCategory.Combat;
            base.Conditions.Add(new DoesNotHaveMeatCleaverStacksCondition());
            base.Conditions.Add(new TargetNotInExecuteRangeCondition(MyCurrentTarget));
        }
    }
}
