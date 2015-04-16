using Styx;

namespace InnerRage.Core.Conditions.Talents
{
    internal class TalentAvatarEnabledCondition : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.KnowsSpell(SpellBook.SpellAvatar);
        }
    }
}