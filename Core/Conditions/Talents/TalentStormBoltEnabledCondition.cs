using Styx;

namespace InnerRage.Core.Conditions.Talents
{
    internal class TalentStormBoltEnabledCondition : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.KnowsSpell(SpellBook.SpellStormBolt);
        }
    }
}