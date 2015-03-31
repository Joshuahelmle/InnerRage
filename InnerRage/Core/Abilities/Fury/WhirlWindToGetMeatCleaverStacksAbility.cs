using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Auras;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace InnerRage.Core.Abilities.Fury
{
    class WhirlWindToGetMeatCleaverStacksAbility : AbilityBase
    {
        public WhirlWindToGetMeatCleaverStacksAbility()
            : base(WoWSpell.FromId(SpellBook.SpellWhirlwind), true, false)
        {
            base.Category = AbilityCategory.Combat;
            
        }

        public override Task<bool> CastOnTarget(WoWUnit target)
        {
            if (MustWaitForGlobalCooldown) this.Conditions.Add(new IsOffGlobalCooldownCondition());
            if (MustWaitForSpellCooldown) this.Conditions.Add(new SpellIsNotOnCooldownCondition(this.Spell));
            base.Conditions.Add(new DoesNotHaveMeatCleaverStacksCondition());
            base.Conditions.Add(new TargetNotInExecuteRangeCondition(Target));
            return base.CastOnTarget(Target);
        }
    }
}
