using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Media;
using InnerRage.Core.Utilities;
using Styx;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace InnerRage.Core.Managers
{
    /// <summary>
    /// Provides the managment of surrounding units and methods.
    /// </summary>
    public sealed class UnitManager
    {
        #region Singleton Stuff

        private static UnitManager _singletonInstance;

        private static LocalPlayer Me
        {
            get { return StyxWoW.Me; }
        }

        private static AbilityManager Abilities
        {
            get { return AbilityManager.Instance; }
        }

        //private static SettingsManager Settings { get { return SettingsManager.Instance; } }

        public static UnitManager Instance
        {
            get { return _singletonInstance ?? (_singletonInstance = new UnitManager()); }
        }

        #endregion

        /// <summary>
        /// Timer used to monitor the surrounding enemies.
        /// </summary>
        private Stopwatch _enemyScanner = new Stopwatch();

        /// <summary>
        /// The number of milliseconds to elapse before considering the enemy timer "tick"
        /// </summary>
        private int _enemyScannerIntervalMs = 500;

        /// <summary>
        /// Timer used to monitor the group information.
        /// </summary>
        private Stopwatch _groupScanner = new Stopwatch();

        /// <summary>
        /// The number of milliseconds to elapse before considering the group timer "tick"
        /// </summary>
        private int _groupScannerIntervalMs = 5000;

        /// <summary>
        /// Used to calculate the currentTargets Time to die, highly experimental!
        /// </summary>
        private double _currentTargetHealth = 100;

        public TimeSpan TargetTimeToDie;
        /// <summary>
        /// Gets the list of the last known surrounding enemies (Cached - ensure to check for null and valid units). 
        /// </summary>
        public List<WoWUnit> LastKnownSurroundingEnemies { get; private set; }

        /// <summary>
        /// Gets the list of the last known allies that have a given property
        /// </summary>
        public List<WoWUnit> LastKnownBleedingEnemies { get; private set; }
        public List<WoWUnit> LastKnownEnemiesInExecuteRange { get; private set; }
        public List<WoWUnit> LastKnownNonBleedingEnemies { get; private set; } 

        /// <summary>
        /// Gets the number of the last known group size.
        /// </summary>
        public int LastKnownGroupMemberSize { get; set; }

        public UnitManager()
        {
            this.LastKnownSurroundingEnemies = new List<WoWUnit>();
            this.LastKnownBleedingEnemies = new List<WoWUnit>();
            this.LastKnownEnemiesInExecuteRange = new List<WoWUnit>();
            this.LastKnownNonBleedingEnemies = new List<WoWUnit>();

            _enemyScanner.Start();
            _groupScanner.Start();
        }

        /// <summary>
        /// Updates the Unit manager. Should only be performed during Main.Pulse().
        /// </summary>
        public void Update()
        {
            EnemyUpdate();
            GroupUpdate();
        }

        /// <summary>
        /// Updates and caches the last known surrrounding enemies list. Try to make as few calls to the object manager as neccessary for performance considerations.
        /// Also updates and caches the last known bleeding units.
        /// </summary>
        private void EnemyUpdate()
        {
            if (Me.Combat)
            {
                
                if (!_enemyScanner.IsRunning) _enemyScanner.Restart();
                if (_enemyScanner.ElapsedMilliseconds >= _enemyScannerIntervalMs)
                {
                    this.LastKnownSurroundingEnemies = ObjectManager.GetObjectsOfTypeFast<WoWUnit>().Where(o =>
                        o.Attackable &&
                        o.Distance <= SettingsManager.Instance.AOERange &&
                        o.IsValid &&
                        o.IsAlive &&
                        !o.IsFriendly &&
                        !o.IsNonCombatPet &&
                        !o.IsCritter
                        )
                        .OrderBy(o => o.Distance)
                        .ToList();
                    if(Main.Debug) Log.Combat("sorrounding enemies: "+LastKnownSurroundingEnemies.Count);

                    this.LastKnownNonBleedingEnemies =
                        LastKnownSurroundingEnemies.Where(o => !o.AuraExists(SpellBook.SpellRend, true)).ToList();
                    if (Main.Debug) Log.Combat("sorrounding non bleeding :" + LastKnownNonBleedingEnemies.Count);
                    //Track Rend
                    this.LastKnownBleedingEnemies =
                        LastKnownSurroundingEnemies.Where(o => o.AuraExists(SpellBook.SpellRend, true)).ToList();
                    if (Main.Debug) Log.Combat("sorrounding  bleeding :" + LastKnownBleedingEnemies.Count);
                   
                    //Track Enemies in ExecuteRange
                    this.LastKnownEnemiesInExecuteRange.Where(o => o.HealthPercent < 20).ToList();
                    //TODO: Highly experimental way of calculating how long the current Target will be alive.
                    /*
                    targetTimeToDie = TimeSpan.FromSeconds(StyxWoW.Me.CurrentTarget.HealthPercent / (currentTargetHealth - StyxWoW.Me.CurrentTarget.HealthPercent)*2);
                    currentTargetHealth = StyxWoW.Me.CurrentTarget.HealthPercent;
                     */
                    _enemyScanner.Restart();
                }
            }
            else
            {
                this.LastKnownSurroundingEnemies.Clear();
                _enemyScanner.Reset();
            }
        }



        /// <summary>
        /// Updates the group information.  Uncomment to help diagnose group detection issues.
        /// </summary>
        private void GroupUpdate()
        {
            if (!_groupScanner.IsRunning) _groupScanner.Restart();
            if (_groupScanner.ElapsedMilliseconds >= _groupScannerIntervalMs)
            {

                /* diagnostics and debugging only
                 * We keep this commented out because we don't want player names to show up in our logs
                 * This should only be uncommented if something is not acting right with the group information
                */
                if (this.LastKnownGroupMemberSize != Me.GroupInfo.NumRaidMembers)
                {
                    StringBuilder sb =
                        new StringBuilder(string.Format("Group size changed from {0} to {1}",
                            this.LastKnownGroupMemberSize, Me.GroupInfo.NumRaidMembers));
                    this.LastKnownGroupMemberSize = Me.GroupInfo.NumRaidMembers;

                    /* // BEGIN
                    this.LastKnownGroupMemberSize = Me.GroupInfo.NumRaidMembers;
                    foreach (var partyMemeber in Me.GroupInfo.RaidMembers)
                    {
                        WoWPlayer player = null;
                        try
                        {
                            player = partyMemeber.ToPlayer();
                        }
                        catch { } // can't convert unit to player - maybe you're in proving grounds? // }

                        sb.Append(string.Format("\t[{0}, {1}]", player == null ? "Unknown" : player.Name, partyMemeber.Role));
                    } */

                    Log.Gui(sb.ToString());
                }
                // END */

                _groupScanner.Restart();
            }
        }


    }
}
