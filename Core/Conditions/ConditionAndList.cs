using System.Collections.Generic;
using System.Linq;

namespace InnerRage.Core.Conditions
{
    /// <summary>
    ///     Condition dependency list where each condition must be satisfied to return true.
    /// </summary>
    public class ConditionAndList : List<ICondition>, ICondition
    {
        public ConditionAndList()
        {
        }

        public ConditionAndList(params ICondition[] conditions)
        {
            AddRange(conditions);
        }

        public bool Satisfied()
        {
            return this.All(item => item.Satisfied());
        }
    }
}