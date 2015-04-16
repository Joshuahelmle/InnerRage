using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace InnerRage.Core.Conditions.Auras
{
    internal class DoesNotHaveAuraUpCondition : ICondition
    {
        private readonly WoWSpell _aura;
        private readonly WoWUnit _target;

        public DoesNotHaveAuraUpCondition(WoWUnit target, WoWSpell aura)
        {
            _target = target;
            _aura = aura;
        }

        public bool Satisfied()
        {
            return _target != null && !_target.AuraExists(_aura.Id, true);
        }
    }
}