using Styx;

namespace InnerRage.Core.Conditions
{
    /// <summary>
    ///     Checks wheter we are the given race.
    /// </summary>
    internal class IsRaceCondition : ICondition
    {
        /// <summary>
        ///     the Race to check for
        /// </summary>
        private readonly WoWRace _race;

        public IsRaceCondition(WoWRace race)
        {
            _race = race;
        }

        public bool Satisfied()
        {
            return StyxWoW.Me.Race == _race;
        }
    }
}