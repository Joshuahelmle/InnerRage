using InnerRage.Core.Conditions;
using InnerRage.Core.Managers;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Protection
{
    public class ShieldWallAbility : AbilityBase
    {
        public ShieldWallAbility() 
            : base(WoWSpell.FromId(SpellBook.SpellShieldWall),false , true )
        {
            Category = AbilityCategory.Buff;
            Conditions.Add(new BooleanCondition(SettingsManager.Instance.UseShieldWall));
            Conditions.Add(new TargetIsInHealthRangeCondition(Me, 0, SettingsManager.Instance.UseShieldWallHP));
        }
    }
}