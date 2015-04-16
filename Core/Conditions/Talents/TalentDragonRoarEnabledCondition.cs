using Styx;

namespace InnerRage.Core.Conditions.Talents
{
    internal class TalentDragonRoarEnabledCondition : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.KnowsSpell(SpellBook.SpellDragonRoar);
        }
    }
}