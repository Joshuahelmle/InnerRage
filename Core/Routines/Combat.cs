//using Arms = InnerRage.Core.Abilities.Arms;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using InnerRage.Core.Abilities.Arms;
using InnerRage.Core.Abilities.Fury;
using InnerRage.Core.Abilities.Shared;
using InnerRage.Core.Managers;
using InnerRage.Core.Utilities;
using Styx;
using Styx.CommonBot;
using Styx.WoWInternals.WoWObjects;
using HkM = InnerRage.Core.Managers.HotKeyManager;

namespace InnerRage.Core.Routines
{
    public static class Combat
    {
        private static LocalPlayer Me
        {
            get { return StyxWoW.Me; }
        }

        private static WoWUnit MyCurrentTarget
        {
            get { return Me.CurrentTarget; }
        }

        //  private static SettingsManager Settings { get { return SettingsManager.Instance; } }
        private static AbilityManager Abilities
        {
            get { return AbilityManager.Instance; }
        }

        private static UnitManager Units
        {
            get { return UnitManager.Instance; }
        }

        public static async Task<bool> Rotation()
        {
            if(Main.Debug) Log.Diagnostics("In CombatRotationCall()");
            if (Me.IsCasting || Me.IsChanneling || Me.IsFlying || Me.OnTaxi) return false;

            if (BotManager.Current.IsRoutineBased() && Me.Mounted) return false;

            if (BotManager.Current.IsRoutineBased() && !Me.Combat) return false;


            // Clear loss of control if we can //
            //     if (await ItemManager.ClearLossOfControlWithTrinkets()) return true;

            // Don't go any further if we have total loss of control //
            //    if (Me.HasTotalLossOfControl()) return false;


            if (Me.Specialization == WoWSpec.WarriorFury)
            {
                //Log.AppendLine("Surrounding Enemies: " + UnitManager.Instance.LastKnownSurroundingEnemies.Count, Colors.DarkRed);
                switch (UnitManager.Instance.LastKnownSurroundingEnemies.Count)
                {
                    case 1:
                        return await FuryCombatRotation();
                    case 2:
                        return await FuryCombatRotationTwoTargets();
                    case 3:
                        return await FuryCombatRotationThreeTargets();
                    default:
                        return await FuryCombatRotationAoE();
                }
            }
            if (Me.Specialization == WoWSpec.WarriorArms)
            {
                if(UnitManager.Instance.LastKnownSurroundingEnemies.Count > 1)
                    return await ArmsAoeRotation();
                return await ArmsCombatRotation();
            }
           return false;
        }

        #region Fury

        private static async Task<bool> FuryCombatRotation()
        {
            if (await InterruptManager.CheckMyTarget()) return true;
            if (await Abilities.Cast<WildStrikeRageDumpAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<BloodThirstToEnrageOrRagingBlowStacksAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<RavagerAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<SiegeBreakerAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<ExecuteWithSuddenDeathAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<StormBoltAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<WildStrikeWithBloodSurgeUpAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<ExecuteAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<DragonRoarAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<RagingBlowAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<AwaitBloodThirstCooldownAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<WildStrikeWithoutBloodSurgeAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<BladeStormAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<ShockWaveAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<ImpendingVictoryAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<FillerBloodThirstAbility>(MyCurrentTarget)) return true;
            return false;
        }

        private static async Task<bool> FuryCombatRotationAoE()
        {
            if (HkM.NoAoe)
                await FuryCombatRotation();

            if (await InterruptManager.CheckMyTarget()) return true;
            if (await Abilities.Cast<RavagerAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<RagingBlowWithMeatCleaverAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<BloodThirstToEnrageOrRagingBlowStacksAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<RagingBlowWithMeatCleaverToNotCapAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<BladeStormAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<WhirlWindAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<SiegeBreakerAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<ExecuteWithSuddenDeathAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<DragonRoarAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<FillerBloodThirstAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<WildStrikeWithBloodSurgeUpAbility>(MyCurrentTarget)) return true;
            return false;
        }

        private static async Task<bool> FuryCombatRotationThreeTargets()
        {
            if (HkM.NoAoe)
                await FuryCombatRotation();

            if (await InterruptManager.CheckMyTarget()) return true;
            if (await Abilities.Cast<RavagerAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<BladeStormAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<BloodThirstToEnrageOrRagingBlowStacksAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<RagingBlowWithMeatCleaverToNotCapAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<SiegeBreakerAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<ExecuteAbility>(MyCurrentTarget)) return true;
            if (
                await
                    Abilities.Cast<ExecuteAbility>(
                        UnitManager.Instance.LastKnownSurroundingEnemies.FirstOrDefault())) return true;
            if (await Abilities.Cast<DragonRoarAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<WhirlWindAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<FillerBloodThirstAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<WildStrikeWithBloodSurgeUpAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<RagingBlowAbility>(MyCurrentTarget)) return true;


            return false;
        }

        private static async Task<bool> FuryCombatRotationTwoTargets()
        {
            if (HkM.NoAoe)
                await FuryCombatRotation();

            if (await InterruptManager.CheckMyTarget()) return true;
            if (await Abilities.Cast<RavagerAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<DragonRoarAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<BladeStormAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<BloodThirstToEnrageOrRagingBlowStacksAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<SiegeBreakerAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<ExecuteWithSuddenDeathAbility>(MyCurrentTarget))
                return true; //DPS Loss regarding simcraft
            if (await Abilities.Cast<ExecuteAbility>(MyCurrentTarget)) return true;
           /* if (
                await
                    Abilities.Cast<ExecuteAbility>(
                        UnitManager.Instance.LastKnownSurroundingEnemies.FirstOrDefault())) return true; */
            if (await Abilities.Cast<RagingBlowAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<WhirlWindToGetMeatCleaverStacksAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<WildStrikeWithBloodSurgeUpAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<FillerBloodThirstAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<WhirlWindAbility>(MyCurrentTarget)) return true;
            return false;
        }

        #endregion
        #region Arms

        private static async Task<bool> ArmsCombatRotation()
        {

            if (await InterruptManager.CheckMyTarget()) return true;
            if (await Abilities.Cast<RendAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<RavagerAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<CollosusSmashAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<MortalStrikeAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<BladeStormAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<StormBoltAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<SiegeBreakerAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<DragonRoarAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<ExecuteWithSuddenDeathAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<ExecuteAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<ImpendingVictoryAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<SlamAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<ThunderclapAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<WhirlWindAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<ShockWaveAbility>(MyCurrentTarget)) return true;

            return false;

        }

        private static async Task<bool> ArmsAoeRotation()
        {
            if (await InterruptManager.CheckMyTarget()) return true;
            if (await Abilities.Cast<SweepingStrikesAbility>(Me)) return true;
            if (await Abilities.Cast<RendAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<RendAbility>(Units.LastKnownNonBleedingEnemies.FirstOrDefault())) return true;
            if (await Abilities.Cast<RavagerAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<BladeStormAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<CollosusSmashAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<ExecuteAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<MortalStrikeAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<DragonRoarAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<ThunderclapAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<WhirlwindAoeAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<SiegeBreakerAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<StormBoltAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<ShockWaveAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<ExecuteWithSuddenDeathAbility>(MyCurrentTarget)) return true;

            return false;


        } 
        #endregion
    }
}