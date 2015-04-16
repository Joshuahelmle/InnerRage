/* CREDIT : Almost all of the code in this class is Work of SnowCrash , thanks for giving me insight and creative ideas buddy! */

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using Buddy.Coroutines;
using InnerRage.Core.Abilities;
using InnerRage.Core.Abilities.Fury;
using InnerRage.Core.Conditions;
using InnerRage.Core.Utilities;
using Styx;
using Styx.CommonBot;
using Styx.CommonBot.Coroutines;
using Styx.Pathing;
using Styx.WoWInternals.WoWObjects;

namespace InnerRage.Core
{
    /// <summary>
    ///     Provides the management of spell casting.
    /// </summary>
    public static class CastManager
    {
        /// <summary>
        ///     Determine if the spell is on cooldown.
        /// </summary>
        /// <returns></returns>
        public static bool SpellIsOnCooldown(int spellId)
        {
            SpellFindResults spellFindResults;
            if (SpellManager.FindSpell(spellId, out spellFindResults))
            {
                return spellFindResults.Override != null
                    ? spellFindResults.Override.Cooldown
                    : spellFindResults.Original.Cooldown;
            }

            return false;
        }

        /// <summary>
        ///     (Non-Blocking) Casts the provided spell on the provided target requiring all conditions to be satisfied prior to
        ///     casting.
        /// </summary>
        /// <returns>Returns true if the cast is successful</returns>
        public static async Task<bool> CastOnTarget(WoWUnit target, IAbility ability, List<ICondition> conditions)
        {
            foreach (var condition in conditions)
                if (!condition.Satisfied())
                {
                    if (Main.Debug && !(condition is IsOffGlobalCooldownCondition))
                        if (Main.Debug) Log.Diagnostics("In " + ability + "call.");
                    if (Main.Debug)
                        Log.Diagnostics("Failed at condition:" + condition);

                    // if(Main.Debug) Log.Diagnostics("current Target: " + target);
                    return false;
                }

            //Check if Ability is a "wait Ability - waiting for Cooldown then casting it."
            if (ability is AwaitBloodThirstCooldownAbility)
            {
                await Coroutine.Sleep(ability.Spell.CooldownTimeLeft);
            }


            if (!SpellManager.HasSpell(ability.Spell)) return false;
            if (!SpellManager.CanCast(ability.Spell)) return false;
            if (!SpellManager.Cast(ability.Spell, target)) return false;

            var logColor = Colors.CornflowerBlue;

            switch (ability.Category)
            {
                case AbilityCategory.Heal:
                    logColor = Colors.Yellow;
                    break;
                case AbilityCategory.Defensive:
                    logColor = Colors.LightGreen;
                    break;
                case AbilityCategory.Buff:
                    logColor = Colors.Plum;
                    break;
            }

            {
                Log.AppendLine(string.Format("[{0}] Casted {1} on {2}(Rage: {3}, HP: {4:0.##}%)",
                    ability.Category,
                    ability.Spell.Name,
                    target == null ? "Nothing" : (target.IsMe ? "Me" : target.SafeName),
                    StyxWoW.Me.CurrentRage,
                    StyxWoW.Me.HealthPercent
                    ), logColor);
            }


            await CommonCoroutines.SleepForLagDuration();

            return true;
        }

        public static async Task<bool> DropCast(IAbility ability, WoWUnit target, List<ICondition> conditions)
        {
            foreach (var condition in conditions)
                if (!condition.Satisfied())
                {
                    if (Main.Debug) Log.Diagnostics("Failed at condition:" + condition);

                    return false;
                }


            if (!SpellManager.HasSpell(ability.Spell)) return false;
            if (!SpellManager.CanCast(ability.Spell)) return false;
            if (!SpellManager.Cast(ability.Spell, target)) return false;

            if (!await Coroutine.Wait(1000, () => StyxWoW.Me.CurrentPendingCursorSpell != null))
            {
                Log.Diagnostics("Cursor didn't turn into the spell!");
                return false;
            }

            var targetLocationOnGround = new WoWPoint(target.Location.X, target.Location.Y, StyxWoW.Me.Z);
            SpellManager.ClickRemoteLocation(targetLocationOnGround);

            var logColor = Colors.CornflowerBlue;

            switch (ability.Category)
            {
                case AbilityCategory.Heal:
                    logColor = Colors.Yellow;
                    break;
                case AbilityCategory.Defensive:
                    logColor = Colors.LightGreen;
                    break;
                case AbilityCategory.Buff:
                    logColor = Colors.Plum;
                    break;
            }

            {
                Log.AppendLine(string.Format("[{0}] Casted {1} on {2}(Rage: {3}, HP: {4:0.##}%) at Location Z : {5}",
                    ability.Category,
                    ability.Spell.Name,
                    target == null ? "Nothing" : (target.IsMe ? "Me" : target.SafeName),
                    StyxWoW.Me.CurrentRage,
                    StyxWoW.Me.HealthPercent,
                    targetLocationOnGround
                    ), logColor);
            }

            await CommonCoroutines.SleepForLagDuration();
            return true;
        }

        public static float HeightOffTheGround(WoWUnit unit)
        {
            var unitLoc = new WoWPoint(unit.Location.X, unit.Location.Y, unit.Location.Z);
            var listMeshZ = Navigator.FindHeights(unitLoc.X, unitLoc.Y).Where(h => h <= unitLoc.Z);
            if (listMeshZ.Any())
                return unitLoc.Z - listMeshZ.Max();

            return unit.Z;
        }
    }
}