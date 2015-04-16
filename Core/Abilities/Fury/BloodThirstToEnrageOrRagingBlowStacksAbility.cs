using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Auras;
using InnerRage.Core.Conditions.Talents;
using InnerRage.Core.Managers;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Fury
{
    /// <summary>
    ///     Cast Bloodthirst if we dont have Unquenchable thirst and would not cap rage with the next cast.
    ///     OR Enrage is not up -> get enraged with cast
    ///     OR Raging Blow Stacks are not at cap -> get a new stack with cast
    /// </summary>
    internal class BloodThirstToEnrageOrRagingBlowStacksAbility : AbilityBase
    {
        public BloodThirstToEnrageOrRagingBlowStacksAbility()
            : base(WoWSpell.FromId(SpellBook.SpellBloodThirst), true, true)
        {
            Category = AbilityCategory.Combat;
            Conditions.Add(new ConditionOrList(
                new ConditionAndList(new TalentUnquenchableThirstCondition(), new BloodThirstWillNotCapRageCondition()),
                new DoesNotHaveEnrageUpCondition(),
                new DoesNotHaveFullRagingBlowStacksCondition()));
            Conditions.Add(new ConditionSwitchTester(
                new BooleanCondition(UnitManager.Instance.LastKnownSurroundingEnemies.Count > 1),
                new MaxRageCondition(50)));
        }
    }
}