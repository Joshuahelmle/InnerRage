using Styx;

namespace InnerRage.Core.Conditions
{
    class MaxRageCondition : ICondition
    {
        private int _maxRage;

       public MaxRageCondition(int maxRage)
        {
            this._maxRage = maxRage;
        }
        public bool Satisfied()
        {
            return StyxWoW.Me.CurrentRage < _maxRage;
        }
    }
}
