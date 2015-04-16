using System;
using Styx.Helpers;


namespace InnerRage.Core.Managers
{
    /// <summary>
    /// provides Management of all Settings which are done by the user
    /// This includes things like, interrupt enabled, Talents to use, TrinketUsage and many more.
    /// </summary>
    class SettingsManager : Settings
    {

        #region singletons

        private static SettingsManager _settingsManager;

        public static SettingsManager Instance
        {
            get { return _settingsManager ?? (new SettingsManager(GlobalSettings.GetFullPathToProfile(GlobalSettings.Instance.LastUsedProfile))); }
        }

        


        public static void Init(String pathToProfile = null)
        {
            _settingsManager = pathToProfile != null ? new SettingsManager(pathToProfile) : new SettingsManager(GlobalSettings.GetFullPathToProfile(GlobalSettings.Instance.LastUsedProfile));
        }

        #endregion

      

#region [IR] - Shared Settings
        [Setting, DefaultValue(10)]
        public int AOERange { get; set; }
        //Buffs
        [Setting, DefaultValue(false)]
        public bool BuffBattleshout { get; set; }
        [Setting, DefaultValue(false)]
        public bool BuffCommandingShout { get; set; }
        [Setting, DefaultValue(false)]
        public bool BuffEnabled { get; set; }
        [Setting,DefaultValue(false)]
        public bool InterruptPummel { get; set; }
        [Setting, DefaultValue(false)]
        public bool InterruptDisruptingShout { get; set; }
        [Setting, DefaultValue(false)]
        public bool InterruptShockWave { get; set; }
        [Setting, DefaultValue(false)]
        public bool InterruptStormBolt { get; set; }
        [Setting, DefaultValue(false)]
        public bool TalentAvatar { get; set; }
        [Setting, DefaultValue(false)]
        public bool TalentBloodBath { get; set; }
        [Setting, DefaultValue(false)]
        public bool TalentBladeStorm { get; set; }
        [Setting, DefaultValue(false)]
        public bool TalentDragonRoar { get; set; }
        [Setting, DefaultValue(false)]
        public bool TalentRavager { get; set; }
        [Setting, DefaultValue(false)]
        public bool TalentShockWave { get; set; }
        [Setting, DefaultValue(false)]
        public bool TalentStormBolt { get; set; }
        [Setting, DefaultValue(false)]
        public bool TalentBloodbathOnTrinket { get; set; }
        [Setting, DefaultValue(false)]
        public bool TalentBloodbathAlways { get; set; }
        [Setting, DefaultValue(false)]
        public bool TalentRecklessnessAlways { get; set; }
        [Setting, DefaultValue(false)]
        public bool TalentRecklessnessOnBloodBath { get; set; }
        [Setting, DefaultValue(false)]
        public bool TalentRecklessnessNever { get; set; }
        [Setting, DefaultValue(false)]
        public bool TalentSyncBladeStorm { get; set; }
        [Setting, DefaultValue(false)]
        public bool TalentSyncRavager { get; set; }
        [Setting, DefaultValue(false)]
        public bool TalentSyncAvatar { get; set; }
        [Setting, DefaultValue(false)]
        public bool TalentSyncDragonRoar { get; set; }
        [Setting, DefaultValue(false)]
        public bool UseTrinket1 { get; set; }
        [Setting, DefaultValue(false)]
        public bool UseTrinket1OnLoC { get; set; }
        [Setting, DefaultValue(false)]
        public bool UseTrinket1ToBurst { get; set; }
        [Setting, DefaultValue(false)]
        public bool UseTrinket2 { get; set; }
        [Setting, DefaultValue(false)]
        public bool UseTrinket2OnLoC { get; set; }
        [Setting, DefaultValue(false)]
        public bool UseTrinket2ToBurst { get; set; }
        [Setting, DefaultValue(false)]
        public bool UseOrcRacial { get; set; }
        [Setting, DefaultValue(false)]
        public bool UseTrollRacial { get; set; }
        [Setting, DefaultValue(false)]
        public bool UseHumanRacial { get; set; }
        [Setting, DefaultValue(false)]
        public bool UseBloodElfRacial { get; set; }
        [Setting, DefaultValue(0)]
        public int TrinketProccAura { get; set; }
        [Setting, DefaultValue(300)]
        public int InterruptDelay { get;set; }
        [Setting, DefaultValue(300)]
        public int LoCDelay { get; set; }
        [Setting, DefaultValue(false)]
        public bool RecklessOnlyOnBoss { get; set; }
        [Setting, DefaultValue(false)]
        public bool RavagerOnlyOnBoss { get; set; }
        [Setting, DefaultValue(false)]
        public bool RavagerOnlyOnAoECount { get; set; }
        [Setting, DefaultValue(2)]
        public int RavagerAoeCount { get; set; }
        [Setting, DefaultValue(false)]
        public bool BladestormOnlyOnBoss { get; set; }        
        [Setting, DefaultValue(false)]
        public bool BladestormOnlyOnAoECount { get; set; }
        [Setting, DefaultValue(2)]
        public int BladestormAoeCount { get; set; }
        [Setting, DefaultValue(false)]
        public bool DragonRoarOnlyOnBoss { get; set; }
        [Setting, DefaultValue(false)]
        public bool DragonRoarOnlyOnAoECount { get; set; }
        [Setting, DefaultValue(2)]
        public int DragonRoarAoeCount { get; set; }
        [Setting, DefaultValue(false)]
        public bool UseBerserkerBreakFear { get; set; }
        [Setting, DefaultValue(60)]
        public int EnragedRegenerationHP { get; set; }
        [Setting, DefaultValue(false)]
        public bool UseEnragedRegeneration { get; set; }
        [Setting, DefaultValue(false)]
        public bool UseRallyingCry { get; set; }
        [Setting, DefaultValue(25)]
        public int RallyingCryHP { get; set; }
        [Setting, DefaultValue(false)]
        public bool UseDieByTheSword { get; set; }
        [Setting, DefaultValue(25)]
        public int UseDieByTheSwordHP { get; set; }


        #endregion

        public SettingsManager(String pathToFile)
            : base(pathToFile)
        {
        }





        
    }
}
