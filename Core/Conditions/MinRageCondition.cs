using Styx;

namespace InnerRage.Core.Conditions
{
    class MinRageCondition : ICondition
    {
        private int _minRage;

       public  MinRageCondition(int minRage)
        {
            this._minRage = minRage;
        }

        public bool Satisfied()
        {
            return StyxWoW.Me.CurrentRage > _minRage;
        }
    }
}
