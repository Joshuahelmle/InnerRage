using InnerRage.Core.Abilities.Fury;
using InnerRage.Core.Managers;

namespace InnerRage.Core.Conditions
{
    internal class LastSpellCastBloodThirstCondition : ICondition
    {
        public bool Satisfied()
        {
            return AbilityManager.Instance.LastCastAbility is BloodThirstToEnrageOrRagingBlowStacksAbility ||
                   AbilityManager.Instance.LastCastAbility is AwaitBloodThirstCooldownAbility ||
                   AbilityManager.Instance.LastCastAbility is FillerBloodThirstAbility;
        }
    }
}