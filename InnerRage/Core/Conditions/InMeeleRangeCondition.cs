using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Styx;

namespace InnerRage.Core.Conditions
{
    class InMeeleRangeCondition : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.HasAttackableTarget() && StyxWoW.Me.CurrentTarget.IsWithinMeleeRange;
        }
    }
}
