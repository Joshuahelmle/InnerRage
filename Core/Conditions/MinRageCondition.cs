using Styx;

namespace InnerRage.Core.Conditions
{
    internal class MinRageCondition : ICondition
    {
        private readonly int _minRage;

        public MinRageCondition(int minRage)
        {
            _minRage = minRage;
        }

        public bool Satisfied()
        {
            return StyxWoW.Me.CurrentRage > _minRage;
        }
    }
}