using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace InnerRage.Core.Conditions.Auras
{
    internal class TargetAuraUpCondition : ICondition
    {
        private readonly WoWSpell _aura;
        private readonly WoWUnit _target;

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