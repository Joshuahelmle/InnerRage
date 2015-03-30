using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Auras;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared
{
    class ThunderclapAbility : AbilityBase
    {
        public ThunderclapAbility()
            : base(WoWSpell.FromId(SpellBook.SpellThunderClap),true, true)
        {
            base.Category = AbilityCategory.Combat;
            base.Conditions.Add(new BooleanCondition(!Me.KnowsSpell(SpellBook.SpellSlam)));
            base.Conditions.Add(new TargetNotInExecuteRangeCondition(MyCurrentTarget));
            base.Conditions.Add(new ConditionOrList(
                new MinRageCondition(40),
                new TargetAuraUpCondition(MyCurrentTarget, WoWSpell.FromId(SpellBook.SpellCollosusSmash))));
            base.Conditions.Add(new BooleanCondition(Me.KnowsSpell(SpellBook.GlyphOfResonatingPower)));
            base.Conditions.Add(new CoolDownLeftMinCondition(WoWSpell.FromId(SpellBook.SpellCollosusSmash), TimeSpan.FromSeconds(1)));

        }
    }
}
