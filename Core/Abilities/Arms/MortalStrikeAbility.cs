using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Arms
{
    internal class MortalStrikeAbility : AbilityBase
    {
        public MortalStrikeAbility()
            : base(WoWSpell.FromId(SpellBook.SpellMortalStrike), true, true)
        {
            Category = AbilityCategory.Combat;
        }
    }
}