using Styx;

namespace InnerRage.Core.Conditions.Talents
{
    internal class TalentShockWaveEnabledCondition : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.KnowsSpell(SpellBook.SpellShockwave);
        }
    }
}