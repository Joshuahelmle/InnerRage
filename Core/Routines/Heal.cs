using System.Threading.Tasks;
using InnerRage.Core.Abilities.Shared;
using InnerRage.Core.Managers;
using Styx;
using Styx.WoWInternals.WoWObjects;

namespace InnerRage.Core.Routines
{
    public static class Heal
    {
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

            if (!StyxWoW.IsInGame || !StyxWoW.IsInWorld)
                return false;

            if (Me.IsDead || Me.IsGhost || Me.IsCasting || Me.IsChanneling || Me.IsFlying || Me.OnTaxi || Me.Mounted)
                return false;

            // if (Me.HasTotalLossOfControl())
            //     return false;

            return await HealRotation();
        }

        private static async Task<bool> HealRotation()
        {
            //   if (await ItemManager.UseHealthstone()) return true;
            //  if (await ItemManager.UseEligibleItems(MyState.CombatHealing)) return true;
            if (await Abilities.Cast<RallyingCryAbility>(Me)) return false;
            if (await Abilities.Cast<DieByTheSwordAbility>(Me)) return false;
            if (await Abilities.Cast<EnragedRegenerationAbility>(Me)) return false;
            if (await Abilities.Cast<ImpendingVictoryAbility>(Me)) return true;
            if (await Abilities.Cast<VictoryRushAbility>(MyCurrentTarget)) return false;

            return false;
        }
    }
}