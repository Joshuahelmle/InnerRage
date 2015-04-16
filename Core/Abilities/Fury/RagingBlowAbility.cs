using InnerRage.Core.Conditions.Auras;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Fury
{
    internal class RagingBlowAbility : AbilityBase
    {
        public RagingBlowAbility() : base(WoWSpell.FromId(SpellBook.SpellRagingBlow), true, false)
        {
            Category = AbilityCategory.Combat;
            Conditions.Add(new HasRagingBlowProccCondition());
        }
    }
}