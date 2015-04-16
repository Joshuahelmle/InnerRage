using InnerRage.Core.Conditions;
using InnerRage.Core.Managers;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared
{
    public class Pummel : AbilityBase
    {
        public Pummel() : base(WoWSpell.FromId(SpellBook.SpellPummel), false, true)
        {
            Category = AbilityCategory.Combat;
            Conditions.Add(new BooleanCondition(SettingsManager.Instance.InterruptPummel));
        }
    }
}