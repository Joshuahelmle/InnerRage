using Styx;

namespace InnerRage.Core
{
    internal static class SpellBook
    {
        #region [IR] - Stances

        public const int StanceBattleStance = 2457,
            StanceDefensiveStance = 71,
            StanceImprovedDefensiveStance = 157494,
            StanceGladiatorStance = 156291;

        #endregion

        #region [IR] - Aura List

        public const int
            AuraBloodBath = 12292,
            AuraBloodSurge = 46916,
            AuraEnrage = 12880,
            AuraMeatCleaver = 85739,
            AuraUltimatum = 122510,
            AuraUnyieldingStrikes = 169686,
            AuraRagingBlow = 131116,
            AuraSuddenDeath = 52437,
            AuraShieldBlock = 132404,

            #endregion

            #region [IR] - Debuff List

            #endregion

            #region [IR] - Glyphs

            GlyphUnendingRage = 58098,
            GlyphOfResonatingPower = 58356,

            #endregion

            #region [IR] - Spell List

            SpellAvatar = 107574,
            SpellBattleshout = 6673,
            SpellCommandingShout = 469,
            SpellBerserkerRage = 18499,
            SpellBladestorm = 46924,
            SpellBloodbath = 12292,
            SpellBloodThirst = 23881,
            SpellCharge = 100,
            SpellCollosusSmash = 167105,
            SpellDevastate = 20243,
            SpellDieByTheSword = 118038,
            SpellDragonRoar = 118000,
            SpellEnragedRegeneration = 55694,
            SpellFuriousStrikes = 169679,
            SpellHamString = 1715,
            SpellHeroicStrike = 78,
            SpellImpendingVictory = 103840,
            SpellMortalStrike = 12294,
            SpellPummel = 6552,
            SpellRallyingCry = 97462,
            SpellRagingBlow = 85288,
            SpellRavager = 152277,
            SpellRecklessness = 1719,
            SpellRend = 772,
            SpellRevenge = 6572,
            SpellSiegeBreaker = 176289,
            SpellShockwave = 46968,
            SpellShieldSlam = 23922,
            SpellSlam = 1464,
            SpellStormBolt = 107570,
            SpellSuddenDeath = 29725,
            SpellSweepingStrikes = 12328,
            SpellTasteForBlood = 566636,
            SpellThunderClap = 6343,
            SpellUnquenchableThirst = 169683,
            SpellVictoryRush = 34428,
            SpellWhirlwind = 1680,
            SpellWildStrike = 100130;


        //execute changes within speccs
        public static int SpellExecute = StyxWoW.Me.Specialization == WoWSpec.WarriorArms ? 163201 : 5308;

        #endregion

        #region [IR] - Raid or other Buffs

        //Attackpower
        public const int
            AuraBattleShout = 6673,
            AuraHornOfWinter = 57330,
            AuraTrueshotAura = 19506,

            //Stamina
            AuraCommandingShout = 21562,
            AuraPowerWordFortitude = 166928,
            AuraBloodPact = 469,
            AuraLoneWolfFortitudeOfTheBear = 160199,

            //Stats
            AuraMarkOfTheWild = 1126,

            //Haste
            AuraAncientHysteria = 90355,
            AuraBloodlust = 2825,
            AuraHeroism = 32182,
            AuraNetherwinds = 160452,
            AuraTimewarp = 80353;

        //Racials

        public const int
            RacialTrollBerserking = 26297,
            RacialOrcBloodFury = 33697,
            RacialBloodElfArcaneTorrent = 28730,
            RacialHumanEveryManForHimself = 59752;

        #endregion
    }
}