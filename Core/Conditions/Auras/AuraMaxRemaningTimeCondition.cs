using System;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace InnerRage.Core.Conditions.Auras
{
    internal class AuraMaxRemaningTimeCondition : ICondition
    {
        private readonly WoWSpell _aura;
        private readonly TimeSpan _maxRemaingTime;
        private readonly WoWUnit _target;

        public AuraMaxRemaningTimeCondition(TimeSpan maxRemaingTime, WoWSpell aura, WoWUnit target)
        {
            _maxRemaingTime = maxRemaingTime;
            _aura = aura;
            _target = target;
        }

        public bool Satisfied()
        {
            return _target != null && _target.AuraExists(_aura.Id, true) &&
                   _target.AuraRemainingTime(_aura.Id, true) < _maxRemaingTime;
        }
    }
}