using InnerRage.Core.Conditions;
using InnerRage.Core.Managers;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared
{
    public class EnragedRegenerationAbility : AbilityBase
    {
        public EnragedRegenerationAbility()
            : base(WoWSpell.FromId(SpellBook.SpellEnragedRegeneration), false, true)
        {
            Category = AbilityCategory.Heal;
            Conditions.Add(new BooleanCondition(Me.KnowsSpell(Spell.Id)));
            Conditions.Add(new BooleanCondition(SettingsManager.Instance.UseEnragedRegeneration));
            Conditions.Add(new TargetIsInHealthRangeCondition(Me, 0, SettingsManager.Instance.EnragedRegenerationHP));
        }
    }
}