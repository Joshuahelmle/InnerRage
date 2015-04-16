using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Glyphs;
using InnerRage.Core.Managers;
using Styx;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared.Racials
{
    internal class RacialsBloodElfAbility : AbilityBase
    {
        public RacialsBloodElfAbility()
            : base(WoWSpell.FromId(SpellBook.RacialBloodElfArcaneTorrent), false, true)
        {
            Category = AbilityCategory.Buff;
            Conditions.Add(new IsRaceCondition(WoWRace.BloodElf));
            Conditions.Add(new BooleanCondition(SettingsManager.Instance.UseBloodElfRacial));
            Conditions.Add(new ConditionSwitchTester(
                new GlyphUnendingRageCondition(),
                new MaxRageCondition(80),
                new MaxRageCondition(60)
                ));
        }
    }
}