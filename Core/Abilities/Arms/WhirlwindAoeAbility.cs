using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnerRage.Core.Conditions;
using Styx;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace InnerRage.Core.Abilities.Arms
{
    class WhirlwindAoeAbility :AbilityBase
    {
        public WhirlwindAoeAbility() : base(WoWSpell.FromId(SpellBook.SpellWhirlwind), true, false)
        {
            base.Category = AbilityCategory.Combat;
        }


        public async override Task<bool> CastOnTarget(WoWUnit target)
        {
            base.Conditions.Clear();
            base.Conditions.Add(new InMeeleRangeCondition());
            if (MustWaitForGlobalCooldown) base.Conditions.Add(new IsOffGlobalCooldownCondition());
            if (MustWaitForSpellCooldown) base.Conditions.Add(new SpellIsNotOnCooldownCondition(this.Spell));
            base.Conditions.Add(new InMeeleRangeCondition());
            base.Conditions.Add(new TargetNotInExecuteRangeCondition(Target));
            return await base.CastOnTarget(target);
        }

       
           
    }
}
