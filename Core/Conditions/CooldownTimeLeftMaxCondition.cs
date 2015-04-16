using System;
using InnerRage.Core.Utilities;
using Styx.WoWInternals;

namespace InnerRage.Core.Conditions
{
    /// <summary>
    ///     determines if the SpellCooldown is Lower than given MaxTimeLeft.
    /// </summary>
    internal class CooldownTimeLeftMaxCondition : ICondition
    {
        public CooldownTimeLeftMaxCondition(WoWSpell spell, TimeSpan maxTimeLeft)
        {
            Spell = spell;
            MaxTimeLeft = maxTimeLeft;
        }

        /// <summary>
        ///     The Spell id used to determine the time left to satisfy the condition.
        /// </summary>
        private WoWSpell Spell { get; set; }

        /// <summary>
        ///     The maximum amount of time left to satisfy the condition.
        /// </summary>
        public TimeSpan MaxTimeLeft { get; set; }

        public bool Satisfied()
        {
            if (Main.Debug) Log.Diagnostics("CooldownTimeleft of: " + Spell + " is :" + Spell.CooldownTimeLeft);
            return Spell.CooldownTimeLeft < MaxTimeLeft;
        }
    }
}