using InnerRage.Core.Conditions;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Fury
{
    class FillerBloodThirstAbility :AbilityBase
    {
        public FillerBloodThirstAbility() 
            : base(WoWSpell.FromId(SpellBook.SpellBloodThirst),true,true)
        {
            base.Category = AbilityCategory.Combat;
        }
    }
}
