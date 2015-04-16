using System.Runtime.CompilerServices;
using InnerRage.Core.Conditions.Auras;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Protection
{
    public class ShieldSlamWithBlockUpAbility : AbilityBase
    {
        public ShieldSlamWithBlockUpAbility()
            : base(WoWSpell.FromId(SpellBook.SpellShieldSlam), true, true)
        {
            base.Conditions.Add(new TargetAuraUpCondition(Me , WoWSpell.FromId(SpellBook.AuraShieldBlock)));
        }
    }
}