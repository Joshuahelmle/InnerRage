using InnerRage.Core.Conditions.Auras;
using InnerRage.Core.Conditions.Talents;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared
{
    internal class ExecuteWithSuddenDeathAbility : AbilityBase
    {
        public ExecuteWithSuddenDeathAbility()
            : base(WoWSpell.FromId(SpellBook.SpellExecute), true, false)
        {
            Category = AbilityCategory.Combat;
            Conditions.Add(new TalentSuddenDeathEnabledCondition());
            Conditions.Add(new HasSuddenDeathProccCondition());
        }
    }
}