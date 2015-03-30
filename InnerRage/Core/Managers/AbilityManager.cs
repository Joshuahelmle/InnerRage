/* CREDIT : Almost all of the code in this class is Work of SnowCrash , thanks for giving me insight and creative ideas buddy! */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Buddy.Coroutines;
using InnerRage.Core.Abilities;
using InnerRage.Core.Abilities.Arms;
using InnerRage.Core.Abilities.Fury;
using InnerRage.Core.Abilities.Shared;
using InnerRage.Core.Abilities.Shared.Racials;
using InnerRage.Core.Utilities;
using Styx.WoWInternals.WoWObjects;

//using Arms = InnerRage.Core.Abilities.Arms;
//using Fury = InnerRage.Core.Abilities.Fury;

namespace InnerRage.Core.Managers
{
    /// <summary>
    /// Provides the management of loaded abilities.
    /// </summary>
    public sealed class AbilityManager
    {
        #region [IR] Singletons

        private static AbilityManager _singletonInstance;

        /// <summary>
        /// Singleton instance.
        /// </summary>
        public static AbilityManager Instance
        {
            get
            {
                return _singletonInstance ?? (_singletonInstance = new AbilityManager());
            }
        }

        /// <summary>
        /// Rebuilds and reloads all of the abilities. Is used after changing Talents, or Specc
        /// </summary>
        public static void ReloadAbilities()
        {
            _singletonInstance = new AbilityManager();
        }

        #endregion

        /// <summary>
        /// The amount of time to elapse in order to presume an ability has been casted too quickly after it has been already previously casted.
        /// </summary>
        public const int CastTryElapsedTimeMs = 500;

        /// <summary>
        /// The number of times allowed to cast an ability before it has been blocked after a consecutive attempt.
        /// </summary>
        public const int CastTryThreshold = 2;

        /// <summary>
        /// The length of time in Milliseconds to block an ability before it is allowed to be cast again.
        /// </summary>
        public const int BlockTimeMs = 2000;

        /// <summary>
        /// Gets the last casted ability.
        /// </summary>
        public IAbility LastCastAbility { get; private set; }

        /// <summary>
        /// Gets the time of the last casted ability.
        /// </summary>
        public DateTime LastCastDateTime { get; private set; }

        /// <summary>
        /// Gets the number of successful cast attempts for the last casted ability.
        /// </summary>
        public int LastCastTries { get; private set; }

        /// <summary>
        /// Gets the list of loaded abilities.
        /// </summary>
        public List<IAbility> Abilities { get; private set; }

        /// <summary>
        /// Gets the list of abilities that are currently blocked.
        /// </summary>
        public BlockedAbilityList BlockedAbilities { get; private set; }

        /// <summary>
        /// Updates each loaded ability. This should only be done during the Main.Pulse().
        /// </summary>
        public void Update()
        {
            foreach (IAbility ability in Abilities)
            {
                ability.Update();
            }
        }

