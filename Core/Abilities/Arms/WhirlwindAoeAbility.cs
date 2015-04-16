using System.Threading.Tasks;
using InnerRage.Core.Conditions;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace InnerRage.Core.Abilities.Arms
{
    internal class WhirlwindAoeAbility : AbilityBase
    {
        public WhirlwindAoeAbility() : base(WoWSpell.FromId(SpellBook.SpellWhirlwind), true, false)
        {
            Category = AbilityCategory.Combat;
        }

        public override async Task<bool> CastOnTarget(WoWUnit target)
        {
            Conditions.Clear();
            Conditions.Add(new InMeeleRangeCondition());
            if (MustWaitForGlobalCooldown) Conditions.Add(new IsOffGlobalCooldownCondition());
            if (MustWaitForSpellCooldown) Conditions.Add(new SpellIsNotOnCooldownCondition(Spell));
            Conditions.Add(new InMeeleRangeCondition());
            Conditions.Add(new TargetNotInExecuteRangeCondition(Target));
            return await base.CastOnTarget(target);
        }
    }
}