using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Auras;
using InnerRage.Core.Managers;
using InnerRage.Core.Utilities;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace InnerRage.Core.Abilities.Arms
{
    class RendAbility : AbilityBase
    {
        public RendAbility() 
            : base(WoWSpell.FromId(SpellBook.SpellRend), true, false)
        {
            base.Category = AbilityCategory.Combat;
            

        }


        public override Task<bool> CastOnTarget(WoWUnit target)
        {
             base.Conditions.Clear();
            if (MustWaitForGlobalCooldown) this.Conditions.Add(new IsOffGlobalCooldownCondition());
            if (MustWaitForSpellCooldown) this.Conditions.Add(new SpellIsNotOnCooldownCondition(this.Spell));
            base.Conditions.Add(new BooleanCondition(Target != null));
            base.Conditions.Add(new ConditionOrList(
                new AuraMaxRemaningTimeCondition(TimeSpan.FromSeconds(4.5), Spell, Target),
                new DoesNotHaveAuraUpCondition(Target, Spell)));
            base.Conditions.Add(new ConditionOrList(
                new TargetNotInExecuteRangeCondition(Target),
                new DoesNotHaveAuraUpCondition(Target, WoWSpell.FromId(SpellBook.SpellCollosusSmash))));
            //Aoe Logic
            base.Conditions.Add(new ConditionSwitchTester(
                new BooleanCondition(Me.KnowsSpell(SpellBook.SpellTasteForBlood)),
                new BooleanCondition(UnitManager.Instance.LastKnownBleedingEnemies.Count < 4),
                new BooleanCondition(UnitManager.Instance.LastKnownBleedingEnemies.Count < 3)));
           return base.CastOnTarget(Target);
       
           
        }
    }
}
