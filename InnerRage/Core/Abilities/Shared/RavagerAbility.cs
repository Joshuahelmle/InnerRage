using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Talents;
using InnerRage.Core.Managers;
using Styx;
using Styx.CommonBot;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace InnerRage.Core.Abilities.Shared
{
    class RavagerAbility : AbilityBase
    {
        /// <summary>
        /// Casts Ravager on current Target.
        /// Fury and Arms: Check if Bloodbath is learned, if so wait to sync.
        /// Only Arms: check if Cooldown of CollosusSmash is lower than 4 seconds, if so sync.
        /// TODO: Add Logic to thow it on the Ground.
        /// </summary>
        public RavagerAbility() 
            : base(WoWSpell.FromId(SpellBook.SpellRavager),true, true)
        {
            base.Category = AbilityCategory.Combat;
            base.Conditions.Add(new BooleanCondition(SettingsManager.Instance.TalentRavager));
            base.Conditions.Add(new TalentRavagerEnabledCondition());
            base.Conditions.Add(
                new ConditionSwitchTester( // Sync with BloodBath
                    new BooleanCondition(SettingsManager.Instance.TalentSyncRavager),
                    new BloodBathUpOrNotEnabledCondition()));
            base.Conditions.Add(new ConditionSwitchTester(// If we are in Armsspecc, test if Collosus Smash is up in 4 seconds, if so, wait with ravager to sync it
                new IsInCurrentSpecializationCondition(WoWSpec.WarriorArms),
                new SpellCoolDownLowerThanCondition(WoWSpell.FromId(SpellBook.SpellCollosusSmash),TimeSpan.FromSeconds(4))));
        }


        public async override Task<bool> CastOnTarget(WoWUnit target)
        {
           if(await CastManager.DropCast(this, target, this.Conditions)) return true;
            return false;
        }
    }
}
