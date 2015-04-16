using Styx;

namespace InnerRage.Core.Conditions.Talents
{
    public class TalentUnyieldingStrikesEnabledCondition : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.KnowsSpell(169685);
        }
    }
}