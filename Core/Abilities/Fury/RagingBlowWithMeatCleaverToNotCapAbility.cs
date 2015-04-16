using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Auras;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Fury
{
    /// <summary>
    ///     Cast RagingBlow to get Rid of Meatcleaver stacks
    /// </summary>
    internal class RagingBlowWithMeatCleaverToNotCapAbility : AbilityBase
    {
        public RagingBlowWithMeatCleaverToNotCapAbility()
            : base(WoWSpell.FromId(SpellBook.SpellRagingBlow), true, false)
        {
            Category = AbilityCategory.Combat;
            Conditions.Add(new ConditionAndList(
                new DoesHaveMinAuraStacksCondition(WoWSpell.FromId(SpellBook.AuraMeatCleaver), 3),
                new DoesHaveMinAuraStacksCondition(WoWSpell.FromId(SpellBook.AuraRagingBlow), 1)));
        }
    }
}