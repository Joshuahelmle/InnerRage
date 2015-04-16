using InnerRage.Core.Conditions;
using InnerRage.Core.Managers;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared
{
    internal class BattleShoutAbility : AbilityBase
    {
        public BattleShoutAbility() : base(WoWSpell.FromId(SpellBook.SpellBattleshout), true, false)
        {
            Category = AbilityCategory.Buff;
            Conditions.Add(new BooleanCondition(SettingsManager.Instance.BuffBattleshout));
            Conditions.Add(new DoesNotHaveAttackPowerBuffCondition());
        }
    }
}