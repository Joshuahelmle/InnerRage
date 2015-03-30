using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Styx.WoWInternals;

namespace InnerRage.Core.Conditions
{
    class SpellCoolDownLowerThanCondition : ICondition
    {
        private TimeSpan _maxCooldown;
        private WoWSpell _spell;

        /// <summary>
        /// checks if a given Spell's cooldown is lower than the given TimeSpan
        /// </summary>
        /// <param name="spell"></param>
        /// <param name="maxCooldown"></param>
        public SpellCoolDownLowerThanCondition(WoWSpell spell, TimeSpan maxCooldown)
        {
            this._spell = spell;
            this._maxCooldown = maxCooldown;
        }
        public bool Satisfied()
        {
            return !CastManager.SpellIsOnCooldown(_spell.Id) || _spell.CooldownTimeLeft < _maxCooldown;
        }
    }
}
