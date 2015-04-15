using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Talents;
using Styx.CommonBot;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Arms
{
    class SlamAbility : AbilityBase
    {
        public SlamAbility() 
            : base(WoWSpell.FromId(SpellBook.SpellSlam), true, true)
        {
            base.Category = AbilityCategory.Combat;
            base.Conditions.Add(new TalentSlamEnabled());
            base.Conditions.Add(new ConditionAndList(
                new ConditionOrList(
                    new MinRageCondition(20),
                    new CooldownTimeLeftMaxCondition(WoWSpell.FromId(SpellBook.SpellCollosusSmash), SpellManager.GlobalCooldownLeft)),
                    new TargetNotInExecuteRangeCondition(MyCurrentTarget),
                    new CooldownTimeLeftMaxCondition(WoWSpell.FromId(SpellBook.SpellCollosusSmash), TimeSpan.FromSeconds(1))));
        }
    }
}
