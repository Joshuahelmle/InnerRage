using InnerRage.Core.Conditions;
using InnerRage.Core.Managers;
using Styx.Helpers;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared
{
    class BattleShoutAbility : AbilityBase
    {
        public BattleShoutAbility() : base(WoWSpell.FromId(SpellBook.SpellBattleshout) ,true, false)
        {
            base.Category = AbilityCategory.Buff;
            base.Conditions.Add(new BooleanCondition(SettingsManager.Instance.BuffBattleshout));
            base.Conditions.Add(new DoesNotHaveAttackPowerBuffCondition());
        }
    }
}
