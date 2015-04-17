/* CREDIT : Almost all of the code in this class is Work of SnowCrash , thanks for giving me insight and creative ideas buddy! */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InnerRage.Core.Abilities;
using InnerRage.Core.Abilities.Arms;
using InnerRage.Core.Abilities.Fury;
using InnerRage.Core.Abilities.Protection;
using InnerRage.Core.Abilities.Shared;
using InnerRage.Core.Abilities.Shared.Racials;
using InnerRage.Core.Utilities;
using Styx.WoWInternals.WoWObjects;

//using Arms = InnerRage.Core.Abilities.Arms;
//using Fury = InnerRage.Core.Abilities.Fury;

namespace InnerRage.Core.Managers
{
    /// <summary>
    ///     Provides the management of loaded abilities.
    /// </summary>
    public sealed class AbilityManager
    {
        /// <summary>
        ///     The amount of time to elapse in order to presume an ability has been casted too quickly after it has been already
        ///     previously casted.
        /// </summary>
        public const int CastTryElapsedTimeMs = 500;

        /// <summary>
        ///     The number of times allowed to cast an ability before it has been blocked after a consecutive attempt.
        /// </summary>
        public const int CastTryThreshold = 2;

        /// <summary>
        ///     The length of time in Milliseconds to block an ability before it is allowed to be cast again.
        /// </summary>
        public const int BlockTimeMs = 2000;

        /// <summary>
        ///     Builds the list of abilities on creation.
        /// </summary>
        public AbilityManager()
        {
            Abilities = new List<IAbility>();
            BlockedAbilities = new BlockedAbilityList();

            #region [IR] - Arms

            Abilities.Add(new CollosusSmashAbility());
            Abilities.Add(new MortalStrikeAbility());
            Abilities.Add(new RendAbility());
            Abilities.Add(new SlamAbility());
            Abilities.Add(new SweepingStrikesAbility());
            Abilities.Add(new WhirlwindAoeAbility());

            #endregion

            #region [IR] - Fury

            Abilities.Add(new AwaitBloodThirstCooldownAbility());
            Abilities.Add(new BloodThirstToEnrageOrRagingBlowStacksAbility());
            Abilities.Add(new FillerBloodThirstAbility());
            Abilities.Add(new RagingBlowAbility());
            Abilities.Add(new RagingBlowWithMeatCleaverAbility());
            Abilities.Add(new RagingBlowWithMeatCleaverToNotCapAbility());
            Abilities.Add(new WhirlWindToGetMeatCleaverStacksAbility());
            Abilities.Add(new WildStrikeRageDumpAbility());
            Abilities.Add(new WildStrikeWithBloodSurgeUpAbility());
            Abilities.Add(new WildStrikeWithoutBloodSurgeAbility());

            #endregion

            #region [IR] - Prot
            Abilities.Add(new DemoralizingShoutAbility());
            Abilities.Add(new DevastateAbility());
            Abilities.Add(new HeroicStrikeAbility());
            Abilities.Add(new LastStandAbility());
            Abilities.Add(new ProtThunderClapAbility());
            Abilities.Add(new RevengeAbility());
            Abilities.Add(new ShieldBarrierAbility());
            Abilities.Add(new ShieldBlock());
            Abilities.Add(new ShieldSlamAbility());
            Abilities.Add(new ShieldSlamWithBlockUpAbility());
            Abilities.Add(new ShieldWallAbility());
            #endregion
            #region [IR] - Shared

            Abilities.Add(new AvatarAbility());
            Abilities.Add(new BattleShoutAbility());


            Abilities.Add(new BerserkerRageAbility());
            Abilities.Add(new BerserkerBreakCCAbility());
            Abilities.Add(new BladeStormAbility());
            Abilities.Add(new BloodBathAbility());
            Abilities.Add(new CommandingShoutAbility());
            Abilities.Add(new DragonRoarAbility());
            Abilities.Add(new DieByTheSwordAbility());
            Abilities.Add(new EnragedRegenerationAbility());
            Abilities.Add(new ExecuteAbility());
            Abilities.Add(new ExecuteWithSuddenDeathAbility());
            Abilities.Add(new ImpendingVictoryAbility());
            Abilities.Add(new RavagerAbility());
            Abilities.Add(new RecklessnessAbility());
            Abilities.Add(new ShockWaveAbility());
            Abilities.Add(new SiegeBreakerAbility());
            Abilities.Add(new StormBoltAbility());
            Abilities.Add(new VictoryRushAbility());
            Abilities.Add(new WhirlWindAbility());
            Abilities.Add(new ThunderclapAbility());
            Abilities.Add(new RallyingCryAbility());
            Abilities.Add(new RacialOrcBloodFuryAbility());
            Abilities.Add(new RacialsBloodElfAbility());
            Abilities.Add(new RacialsTrollBerserkingAbility());
            Abilities.Add(new RacialHumanAbility());
            Abilities.Add(new Pummel());

            #endregion
        }

