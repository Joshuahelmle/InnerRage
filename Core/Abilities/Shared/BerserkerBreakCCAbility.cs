using InnerRage.Core.Conditions;
using InnerRage.Core.Managers;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared
{
    public class BerserkerBreakCCAbility : AbilityBase
    {
        public BerserkerBreakCCAbility() 
            : base(WoWSpell.FromId(SpellBook.SpellBerserkerRage), false, true)
        {
            Category = AbilityCategory.Buff;
            base.Conditions.Add(new BooleanCondition(SettingsManager.Instance.UseBerserkerBreakFear));
        }
    }
}