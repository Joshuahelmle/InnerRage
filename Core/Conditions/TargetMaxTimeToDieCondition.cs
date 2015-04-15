using System;
using InnerRage.Core.Managers;

namespace InnerRage.Core.Conditions
{
    class TargetMaxTimeToDieCondition :ICondition
    {
        private TimeSpan _maxTimeToDie;

       public TargetMaxTimeToDieCondition(TimeSpan maxTimeToDie)
        {
            this._maxTimeToDie = maxTimeToDie;
        }
        public bool Satisfied()
        {
            return UnitManager.Instance.TargetTimeToDie > _maxTimeToDie;
        }
    }
}
