using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Talents;
using InnerRage.Core.Managers;
using Styx;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared.Racials
{
    class RacialsTrollBerserkingAbility :AbilityBase
    {
        public RacialsTrollBerserkingAbility() 
            : base(WoWSpell.FromId(SpellBook.RacialTrollBerserking),false, true)
        {
            base.Category = AbilityCategory.Buff;
            base.Conditions.Add(new IsRaceCondition(WoWRace.Troll));
            base.Conditions.Add(new BooleanCondition(SettingsManager.Instance.UseTrollRacial));
            base.Conditions.Add(new ConditionOrList(
                        new ConditionOrList(
                            new BloodBathIsUpCondition(),
                            new TalentBloodBathNotEnabledCondition()),
                            new RecklessnessIsUpCondition()));
        }
    }
}
