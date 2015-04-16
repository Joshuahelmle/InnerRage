using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Fury
{
    internal class FillerBloodThirstAbility : AbilityBase
    {
        public FillerBloodThirstAbility()
            : base(WoWSpell.FromId(SpellBook.SpellBloodThirst), true, true)
        {
            Category = AbilityCategory.Combat;
        }
    }
}