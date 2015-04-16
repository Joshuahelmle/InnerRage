using Styx;

namespace InnerRage.Core.Conditions.Talents
{
    internal class TalentSlamEnabled : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.KnowsSpell(SpellBook.SpellSlam);
        }
    }
}