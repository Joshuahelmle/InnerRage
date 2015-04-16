using System;
using Styx.WoWInternals;

namespace InnerRage.Core.Conditions
{
    internal class CoolDownLeftMinCondition : ICondition
    {
        private readonly TimeSpan _maxCooldown;
        private readonly WoWSpell _spell;

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