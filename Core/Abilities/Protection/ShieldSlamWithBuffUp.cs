using InnerRage.Core.Conditions.Auras;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Protection
{
    public class ShieldSlamWithBuffUp : AbilityBase
    {
        public ShieldSlamWithBuffUp() 
            : base(WoWSpell.FromId(SpellBook.SpellShieldSlam), true, true)
        {
            base.Category = AbilityCategory.Combat;
            Conditions.Add(new TargetAuraUpCondition(Me, WoWSpell.FromId(50227)));
        }
    }
}