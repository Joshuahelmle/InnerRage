using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Talents;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared
{
    public class VictoryRushAbility : AbilityBase
    {
        public VictoryRushAbility()
            : base(WoWSpell.FromId(SpellBook.SpellVictoryRush), true, true)
        {
            Category = AbilityCategory.Heal;
            Conditions.Add(new ConditionOrList(
                new BooleanCondition(Me.CurrentHealth < 70), //use as Heal
                new TalentUnquenchableThirstNotEnabledCondition()));
            //if not needed as a heal never use it in conjunction with unquenchable Thirst. DPS LOSS
        }
    }
}