using System.Diagnostics;
using System.Threading.Tasks;
using InnerRage.Core.Abilities.Shared;
using InnerRage.Core.Abilities.Shared.Racials;
using InnerRage.Core.Conditions.Talents;
using InnerRage.Core.Managers;
using InnerRage.Core.Utilities;
using Styx;
using Styx.CommonBot;
using Styx.CommonBot.Coroutines;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

//using Arms = InnerRage.Core.Abilities.Arms;

namespace InnerRage.Core.Routines
{
    public static class CombatBuff
    {
        private static readonly Stopwatch _locDelay = new Stopwatch();

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
            if (Main.Debug) Log.Diagnostics("InCombatBuffRotationCall()");
            if (Me.IsCasting || Me.IsChanneling || Me.IsFlying || Me.OnTaxi) return false;

            if (BotManager.Current.IsRoutineBased() && Me.Mounted) return false;

            if (BotManager.Current.IsRoutineBased() && !Me.Combat) return false;

            if (Me.HasLossOfControl() || Me.HasTotalLossOfControl())
            {
                if (await Abilities.Cast<BerserkerBreakCCAbility>(Me)) return true;
                if (await UseRacialToClearLoC()) return true;
                if (await UseTrinketsToClearLoC()) return true;
            }

            #region [IR] - Trinkets

            if (await UseTrinketsToBurst()) return true;

            #endregion

            #region [IR] - Racials

            if (await Abilities.Cast<RacialOrcBloodFuryAbility>(Me)) return true;
            if (await Abilities.Cast<RacialsTrollBerserkingAbility>(Me)) return true;
            if (await Abilities.Cast<RacialsBloodElfAbility>(Me)) return true;

            #endregion

            if (Me.Specialization == WoWSpec.WarriorFury) return await FuryCombatBuffRotation();
            if (Me.Specialization == WoWSpec.WarriorArms) return await ArmsCombatBuffRotation();
            if (Me.Specialization == WoWSpec.WarriorProtection) return await ProtCombatBuffRotation();
        }

        private static async Task<bool> FuryCombatBuffRotation()
        {
            if (Main.Debug) Log.Diagnostics("In FuryCombatBuffRotation() call");
            if (await Abilities.Cast<BerserkerRageAbility>(Me)) return false;
            if (await Abilities.Cast<BloodBathAbility>(Me)) return false;
            if (await Abilities.Cast<RecklessnessAbility>(Me)) return false;
            if (await Abilities.Cast<AvatarAbility>(Me)) return true;
            return false;
        }

        private static async Task<bool> ArmsCombatBuffRotation()
        {
            if (Main.Debug) Log.Diagnostics("In ArmsCombatBuffRotation() call");
            if (await Abilities.Cast<BloodBathAbility>(Me)) return false;
            if (await Abilities.Cast<RecklessnessAbility>(Me)) return false;
            if (await Abilities.Cast<AvatarAbility>(Me)) return true;
            return false;
        }

        private static async Task<bool> ProtCombatBuffRotation()
        {
            if(Main.Debug) Log.Diagnostics("In ProtCombatBuffRotation() call");
            if (await Abilities.Cast<BloodBathAbility>(Me)) return false;
            if (await Abilities.Cast<RecklessnessAbility>(Me)) return false;
            if (await Abilities.Cast<AvatarAbility>(Me)) return true;
            return false;
        }

        private static async Task<bool> UseRacialToClearLoC()
        {
            if (Main.Debug) Log.Diagnostics("In UseRacialToClearLoc() call");
            if (!_locDelay.IsRunning)
            {
                _locDelay.Start();
                return false;
            }
            if (_locDelay.ElapsedMilliseconds > SettingsManager.Instance.LoCDelay)
            {
                if (WoWSpell.FromId(SpellBook.RacialHumanEveryManForHimself).CooldownTimeLeft.TotalMilliseconds == 0)
                {
                    if (await Abilities.Cast<RacialHumanAbility>(Me))
                    {
                        _locDelay.Reset();
                        return true;
                    }
                }
                else Log.Diagnostics("Human Racial is on Cooldown.");
                return true;
            }
            return true;
        }

        /// <summary>
        ///     Checks whether we have trinkets equipped, and are allowed to use them, if so we are trying to Clear our Loss of
        ///     control with them.
        /// </summary>
        /// <returns></returns>
        private static async Task<bool> UseTrinketsToClearLoC()
        {
            if (Main.Debug) Log.Diagnostics("in UseTrinketsToClearLoC call");

            if (Me.Inventory.Equipped.Trinket1 != null)
            {
                //Use Trinkets if Settings allow it.
                if (SettingsManager.Instance.UseTrinket1)
                {
                    //Clear Loss of Control
                    if (SettingsManager.Instance.UseTrinket1OnLoC)
                    {
                        if (!_locDelay.IsRunning)
                        {
                            _locDelay.Start();
                            return true;
                        }
                        if (_locDelay.ElapsedMilliseconds > SettingsManager.Instance.LoCDelay)
                        {
                            if (Me.Inventory.Equipped.Trinket1.CooldownTimeLeft.TotalMilliseconds == 0)
                            {
                                Me.Inventory.Equipped.Trinket1.Use();
                                await CommonCoroutines.SleepForLagDuration();
                                _locDelay.Reset();
                                return true;
                            }
                            {
                                Log.Diagnostics("Trinket 1 on Cooldown.");
                            }
                        }
                    }
                }
            }

            //Trinket 2

            if (Me.Inventory.Equipped.Trinket2 != null)
            {
                //Use Trinkets if Settings allow it.
                if (SettingsManager.Instance.UseTrinket2)
                {
                    //Clear Loss of Control
                    if (SettingsManager.Instance.UseTrinket2OnLoC)
                    {
                        if (!_locDelay.IsRunning)
                        {
                            _locDelay.Start();
                            return true;
                        }
                        if (_locDelay.ElapsedMilliseconds > SettingsManager.Instance.LoCDelay)
                        {
                            if (Me.Inventory.Equipped.Trinket2.CooldownTimeLeft.TotalMilliseconds == 0)
                            {
                                Me.Inventory.Equipped.Trinket2.Use();
                                await CommonCoroutines.SleepForLagDuration();
                                _locDelay.Reset();
                                return true;
                            }
                            {
                                Log.Diagnostics("Trinket 2 on Cooldown.");
                                _locDelay.Reset();
                            }
                        }
                    }
                }
            }
            return false;
        }

        private static async Task<bool> UseTrinketsToBurst()
        {
            // use Trinket1 to burst
            if (SettingsManager.Instance.UseTrinket1ToBurst &&
                new BloodBathUpOrNotEnabledCondition().Satisfied() &&
                Me.Inventory.Equipped.Trinket1.CooldownTimeLeft.Milliseconds != 0)
            {
                Me.Inventory.Equipped.Trinket1.Use();
                await CommonCoroutines.SleepForLagDuration();
            }

            if (SettingsManager.Instance.UseTrinket2ToBurst &&
                new BloodBathUpOrNotEnabledCondition().Satisfied() &&
                Me.Inventory.Equipped.Trinket2.CooldownTimeLeft.Milliseconds != 0)
            {
                Me.Inventory.Equipped.Trinket2.Use();
                await CommonCoroutines.SleepForLagDuration();
            }
            return false;
        }
    }
}