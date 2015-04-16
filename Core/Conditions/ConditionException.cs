using System;

namespace InnerRage.Core.Conditions
{
    internal class ConditionException : Exception
    {
        public ConditionException(string message)
            : base(message)
        {
        }
    }
}