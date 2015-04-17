//using Arms = InnerRage.Core.Abilities.Arms;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InnerRage.Core.Abilities;
using InnerRage.Core.Abilities.Arms;
using InnerRage.Core.Abilities.Fury;
using InnerRage.Core.Abilities.Protection;
using InnerRage.Core.Abilities.Shared;
using InnerRage.Core.Conditions;
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

        /// <summary>
        /// A List of Abilitys queued to execute before the Normal Rotation is Executed. This is to give User inputs like Hotkeys a higher prio.
        /// </summary>
        public static List<AbilityBase> AbilityQueue = new List<AbilityBase>();
        public static List<AbilityBase> AbilityQueueDone = new List<AbilityBase>(); 

        public static async Task<bool> Rotation()
        {
            if (Main.Debug) Log.Diagnostics("In CombatRotationCall()");
            if (Me.IsCasting || Me.IsChanneling || Me.IsFlying || Me.OnTaxi) return false;

            if (BotManager.Current.IsRoutineBased() && Me.Mounted) return false;

            if (BotManager.Current.IsRoutineBased() && !Me.Combat) return false;


            // Clear loss of control if we can //
            //     if (await ItemManager.ClearLossOfControlWithTrinkets()) return true;

            // Don't go any further if we have total loss of control //
            //    if (Me.HasTotalLossOfControl()) return false;

            if (Main.Debug)
            {
                Log.Diagnostics(String.Format("AbilityQueueDone is Empty: {0}",
                    !AbilityQueueDone.Any()));
                Log.Diagnostics(String.Format("AbilityQueue is Empty: {0}",
                    !AbilityQueue.Any()));
            }

            foreach (var cast in AbilityQueueDone)
            {
                AbilityQueue.Remove(cast);
            }
            AbilityQueueDone.Clear();

            //Check for user pressed Hotkeys Abilitys.
            if (AbilityQueue.Any())
            {
                foreach (var cast in AbilityQueue)
                {
                    if (cast.MustWaitForSpellCooldown && new SpellIsOnCooldownCondition(cast.Spell).Satisfied())
                    {
                        AbilityQueueDone.Add(cast);
                        return false;
                    }
                    if (cast.Category == AbilityCategory.Buff)
                    {
                        if (await CastManager.CastOnTarget(Me, cast, cast.Conditions))
                        {
                            AbilityQueueDone.Add(cast);
                            return cast.MustWaitForGlobalCooldown; //casted, is spell on GCD? if so start rotation again, if not walk tree further
                        }
                        return false; //cast was not succesful
                    }
                    else
                    {
                        if (await CastManager.CastOnTarget(MyCurrentTarget, cast, cast.Conditions))
                        {
                            AbilityQueueDone.Add(cast);
                            return cast.MustWaitForGlobalCooldown;
                        }
                        return false; //cast was not successful
                    }  
                }
                
            }

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
                if (UnitManager.Instance.LastKnownSurroundingEnemies.Count > 1)
                    return await ArmsAoeRotation();
                return await ArmsCombatRotation();
            }

            if (Me.Specialization == WoWSpec.WarriorProtection)
            {
                if (UnitManager.Instance.LastKnownSurroundingEnemies.Count > 1)
                    return await ProtectionAoeRotation();
                return await ProtectionCombatRotation(); 
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
            if (HkM.NoAoe)
                await ArmsCombatRotation();
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

        #region Protection

        private static async Task<bool> ProtectionCombatRotation()
        {
            if(Main.Debug) Log.Diagnostics("In ProtectionCombatRotation Call()");
            if (await InterruptManager.CheckMyTarget()) return true;
            if (await Abilities.Cast<ShieldBlock>(Me)) return false; // not on global
            if (await Abilities.Cast<ShieldBarrierAbility>(Me)) return false; //not on global
            if (await Abilities.Cast<DemoralizingShoutAbility>(MyCurrentTarget)) return false; //not on global
            if (await Abilities.Cast<HeroicStrikeAbility>(MyCurrentTarget)) return false; //is not on the GCD
            if (await Abilities.Cast<ShieldSlamWithBuffUpAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<RevengeAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<ShieldSlamAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<RavagerAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<StormBoltAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<DragonRoarAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<ExecuteWithSuddenDeathAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<DevastateAbility>(MyCurrentTarget)) return true;
            return false;
        }

        private static async Task<bool> ProtectionAoeRotation()
        {
            if (HkM.NoAoe) await ProtectionCombatRotation();
            if (Main.Debug) Log.Diagnostics("In ProtectionAoeRotation Call()");
            if (await InterruptManager.CheckMyTarget()) return true;
            if (await Abilities.Cast<ShieldBlock>(Me)) return false; // not on global
            if (await Abilities.Cast<ShieldBarrierAbility>(Me)) return false; //not on global
            if (await Abilities.Cast<DemoralizingShoutAbility>(MyCurrentTarget)) return false; //not on global
            if (await Abilities.Cast<HeroicStrikeAbility>(MyCurrentTarget)) return false; //not on GCD
            if (await Abilities.Cast<ShieldSlamWithBlockUpAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<RavagerAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<DragonRoarAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<ShockWaveAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<RevengeAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<ProtThunderClapAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<BladeStormAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<ShieldSlamAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<StormBoltAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<ExecuteWithSuddenDeathAbility>(MyCurrentTarget)) return true;
            if (await Abilities.Cast<DevastateAbility>(MyCurrentTarget)) return true;

            return false;
        } 
        #endregion

    }
}