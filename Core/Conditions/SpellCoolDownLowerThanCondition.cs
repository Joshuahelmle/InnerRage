using System;
using Styx.WoWInternals;

namespace InnerRage.Core.Conditions
{
    internal class SpellCoolDownLowerThanCondition : ICondition
    {
        private readonly TimeSpan _maxCooldown;
        private readonly WoWSpell _spell;

        /// <summary>
        ///     checks if a given Spell's cooldown is lower than the given TimeSpan
        /// </summary>
        /// <param name="spell"></param>
        /// <param name="maxCooldown"></param>
        public SpellCoolDownLowerThanCondition(WoWSpell spell, TimeSpan maxCooldown)
        {
            _spell = spell;
            _maxCooldown = maxCooldown;
        }

        public bool Satisfied()
        {
            return !CastManager.SpellIsOnCooldown(_spell.Id) || _spell.CooldownTimeLeft < _maxCooldown;
        }
    }
}