using InnerRage.Core.Conditions;
using InnerRage.Core.Managers;
using Styx;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared.Racials
{
    internal class RacialHumanAbility : AbilityBase
    {
        public RacialHumanAbility()
            : base(WoWSpell.FromId(SpellBook.RacialHumanEveryManForHimself), false, true)
        {
            Category = AbilityCategory.Buff;
            Conditions.Add(new BooleanCondition(StyxWoW.Me.Race == WoWRace.Human));
            Conditions.Add(new BooleanCondition(SettingsManager.Instance.UseHumanRacial));
        }
    }
}