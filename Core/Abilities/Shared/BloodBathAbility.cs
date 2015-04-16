using System;
using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Talents;
using InnerRage.Core.Managers;
using Styx;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared
{
    /// <summary>
    ///     Uses Bloodbath with syncing on Enrage and Collosus Smash
    ///     TODO: Add Sync with Recklessness and Trinkets.
    /// </summary>
    internal class BloodBathAbility : AbilityBase
    {
        public BloodBathAbility()
            : base(WoWSpell.FromId(SpellBook.SpellBloodbath), false, true)
        {
            Category = AbilityCategory.Buff;
            Conditions.Add(new BooleanCondition(SettingsManager.Instance.TalentBloodBath));
            Conditions.Add(new ConditionOrList( // Bloodbath always? or on trinketprocc?
                new BooleanCondition(SettingsManager.Instance.TalentBloodbathAlways),
                new BooleanCondition(Me.HasAura(SettingsManager.Instance.TrinketProccAura))));
            //TODO: add logic for Recklessness base.Conditions.Add(CooldownTimeLeftMinCondition(WoWSpell.FromId(SpellBook.spellRecklessness),TimeSpan.FromSeconds(10)));
            Conditions.Add(new TalentBloodBathEnabledCondition());
            Conditions.Add(new ConditionSwitchTester(
                new IsInCurrentSpecializationCondition(WoWSpec.WarriorFury),
                //We are in Fury Specc, sync BloodBath with Enrage
                new DoesHaveEnrageUpCondition(),
                //We are not in Fury Specc, assume we are in Arms
                //TODO: really check if in Arms for future implementation of Defrotations.
                new ConditionAndList(
                    new RendIsTickingCondition(),
                    new CooldownTimeLeftMaxCondition(WoWSpell.FromId(SpellBook.SpellCollosusSmash),
                        TimeSpan.FromSeconds(4)))
                ));
        }
    }
}