using Styx;
using Styx.WoWInternals;

namespace InnerRage.Core.Conditions.Auras
{
    internal class DoesHaveMinAuraStacksCondition : ICondition
    {
        private readonly WoWSpell _spell;
        private readonly int _stacks;

        public DoesHaveMinAuraStacksCondition(WoWSpell spell, int stacks)
        {
            _spell = spell;
            _stacks = stacks;
        }

        public bool Satisfied()
        {
            return StyxWoW.Me.HasAura(_spell.Id)
                ? StyxWoW.Me.GetAuraById(_spell.Id).StackCount >= _stacks
                : (_stacks <= 0);
        }
    }
}