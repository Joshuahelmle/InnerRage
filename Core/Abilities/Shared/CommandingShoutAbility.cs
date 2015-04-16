using InnerRage.Core.Conditions;
using InnerRage.Core.Managers;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared
{
    internal class CommandingShoutAbility : AbilityBase
    {
        public CommandingShoutAbility()
            : base(WoWSpell.FromId(SpellBook.SpellCommandingShout), true, false)
        {
            Category = AbilityCategory.Buff;
            Conditions.Add(new BooleanCondition(SettingsManager.Instance.BuffCommandingShout));
            Conditions.Add(new DoesNotHaveStaminaBuffCondition());
        }
    }
}