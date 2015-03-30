using System;

namespace InnerRage.Core.Conditions.Talents
{
    class TalentUnquenchableThirstNotEnabledCondition : ICondition
    {
        public bool Satisfied()
        {
            return ! new TalentUnquenchableThirstCondition().Satisfied();
        }
    }
}
