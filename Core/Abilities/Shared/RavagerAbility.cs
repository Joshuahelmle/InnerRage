using System;
using System.Threading.Tasks;
using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Talents;
using InnerRage.Core.Managers;
using Styx;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;

namespace InnerRage.Core.Abilities.Shared
{
    internal class RavagerAbility : AbilityBase
    {
        /// <summary>
        ///     Casts Ravager on current Target.
        ///     Fury and Arms: Check if Bloodbath is learned, if so wait to sync.
        ///     Only Arms: check if Cooldown of CollosusSmash is lower than 4 seconds, if so sync.
        ///     TODO: Add Logic to thow it on the Ground.
        /// </summary>
        public RavagerAbility()
            : base(WoWSpell.FromId(SpellBook.SpellRavager), true, true)
        {
            Category = AbilityCategory.Combat;
        }

        public override async Task<bool> CastOnTarget(WoWUnit target)
        {
            Conditions.Clear();
            if (MustWaitForGlobalCooldown) Conditions.Add(new IsOffGlobalCooldownCondition());
            if (MustWaitForSpellCooldown) Conditions.Add(new SpellIsNotOnCooldownCondition(Spell));
            Conditions.Add(new BooleanCondition(Me.CurrentTarget != null));
            Conditions.Add(new BooleanCondition(SettingsManager.Instance.TalentRavager));
            Conditions.Add(new TalentRavagerEnabledCondition());
            Conditions.Add(
                new ConditionSwitchTester( // Sync with BloodBath
                    new BooleanCondition(SettingsManager.Instance.TalentSyncRavager),
                    new BloodBathUpOrNotEnabledCondition()));
            Conditions.Add(new ConditionSwitchTester( // If we are in Armsspecc, test if Collosus Smash is up in 4 seconds, if so, wait with ravager to sync it
                new IsInCurrentSpecializationCondition(WoWSpec.WarriorArms),
                new SpellCoolDownLowerThanCondition(WoWSpell.FromId(SpellBook.SpellCollosusSmash),
                    TimeSpan.FromSeconds(4))));
            Conditions.Add(new ConditionSwitchTester(
                new BooleanCondition(SettingsManager.Instance.RavagerOnlyOnBoss),
                new OnlyOnBossCondition()));
            Conditions.Add(new ConditionSwitchTester(
                new BooleanCondition(SettingsManager.Instance.RavagerOnlyOnAoECount),
                new BooleanCondition(UnitManager.Instance.LastKnownSurroundingEnemies.Count >=
                                     SettingsManager.Instance.RavagerAoeCount)));
            if (await CastManager.DropCast(this, target, Conditions)) return true;
            return false;
        }
    }
}