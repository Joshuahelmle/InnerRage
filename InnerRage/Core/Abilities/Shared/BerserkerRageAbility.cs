using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Auras;
using Styx;
using Styx.Helpers;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared
{
    internal class BerserkerRageAbility : AbilityBase
    {
        public BerserkerRageAbility() : base(WoWSpell.FromId(SpellBook.SpellBerserkerRage), false, true)
        {
            base.Category = AbilityCategory.Buff;
            // base.Conditions.Add(new BooleanCondition(Settings.UseBerserkerBreakFear));
            // base.Conditions.Add(new BooleanCondition(Settings.UseBerserkerBreakSap));
            
            base.Conditions.Add(new ConditionAndList(
                new IsInCurrentSpecializationCondition(WoWSpec.WarriorFury),
                new ConditionOrList(
                new DoesNotHaveEnrageUpCondition(),
                new ConditionAndList(
                    new LastSpellCastBloodThirstCondition(),
                    new DoesNotHaveFullRagingBlowStacksCondition())
                )
                ));
        }
    }
}