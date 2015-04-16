using System;
using InnerRage.Core.Managers;
using Styx;

namespace InnerRage.Core.Conditions
{
    class OnlyOnBossCondition : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.CurrentTarget.IsBoss;
        }
    }
}
