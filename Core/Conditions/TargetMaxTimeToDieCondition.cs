using System;
using InnerRage.Core.Managers;

namespace InnerRage.Core.Conditions
{
    internal class TargetMaxTimeToDieCondition : ICondition
    {
        private readonly TimeSpan _maxTimeToDie;

        public TargetMaxTimeToDieCondition(TimeSpan maxTimeToDie)
        {
            _maxTimeToDie = maxTimeToDie;
        }

        public bool Satisfied()
        {
            return UnitManager.Instance.TargetTimeToDie > _maxTimeToDie;
        }
    }
}