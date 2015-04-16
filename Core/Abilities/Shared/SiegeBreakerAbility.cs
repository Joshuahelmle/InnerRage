using InnerRage.Core.Conditions.Talents;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared
{
    internal class SiegeBreakerAbility : AbilityBase
    {
        public SiegeBreakerAbility()
            : base(WoWSpell.FromId(SpellBook.SpellSiegeBreaker), true, true)
        {
            Category = AbilityCategory.Combat;
            Conditions.Add(new TalentSiegebreakerEnabled());
        }
    }
}