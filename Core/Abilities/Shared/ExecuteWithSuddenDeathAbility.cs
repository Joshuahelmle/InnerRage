using InnerRage.Core.Conditions.Auras;
using InnerRage.Core.Conditions.Talents;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared
{
    class ExecuteWithSuddenDeathAbility : AbilityBase
    {
        public ExecuteWithSuddenDeathAbility() 
            : base(WoWSpell.FromId(SpellBook.SpellExecute), true, false)
        {
            base.Category = AbilityCategory.Combat;
            base.Conditions.Add(new TalentSuddenDeathEnabledCondition());
            base.Conditions.Add(new HasSuddenDeathProccCondition());
        }
    }
}
