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
            return StyxWoW.Me.IsWithinMeleeRangeOf(StyxWoW.Me.CurrentTarget);
        }
    }
}
