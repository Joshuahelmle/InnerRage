using System.Diagnostics;
using System.Threading.Tasks;
using InnerRage.Core.Abilities.Shared;
using InnerRage.Core.Managers;
using Styx;
using Styx.WoWInternals.WoWObjects;

namespace InnerRage.Core.Routines
{
    public static class PreCombat
    {
        /// <summary>
        ///     Buff after a 5 second pulse timer so we don't appear like an automated program that zones in and immediately buffs.
        /// </summary>
        public const int BuffTimerIntervalMs = 5000;

        private static readonly Stopwatch _buffTimer = new Stopwatch();

        private static LocalPlayer Me
        {
            get { return StyxWoW.Me; }
        }

        private static WoWUnit MyCurrentTarget
        {
            get { return Me.CurrentTarget; }
        }

        private static AbilityManager Abilities
        {
            get { return AbilityManager.Instance; }
        }

        public static async Task<bool> Rotation()
        {
            if (Main.DeathTimer.IsRunning) Main.DeathTimer.Reset();

            if (!_buffTimer.IsRunning) _buffTimer.Start();

            // Checking if auras are greater than 0 helps with the bot to stop rebuffing immediately after zoning in
            // because the bot has a very small window after loading the character when it's loaded but does not know about
            // the character auras yet (aura count is 0). // Even if we don't have any visible buffs up, the character likely has over 10 "invisible" auras
            if ((_buffTimer.ElapsedMilliseconds >= BuffTimerIntervalMs) && Me.Auras.Count > 0)
            {
                _buffTimer.Restart();

                if (Me.IsDead || Me.IsGhost || Me.IsCasting || Me.IsChanneling || Me.IsFlying || Me.OnTaxi || Me.Mounted)
                    return false;


                if (Me.Specialization == WoWSpec.WarriorArms || Me.Specialization == WoWSpec.WarriorFury)
                    return await DpsPreCombatRotation();
                return await DefensivePreCombatRotation();
            }

            return true;
        }

        private static async Task<bool> DpsPreCombatRotation()
        {
            // if (await ItemManager.UseEligibleItems(MyState.NotInCombat)) return true;
            if (await Abilities.Cast<BattleShoutAbility>(Me)) return true;
            if (await Abilities.Cast<CommandingShoutAbility>(Me)) return true;
            //   if (await Abilities.Cast<Shared.BattleStance>(Me)) return true;

            return true;
        }

        private static async Task<bool> DefensivePreCombatRotation()
        {
            // if (await ItemManager.UseEligibleItems(MyState.NotInCombat)) return true;
            if (await Abilities.Cast<BattleShoutAbility>(Me)) return true;
            if (await Abilities.Cast<CommandingShoutAbility>(Me)) return true;
            // if (await Abilities.Cast<Shared.GladiatorStance>(Me)) return true;

            return true;
        }
    }
}