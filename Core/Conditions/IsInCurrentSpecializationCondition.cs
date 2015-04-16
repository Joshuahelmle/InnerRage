using Styx;

namespace InnerRage.Core.Conditions
{
    internal class IsInCurrentSpecializationCondition : ICondition
    {
        private readonly WoWSpec _currentSpec;

        public IsInCurrentSpecializationCondition(WoWSpec currentSpec)
        {
            _currentSpec = currentSpec;
        }

        public bool Satisfied()
        {
            return StyxWoW.Me.Specialization == _currentSpec;
        }
    }
}