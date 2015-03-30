using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Talents;
using InnerRage.Core.Managers;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared
{
    public class ShockWaveAbility : AbilityBase
    {

        /// <summary>
        /// ShockWave
        /// </summary>
        public ShockWaveAbility()
            : base(WoWSpell.FromId(SpellBook.SpellShockwave), true, true)
        {
            base.Category = AbilityCategory.Combat;
            base.Conditions.Add(new BooleanCondition(SettingsManager.Instance.TalentShockWave));
            base.Conditions.Add(new TalentUnquenchableThirstNotEnabledCondition());  //Never ever use Shockwave in conjunction with unquenchable thirst, this is a DPS LOSS
            base.Conditions.Add(new TalentShockWaveEnabledCondition());
        }
    }
}