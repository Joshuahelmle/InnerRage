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
    /// <summary>
    /// Cast RagingBlow to get Rid of Meatcleaver stacks
    /// </summary>
    class RagingBlowWithMeatCleaverToNotCapAbility : AbilityBase
    {
        public RagingBlowWithMeatCleaverToNotCapAbility()
            : base(WoWSpell.FromId(SpellBook.SpellRagingBlow), true, false)
        {
            base.Category = AbilityCategory.Combat;
            base.Conditions.Add(new ConditionAndList(
                new DoesHaveMinAuraStacksCondition(WoWSpell.FromId(SpellBook.AuraMeatCleaver), 3),
                new DoesHaveMinAuraStacksCondition(WoWSpell.FromId(SpellBook.AuraRagingBlow), 1)));
        }
    }
}