using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Auras;
using InnerRage.Core.Conditions.Talents;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Protection
{
    public class HeroicStrikeAbility : AbilityBase
    {
        public HeroicStrikeAbility() 
            : base(WoWSpell.FromId(SpellBook.SpellHeroicStrike), false, true)
        {
            Category = AbilityCategory.Combat;
            Conditions.Add(new ConditionOrList(
                new TargetAuraUpCondition(Me, WoWSpell.FromId(SpellBook.AuraUltimatum)),
                new MinRageCondition(110),
                new ConditionAndList(
                    new TalentUnyieldingStrikesEnabledCondition(),
                    new DoesHaveMinAuraStacksCondition(WoWSpell.FromId(SpellBook.AuraUnyieldingStrikes), 6))));
        }
    }
}