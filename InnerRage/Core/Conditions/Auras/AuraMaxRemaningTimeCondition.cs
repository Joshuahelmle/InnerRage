using System;
using System.Drawing.Text;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace InnerRage.Core.Conditions.Auras
{
    class AuraMaxRemaningTimeCondition : ICondition
    {

        private TimeSpan _minRemaingTime;
        private WoWSpell _aura;
        private WoWUnit _target;

       public AuraMaxRemaningTimeCondition(TimeSpan minRemaingTime, WoWSpell aura, WoWUnit target)
        {
            _minRemaingTime = minRemaingTime;
            _aura = aura;
            _target = target;
        }

        public bool Satisfied()
        {
            return _target != null && _target.AuraExists(_aura.Id, true) && _target.GetAuraByName(_aura.Name).TimeLeft < _minRemaingTime;
        }
    }
}
