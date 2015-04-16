using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Auras;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Protection
{
    public class ShieldBlock : AbilityBase
    {
        public ShieldBlock() 
            : base(WoWSpell.FromId(SpellBook.SpellShieldBlock), false, true)
        {
            Category = AbilityCategory.Buff;
            Conditions.Add(new MinRageCondition(60));
            Conditions.Add(new DoesNotHaveAuraUpCondition(Me , WoWSpell.FromId(SpellBook.AuraShieldBlock)));

        }
    }
}