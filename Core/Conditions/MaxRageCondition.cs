using Styx;

namespace InnerRage.Core.Conditions
{
    internal class MaxRageCondition : ICondition
    {
        private readonly int _maxRage;

        public MaxRageCondition(int maxRage)
        {
            _maxRage = maxRage;
        }

        public bool Satisfied()
        {
            return StyxWoW.Me.CurrentRage < _maxRage;
        }
    }
}