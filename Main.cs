using CommonBehaviors.Actions;
using InnerRage.Core;
using InnerRage.Core.Managers;
using InnerRage.Core.Utilities;
using InnerRage.Interface;
using Styx;
using Styx.CommonBot;
using Styx.CommonBot.Routines;
using Styx.TreeSharp;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using R = InnerRage.Core.Routines;

namespace InnerRage
{
    /// <summary>
    /// Main entry point into the custom combat routine.
    /// </summary>
    public class Main : CombatRoutine
    {
        /// <summary>
        /// used to log debug Messages, defaults to false.
        /// </summary>
        public static bool Debug = true;
        private static Version _version = new Version(1, 0, 0, 1);

        public static Version Version { get { return _version; } }
        public static Stopwatch DeathTimer = new Stopwatch();

        private static LocalPlayer Me { get { return StyxWoW.Me; } }
        private static WoWUnit MyCurrentTarget { get { return Me.CurrentTarget; } }
        public override WoWClass Class { get { return WoWClass.Warrior; } }
        public override string Name { get { return string.Format("InnerRage (Beta) (v{0})", Version); } }
        public override bool WantButton { get { return true; } }
        public override bool NeedDeath { get { return !BotManager.Current.IsRoutineBased() && Me.IsDead && !Me.IsGhost; } }

        public WoWSpec MyCurrentSpec { get; set; }

        #region Routines

        public override Composite PreCombatBuffBehavior { get { return new ActionRunCoroutine(o => R.PreCombat.Rotation()); } }
       // public override Composite PullBehavior { get { return new ActionRunCoroutine(o => R.Pull.Rotation()); } }
        public override Composite CombatBehavior { get { return new ActionRunCoroutine(o => R.Combat.Rotation()); } }
        public override Composite HealBehavior { get { return new ActionRunCoroutine(o => R.Heal.Rotation()); } }
        public override Composite CombatBuffBehavior
        { get { return new ActionRunCoroutine(o => R.CombatBuff.Rotation()); } }
        // public override Composite RestBehavior { get { return new ActionRunCoroutine(o => R.Rest.Rotation()); } }

        #endregion

        #region Implementation

        public override void Initialize()
        {
            try
            {
                this.MyCurrentSpec = Me.Specialization;

                GlobalSettings.Instance.Init();
                SettingsManager.Init();
                AbilityManager.ReloadAbilities();

                Log.Combat("--------------------------------------------------");
                Log.Combat(Name);
                Log.Combat(string.Format("You are a Level {0} {1} {2}", Me.Level, Me.Race, Me.Class));
                Log.Combat(string.Format("Current Specialization: {0}", this.MyCurrentSpec.ToString().Replace("Warrior", string.Empty)));
                Log.Combat(string.Format("Current Profile: {0}", GlobalSettings.Instance.LastUsedProfile));
                Log.Combat(string.Format("{0} abilities loaded", AbilityManager.Instance.Abilities.Count));
                Log.Combat("--------------------------------------------------");
                HotKeyManager.RegisterHotKeys();
            }
            catch (Exception ex)
            {
                Log.Gui(string.Format("Error Initializing InnerRage Combat Routine: {0}", ex));
            }
        }


        
        public override void OnButtonPress()
        {
            var settingsForm = new Settings();

            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
               // SettingsManager.Init(GlobalSettings.GetFullPathToProfile(GlobalSettings.Instance.LastUsedProfile));
                AbilityManager.ReloadAbilities();
               // ItemManager.LoadDataSet();

                Log.Gui(string.Format("Profile saved and loaded."));
            }
        }
        public override void Pulse()
        {
            if (MyCurrentSpec != Me.Specialization)
            {
                Log.Combat(string.Format("Specialization changed from {0} to {1}", MyCurrentSpec.ToString().Replace("Warrior", string.Empty), Me.Specialization.ToString().Replace("Warrior", string.Empty)));
                this.MyCurrentSpec = Me.Specialization;
            }

            AbilityManager.Instance.Update();
            UnitManager.Instance.Update();
         //   SnapshotManager.Instance.Update();
            

            base.Pulse();
        }


        /*
        public override void Death()
        {
            if (this.NeedDeath)
            {
                if (SettingsManager.Instance.ReleaseSpiritOnDeathEnabled)
                {
                    if (!DeathTimer.IsRunning) DeathTimer.Start();
                    if (DeathTimer.ElapsedMilliseconds >= SettingsManager.Instance.ReleaseSpiritOnDeathIntervalInMs)
                    {
                        Log.GUI(string.Format("I have died. Corpse released after {0} ms", DeathTimer.ElapsedMilliseconds));

                        DeathTimer.Reset();
                        Lua.DoString("RunMacroText(\"/script RepopMe()\")");
                    }
                }
            }

            base.Death();
        }
        */
        #endregion

        public override void ShutDown() { HotKeyManager.RemoveHotkeys(); }
    }
}