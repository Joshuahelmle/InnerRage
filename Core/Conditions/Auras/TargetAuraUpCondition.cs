using System;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace InnerRage.Core.Conditions.Auras
{
    class TargetAuraUpCondition : ICondition
    {
        private WoWUnit _target;
        private WoWSpell _aura;

        public TargetAuraUpCondition(WoWUnit target, WoWSpell aura)
        {
            _target = target;
            _aura = aura;
        }

        public bool Satisfied()
        {
            return _target != null && _target.HasAura(_aura.Id);
        }
    }
}
