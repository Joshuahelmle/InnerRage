using System;
using InnerRage.Core.Managers;
using Styx;

namespace InnerRage.Core.Conditions
{
    class OnlyOnBossCondition : ICondition
    {
        public bool Satisfied()
        {
            return !SettingsManager.Instance.RecklessOnlyOnBoss || (SettingsManager.Instance.RecklessOnlyOnBoss && StyxWoW.Me.CurrentTarget.IsBoss);
        }
    }
}
