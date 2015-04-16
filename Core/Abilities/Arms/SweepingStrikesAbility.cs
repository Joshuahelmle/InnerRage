using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Arms
{
    internal class SweepingStrikesAbility : AbilityBase
    {
        public SweepingStrikesAbility()
            : base(WoWSpell.FromId(SpellBook.SpellSweepingStrikes), false, true)
        {
            Category = AbilityCategory.Buff;
        }
    }
}