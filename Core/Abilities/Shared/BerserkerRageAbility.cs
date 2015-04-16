using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Auras;
using Styx;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared
{
    internal class BerserkerRageAbility : AbilityBase
    {
        public BerserkerRageAbility() : base(WoWSpell.FromId(SpellBook.SpellBerserkerRage), false, true)
        {
            Category = AbilityCategory.Buff;
            // base.Conditions.Add(new BooleanCondition(Settings.UseBerserkerBreakSap));

            Conditions.Add(new ConditionAndList(
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