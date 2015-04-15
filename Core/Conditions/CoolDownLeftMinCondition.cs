using System;
using Styx.WoWInternals;

namespace InnerRage.Core.Conditions
{
    class CoolDownLeftMinCondition : ICondition
    {
        private WoWSpell _spell;
        private TimeSpan _maxCooldown;

        public CoolDownLeftMinCondition(WoWSpell spell, TimeSpan maxCooldown)
        {
            _spell = spell;
            _maxCooldown = maxCooldown;
        }

        public bool Satisfied()
        {
            return _spell.CooldownTimeLeft > _maxCooldown;
        }
    }
}
