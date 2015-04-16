using InnerRage.Core.Conditions;
using InnerRage.Core.Managers;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Protection
{
    public class LastStandAbility : AbilityBase
    {
        public LastStandAbility ()
        : base(WoWSpell.FromId(SpellBook.SpellLastStand),false, true)
        {

            Category = AbilityCategory.Buff;
            Conditions.Add(new BooleanCondition(SettingsManager.Instance.UseLastStand));
            Conditions.Add(new TargetIsInHealthRangeCondition(Me, 0, SettingsManager.Instance.UseLastStandHP));
        }

    }
}