using System;
using InnerRage.Core.Utilities;
using Styx.WoWInternals;

namespace InnerRage.Core.Conditions
{
    /// <summary>
    /// determines if the SpellCooldown is Lower than given MaxTimeLeft.
    /// </summary>
    class CooldownTimeLeftMaxCondition : ICondition
    {
        /// <summary>
        /// The Spell id used to determine the time left to satisfy the condition.
        /// </summary>
        WoWSpell Spell { get; set; }

        /// <summary>
        /// The maximum amount of time left to satisfy the condition.
        /// </summary>
        public TimeSpan MaxTimeLeft { get; set; }

        public CooldownTimeLeftMaxCondition(WoWSpell spell, TimeSpan maxTimeLeft)
        {
            this.Spell = spell;
            this.MaxTimeLeft = maxTimeLeft;
        }
        public bool Satisfied()
        {
            if (Main.Debug)Log.Diagnostics("CooldownTimeleft of: "+Spell+ " is :"+Spell.CooldownTimeLeft);
            return Spell.CooldownTimeLeft < MaxTimeLeft;
        }
    }
}
