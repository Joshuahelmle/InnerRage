using System.ComponentModel;
using InnerRage.Core.Conditions;
using InnerRage.Core.Managers;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared
{
    public class EnragedRegenerationAbility :AbilityBase
    {
        public EnragedRegenerationAbility() 
            : base(WoWSpell.FromId(SpellBook.SpellEnragedRegeneration), false, true)
        {
            base.Category = AbilityCategory.Heal;
            base.Conditions.Add(new BooleanCondition(Me.KnowsSpell(Spell.Id)));
            base.Conditions.Add(new BooleanCondition(SettingsManager.Instance.UseEnragedRegeneration));
            base.Conditions.Add(new TargetIsInHealthRangeCondition(Me, 0 , SettingsManager.Instance.EnragedRegenerationHP));
        }
    }
}