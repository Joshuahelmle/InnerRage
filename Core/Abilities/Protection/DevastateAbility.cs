using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Protection
{
    public class DevastateAbility : AbilityBase
    {
        public DevastateAbility() 
            : base(WoWSpell.FromId(SpellBook.SpellDevastate), true, false)
        {
            Category = AbilityCategory.Combat;
        }
    }
}