using InnerRage.Core.Conditions;
using InnerRage.Core.Managers;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared
{
    public class RallyingCryAbility : AbilityBase
    {
        public RallyingCryAbility()
            : base(WoWSpell.FromId(SpellBook.SpellRallyingCry), false, true)
        {
            Category = AbilityCategory.Heal;
            base.Conditions.Add(new BooleanCondition(SettingsManager.Instance.UseRallyingCry));
            base.Conditions.Add(new TargetIsInHealthRangeCondition(Me, 0, SettingsManager.Instance.RallyingCryHP));
        }
    }
}