namespace InnerRage.Core.Conditions.Talents
{
    class BloodBathUpOrNotEnabledCondition : ICondition
    {
        public bool Satisfied()
        {
            return new TalentBloodBathNotEnabledCondition().Satisfied() || new BloodBathIsUpCondition().Satisfied();
        }
    }
}
