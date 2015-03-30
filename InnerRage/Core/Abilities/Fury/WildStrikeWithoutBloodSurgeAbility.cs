using InnerRage.Core.Conditions;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Fury
{
    public class WildStrikeWithoutBloodSurgeAbility : AbilityBase
    {
        public WildStrikeWithoutBloodSurgeAbility() 
            : base(WoWSpell.FromId(SpellBook.SpellWildStrike), true, false)
        {
            base.Category = AbilityCategory.Combat;
            base.Conditions.Add(new DoesHaveEnrageUpCondition());
            base.Conditions.Add(new TargetNotInExecuteRangeCondition(MyCurrentTarget));
        }
    }
}