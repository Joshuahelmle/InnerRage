using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Protection
{
    public class DemoralizingShoutAbility :AbilityBase
    {
        public DemoralizingShoutAbility() 
            : base(WoWSpell.FromId(SpellBook.SpellDemoralizingShout), false, true)
        {
            Category = AbilityCategory.Combat;

        }
    }
}