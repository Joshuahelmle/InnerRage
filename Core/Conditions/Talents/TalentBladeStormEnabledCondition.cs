using Styx;

namespace InnerRage.Core.Conditions.Talents
{
    internal class TalentBladeStormEnabledCondition : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.KnowsSpell(SpellBook.SpellBladestorm);
        }
    }
}