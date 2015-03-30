namespace InnerRage.Core.Conditions.Talents
{
    class TalentBloodBathNotEnabledCondition : ICondition
    {
        public bool Satisfied()
        {
            return !new TalentBloodBathEnabledCondition().Satisfied();
        }
    }
}
