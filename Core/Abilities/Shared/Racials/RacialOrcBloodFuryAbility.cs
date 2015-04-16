using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Talents;
using InnerRage.Core.Managers;
using Styx;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared.Racials
{
    internal class RacialOrcBloodFuryAbility : AbilityBase
    {
        public RacialOrcBloodFuryAbility()
            : base(WoWSpell.FromId(SpellBook.RacialOrcBloodFury), false, true)
        {
            Category = AbilityCategory.Buff;
            Conditions.Add(new IsRaceCondition(WoWRace.Orc));
            Conditions.Add(new BooleanCondition(SettingsManager.Instance.UseOrcRacial));
            Conditions.Add(new ConditionOrList(
                new ConditionOrList(
                    new BloodBathIsUpCondition(),
                    new TalentBloodBathNotEnabledCondition())
                ));
        }
    }
}