using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Protection
{
    public class RevengeAbility : AbilityBase
    {
        public RevengeAbility() 
            : base(WoWSpell.FromId(SpellBook.SpellRevenge), true, true)
        {
            Category = AbilityCategory.Combat;

        }
    }
}