        /// <summary>
        /// <para>(Non-Blocking) Casts the specified ability on the provided target. Also generates logging and audit information.</para>
        /// <para>This is the perferred entry point to casting an ability's spell, as it manages the logic behind blocked abilities</para>
        /// </summary>
        /// <returns>Will return true if the cast was successful.</returns>
        public async Task<bool> Cast<T>(WoWUnit target) where T : IAbility
        {

            
            var abilities = Get<T>();
            

            if (abilities == null || abilities.Count == 0)
                throw new AbilityException("Ability does not exist.");

            foreach (var ability in abilities)
            {

                var blockedAbility = this.BlockedAbilities.GetBlockedAbilityByType(ability.GetType());
                if (blockedAbility != null)
                {
                    var blockedTimeInMs = (DateTime.Now - blockedAbility.BlockedDateAndTime).TotalMilliseconds;
                    if (blockedTimeInMs >= BlockTimeMs)
                    {
                        this.BlockedAbilities.Remove(blockedAbility);
                        Log.Diagnostics(string.Format("Blocked ability {0} removed after {1} ms.", ability.Spell.Name, blockedTimeInMs));
                    }
                    else
                    {
                        // The ability is blocked, do not cast.
                        return false;
                    }
                }

                ability.Target = target;
                var castResult = await ability.CastOnTarget(target);

                if (castResult)
                {
                    if (ability == this.LastCastAbility) // This ability was already casted before, has it been less than the threshold minimum?
                    {
                        var lastCastTimeInMs = (DateTime.Now - this.LastCastDateTime).TotalMilliseconds;
                        if (lastCastTimeInMs < CastTryElapsedTimeMs)
                        {
                            if (this.LastCastTries >= CastTryThreshold)
                            {
                                this.BlockedAbilities.Add(new BlockedAbility(ability, DateTime.Now));
                                Log.Diagnostics(string.Format("{0} has been blocked after {1} cast atttempts. Total of {2} blocked abilities.", ability.GetType().Name, this.LastCastTries + 1, this.BlockedAbilities.Count));

                                return false;
                            }
                            else
                            {
                                this.LastCastTries++;
                            }
                        }
                    }
                    else
                    {
                        this.LastCastTries = 1;
                    }


                    // Track Bleeds
                  //  if (ability is Arms.RendAbility) UnitManager.Instance.AddRendedTarget(target);

                    this.LastCastAbility = ability;
                    this.LastCastDateTime = DateTime.Now;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the current instance of the specified ability class.
        /// </summary>
        public List<IAbility> Get<T>() where T : IAbility
        {
            return this.Abilities
                .Where(o => o is T)
                .ToList();
        }

        /// <summary>
        /// Builds the list of abilities on creation.
        /// </summary>
        public AbilityManager()
        {
            this.Abilities = new List<IAbility>();
            this.BlockedAbilities = new BlockedAbilityList();

            #region [IR] - Arms
            this.Abilities.Add(new CollosusSmashAbility());
            this.Abilities.Add(new MortalStrikeAbility());
            this.Abilities.Add(new RendAbility());
            this.Abilities.Add(new SlamAbility());
            this.Abilities.Add(new SweepingStrikesAbility());


            #endregion

            #region [IR] - Fury
            this.Abilities.Add(new AwaitBloodThirstCooldownAbility());
            this.Abilities.Add(new BloodThirstToEnrageOrRagingBlowStacksAbility());
            this.Abilities.Add(new FillerBloodThirstAbility());
            this.Abilities.Add(new RagingBlowAbility());
            this.Abilities.Add(new RagingBlowWithMeatCleaverAbility());
            this.Abilities.Add(new RagingBlowWithMeatCleaverToNotCapAbility());
            this.Abilities.Add(new WhirlWindToGetMeatCleaverStacksAbility());
            this.Abilities.Add(new WildStrikeRageDumpAbility());
            this.Abilities.Add(new WildStrikeWithBloodSurgeUpAbility());
            this.Abilities.Add(new WildStrikeWithoutBloodSurgeAbility());
            

            #endregion

            #region [IR] - Shared
            this.Abilities.Add(new AvatarAbility());
            this.Abilities.Add(new BattleShoutAbility());
            
            
            this.Abilities.Add(new BerserkerRageAbility());
            this.Abilities.Add(new BladeStormAbility());
            this.Abilities.Add(new BloodBathAbility());
            this.Abilities.Add(new CommandingShoutAbility());
            this.Abilities.Add(new DragonRoarAbility());
            this.Abilities.Add(new ExecuteAbility());
            this.Abilities.Add(new ExecuteWithSuddenDeathAbility());
            this.Abilities.Add(new ImpendingVictoryAbility());
            this.Abilities.Add(new RavagerAbility());
            this.Abilities.Add(new RecklessnessAbility());
            this.Abilities.Add(new ShockWaveAbility());
            this.Abilities.Add(new SiegeBreakerAbility());
            this.Abilities.Add(new StormBoltAbility());
            this.Abilities.Add(new WhirlWindAbility());
            this.Abilities.Add(new ThunderclapAbility());
            this.Abilities.Add(new RacialOrcBloodFuryAbility());
            this.Abilities.Add(new RacialsBloodElfAbility());
            this.Abilities.Add(new RacialsTrollBerserkingAbility());
            this.Abilities.Add(new RacialHumanAbility());
            
            #endregion

        }
    }
}