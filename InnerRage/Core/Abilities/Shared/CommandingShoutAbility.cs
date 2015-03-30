using InnerRage.Core.Conditions;
using InnerRage.Core.Managers;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared
{
    class CommandingShoutAbility : AbilityBase
    {

        public CommandingShoutAbility() : base(WoWSpell.FromId(SpellBook.SpellCommandingShout), true, mustWaitForSpellCooldown: false)
        {
            base.Category = AbilityCategory.Buff;
            base.Conditions.Add(new BooleanCondition(SettingsManager.Instance.BuffCommandingShout));
            base.Conditions.Add(new DoesNotHaveStaminaBuffCondition());
           
        }
    }
}