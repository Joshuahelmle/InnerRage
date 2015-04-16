namespace InnerRage.Core.Conditions.Talents
{
    internal class BloodBathUpOrNotEnabledCondition : ICondition
    {
        public bool Satisfied()
        {
            return new TalentBloodBathNotEnabledCondition().Satisfied() || new BloodBathIsUpCondition().Satisfied();
        }
    }
}