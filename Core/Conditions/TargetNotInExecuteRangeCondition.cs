using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Styx.WoWInternals.WoWObjects;

namespace InnerRage.Core.Conditions
{
    class TargetNotInExecuteRangeCondition : ICondition
    {
        private WoWUnit _target;

        public TargetNotInExecuteRangeCondition(WoWUnit target)
        {
            _target = target;
        }

        public bool Satisfied()
        {
            return _target != null && new TargetIsInHealthRangeCondition(_target ,20).Satisfied();
        }
    }
}
