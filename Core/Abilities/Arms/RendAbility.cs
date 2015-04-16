using System;
using System.Threading.Tasks;
using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Auras;
using InnerRage.Core.Managers;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace InnerRage.Core.Abilities.Arms
{
    internal class RendAbility : AbilityBase
    {
        public RendAbility()
            : base(WoWSpell.FromId(SpellBook.SpellRend), true, false)
        {
            Category = AbilityCategory.Combat;
        }

        public override async Task<bool> CastOnTarget(WoWUnit target)
        {
            Conditions.Clear();
            if (MustWaitForGlobalCooldown) Conditions.Add(new IsOffGlobalCooldownCondition());
            if (MustWaitForSpellCooldown) Conditions.Add(new SpellIsNotOnCooldownCondition(Spell));
            Conditions.Add(new BooleanCondition(Target != null));
            Conditions.Add(new InMeeleRangeCondition());
            Conditions.Add(new ConditionOrList(
                new AuraMaxRemaningTimeCondition(TimeSpan.FromSeconds(4.5), Spell, target),
                new DoesNotHaveAuraUpCondition(Target, Spell)));
            Conditions.Add(new ConditionOrList(
                new TargetNotInExecuteRangeCondition(Target),
                new DoesNotHaveAuraUpCondition(Target, WoWSpell.FromId(SpellBook.SpellCollosusSmash))));
            //Aoe Logic
            Conditions.Add(new ConditionSwitchTester(
                new BooleanCondition(Me.KnowsSpell(SpellBook.SpellTasteForBlood)),
                new BooleanCondition(UnitManager.Instance.LastKnownBleedingEnemies.Count < 4),
                new BooleanCondition(UnitManager.Instance.LastKnownBleedingEnemies.Count < 3)));
            return await base.CastOnTarget(Target);
        }
    }
}