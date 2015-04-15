using InnerRage.Core.Conditions.Talents;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared
{
    class SiegeBreakerAbility : AbilityBase
    {
        public SiegeBreakerAbility() 
        : base(WoWSpell.FromId(SpellBook.SpellSiegeBreaker), true, true)
        {
            base.Category = AbilityCategory.Combat;
            base.Conditions.Add(new TalentSiegebreakerEnabled());
        }
    }
}
