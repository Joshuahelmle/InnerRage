using InnerRage.Core.Conditions.Auras;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Fury
{
    /// <summary>
    ///     Casting Wildtrike to get rid of Bloodsurge stacks
    /// </summary>
    internal class WildStrikeWithBloodSurgeUpAbility : AbilityBase
    {
        public WildStrikeWithBloodSurgeUpAbility()
            : base(WoWSpell.FromId(SpellBook.SpellWildStrike), true, false)
        {
            Category = AbilityCategory.Combat;
            Conditions.Add(new HasBloodSurgeStacksCondition());
        }
    }
}