        /// <summary>
        ///     Gets the last casted ability.
        /// </summary>
        public IAbility LastCastAbility { get; private set; }

        /// <summary>
        ///     Gets the time of the last casted ability.
        /// </summary>
        public DateTime LastCastDateTime { get; private set; }

        /// <summary>
        ///     Gets the number of successful cast attempts for the last casted ability.
        /// </summary>
        public int LastCastTries { get; private set; }

        /// <summary>
        ///     Gets the list of loaded abilities.
        /// </summary>
        public List<IAbility> Abilities { get; private set; }

        /// <summary>
        ///     Gets the list of abilities that are currently blocked.
        /// </summary>
        public BlockedAbilityList BlockedAbilities { get; private set; }

        /// <summary>
        ///     Updates each loaded ability. This should only be done during the Main.Pulse().
        /// </summary>
        public void Update()
        {
            foreach (var ability in Abilities)
            {
                ability.Update();
            }
        }

        /// <summary>
        ///     <para>
        ///         (Non-Blocking) Casts the specified ability on the provided target. Also generates logging and audit
        ///         information.
        ///     </para>
        ///     <para>
        ///         This is the perferred entry point to casting an ability's spell, as it manages the logic behind blocked
        ///         abilities
        ///     </para>
        /// </summary>
        /// <returns>Will return true if the cast was successful.</returns>
        public async Task<bool> Cast<T>(WoWUnit target) where T : IAbility
        {
            var abilities = Get<T>();


            if (abilities == null || abilities.Count == 0)
                throw new AbilityException("Ability does not exist.");

            foreach (var ability in abilities)
            {
                var blockedAbility = BlockedAbilities.GetBlockedAbilityByType(ability.GetType());
                if (blockedAbility != null)
                {
                    var blockedTimeInMs = (DateTime.Now - blockedAbility.BlockedDateAndTime).TotalMilliseconds;
                    if (blockedTimeInMs >= BlockTimeMs)
                    {
                        BlockedAbilities.Remove(blockedAbility);
                        Log.Diagnostics(string.Format("Blocked ability {0} removed after {1} ms.", ability.Spell.Name,
                            blockedTimeInMs));
                    }
                    else
                    {
                        // The ability is blocked, do not cast.
                        return false;
                    }
                }

                ability.Target = target;
                var castResult = await ability.CastOnTarget(target);
                if(Main.Debug) Log.Diagnostics("Cast result was : "+castResult);
                if (castResult)
                {
                    if (ability == LastCastAbility)
                        // This ability was already casted before, has it been less than the threshold minimum?
                    {
                        var lastCastTimeInMs = (DateTime.Now - LastCastDateTime).TotalMilliseconds;
                        if (lastCastTimeInMs < CastTryElapsedTimeMs)
                        {
                            if (LastCastTries >= CastTryThreshold)
                            {
                                BlockedAbilities.Add(new BlockedAbility(ability, DateTime.Now));
                                Log.Diagnostics(
                                    string.Format(
                                        "{0} has been blocked after {1} cast atttempts. Total of {2} blocked abilities.",
                                        ability.GetType().Name, LastCastTries + 1, BlockedAbilities.Count));

                                return false;
                            }
                            LastCastTries++;
                        }
                    }
                    else
                    {
                        LastCastTries = 1;
                    }


                    // Track Bleeds
                    //  if (ability is Arms.RendAbility) UnitManager.Instance.AddRendedTarget(target);

                    LastCastAbility = ability;
                    LastCastDateTime = DateTime.Now;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        ///     Gets the current instance of the specified ability class.
        /// </summary>
        public List<IAbility> Get<T>() where T : IAbility
        {
            return Abilities
                .Where(o => o is T)
                .ToList();
        }

        #region [IR] Singletons

        private static AbilityManager _singletonInstance;

        /// <summary>
        ///     Singleton instance.
        /// </summary>
        public static AbilityManager Instance
        {
            get { return _singletonInstance ?? (_singletonInstance = new AbilityManager()); }
        }

        /// <summary>
        ///     Rebuilds and reloads all of the abilities. Is used after changing Talents, or Specc
        /// </summary>
        public static void ReloadAbilities()
        {
            _singletonInstance = new AbilityManager();
        }

        #endregion
    }
}