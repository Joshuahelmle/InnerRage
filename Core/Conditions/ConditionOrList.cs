using System.Collections.Generic;
using System.Linq;

namespace InnerRage.Core.Conditions
{
    /// <summary>
    ///     Condition list that returns true if any condition is satisfied.
    /// </summary>
    public class ConditionOrList : List<ICondition>, ICondition
    {
        public ConditionOrList()
        {
        }

        public ConditionOrList(params ICondition[] conditions)
        {
            AddRange(conditions);
        }

        public bool Satisfied()
        {
            return this.Any(condition => condition.Satisfied());
        }
    }
}