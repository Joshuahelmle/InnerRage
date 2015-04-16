namespace InnerRage.Core.Conditions.Talents
{
    internal class TalentBloodBathNotEnabledCondition : ICondition
    {
        public bool Satisfied()
        {
            return !new TalentBloodBathEnabledCondition().Satisfied();
        }
    }
}