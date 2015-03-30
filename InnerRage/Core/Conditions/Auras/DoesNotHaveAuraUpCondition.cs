using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace InnerRage.Core.Conditions.Auras
{
    class DoesNotHaveAuraUpCondition : ICondition
    {

        private WoWUnit _target;
        private WoWSpell _aura;

        public DoesNotHaveAuraUpCondition(WoWUnit target, WoWSpell aura)
        {
            _target = target;
            _aura = aura;
        }

        public bool Satisfied()
        {
            return  _target != null && !_target.HasAura(_aura.Id);
        }
    }
}
