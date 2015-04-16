/* CREDIT : Almost all of the code in this class is Work of SnowCrash , thanks for giving me insight and creative ideas buddy! */

using System.Collections.Generic;
using System.Threading.Tasks;
using InnerRage.Core.Conditions;
using Styx;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;
using SM = InnerRage.Core.Managers.SettingsManager;

namespace InnerRage.Core.Abilities
{
    /// <summary>
    ///     The base Ability class that all abilities should inherit from. This class cannot be directly instantiated.
    /// </summary>
    public abstract class AbilityBase : IAbility
    {
        private WoWSpell _woWSpell;
        // protected static SettingsManager Settings { get { return SettingsManager.Instance; } }

        protected bool MustWaitForGlobalCooldown;
        protected bool MustWaitForSpellCooldown;

        /// <summary>
        ///     <para>The default declaration defines an instant use ability that is on the GCD</para>
        ///     <para>mustWaitForGlobalCooldown = true</para>
        ///     <para>mustWaitForSpellCooldown = false</para>
        /// </summary>
        public AbilityBase(WoWSpell spell, bool mustWaitForGlobalCooldown = true, bool mustWaitForSpellCooldown = false)
        {
            Category = AbilityCategory.Normal;

            if (spell == null)
                throw new AbilityException("Spell cannot be null");

            Spell = spell;

            MustWaitForGlobalCooldown = mustWaitForGlobalCooldown;
            MustWaitForSpellCooldown = mustWaitForSpellCooldown;

            Conditions = new List<ICondition>();

            if (MustWaitForGlobalCooldown) Conditions.Add(new IsOffGlobalCooldownCondition());
            if (MustWaitForSpellCooldown) Conditions.Add(new SpellIsNotOnCooldownCondition(Spell));
            if (Category == AbilityCategory.Combat)
                Conditions.Add(new InMeeleRangeCondition());
        }

        /// <summary>
        ///     The list of conditions that must be satisfied prior to a casting attempt.
        /// </summary>
        public List<ICondition> Conditions { get; protected set; }

        protected static LocalPlayer Me
        {
            get { return StyxWoW.Me; }
        }

        protected static WoWUnit MyCurrentTarget
        {
            get { return Me.CurrentTarget; }
        }

        /// <summary>
        ///     The category of the ability. Displayed during logging.
        /// </summary>
        public AbilityCategory Category { get; set; }

        public WoWUnit Target { get; set; }

        /// <summary>
        ///     The spell that the ability directly relates to.
        /// </summary>
        public WoWSpell Spell { get; set; }

        /// <summary>
        ///     (Non-Blocking) Casts the ability's spell on the specified target. The cast will only be attempted if the conditions
        ///     list is completely satisfied first.
        /// </summary>
        /// <returns>Returns true on a successful cast.</returns>
        public virtual async Task<bool> CastOnTarget(WoWUnit target)
        {
            Target = target;
            return await CastManager.CastOnTarget(target, this, Conditions);
        }

        /// <summary>
        ///     Provides an opportunity to update the ability with any dynamic changes as necessary. This should be done during
        ///     Main.Pulse().
        /// </summary>
        public virtual void Update()
        {
            // Filler so that every implementing class does not have to update and those that need to can just override.
        }
    }
}