using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Talents;
using InnerRage.Core.Managers;
using Styx;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared.Racials
{
    internal class RacialsTrollBerserkingAbility : AbilityBase
    {
        public RacialsTrollBerserkingAbility()
            : base(WoWSpell.FromId(SpellBook.RacialTrollBerserking), false, true)
        {
            Category = AbilityCategory.Buff;
            Conditions.Add(new IsRaceCondition(WoWRace.Troll));
            Conditions.Add(new BooleanCondition(SettingsManager.Instance.UseTrollRacial));
            Conditions.Add(new ConditionOrList(
                new ConditionOrList(
                    new BloodBathIsUpCondition(),
                    new TalentBloodBathNotEnabledCondition()),
                new RecklessnessIsUpCondition()));
        }
    }
}