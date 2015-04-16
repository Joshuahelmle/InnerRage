namespace InnerRage.Core.Conditions.Talents
{
    internal class TalentUnquenchableThirstNotEnabledCondition : ICondition
    {
        public bool Satisfied()
        {
            return !new TalentUnquenchableThirstCondition().Satisfied();
        }
    }
}