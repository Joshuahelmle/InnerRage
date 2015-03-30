using Styx;

namespace InnerRage.Core.Conditions.Talents
{
    class TalentDragonRoarEnabledCondition : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.KnowsSpell(SpellBook.SpellDragonRoar);
        }
    }
}
