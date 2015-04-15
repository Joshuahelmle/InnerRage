using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Auras;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Fury
{
    class RagingBlowAbility : AbilityBase
    {
        public RagingBlowAbility() : base(WoWSpell.FromId(SpellBook.SpellRagingBlow), true, false)
        {
            base.Category = AbilityCategory.Combat;
            base.Conditions.Add(new HasRagingBlowProccCondition());
        }
    }
}
