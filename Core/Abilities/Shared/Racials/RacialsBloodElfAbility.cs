using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Glyphs;
using InnerRage.Core.Managers;
using Styx;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared.Racials
{
    class RacialsBloodElfAbility : AbilityBase
    {
        public RacialsBloodElfAbility()
            : base(WoWSpell.FromId(SpellBook.RacialBloodElfArcaneTorrent), false, true)
        {
            base.Category = AbilityCategory.Buff;
            base.Conditions.Add(new IsRaceCondition(WoWRace.BloodElf));
            base.Conditions.Add(new BooleanCondition(SettingsManager.Instance.UseBloodElfRacial));
            base.Conditions.Add(new ConditionSwitchTester(
                new GlyphUnendingRageCondition(),
                new MaxRageCondition(80),
                new MaxRageCondition(60)
            ));
                
        }
    }
}
