﻿using InnerRage.Core.Conditions;
using InnerRage.Core.Conditions.Talents;
using InnerRage.Core.Managers;
using Styx;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared.Racials
{
    class RacialOrcBloodFuryAbility : AbilityBase
    {
       public RacialOrcBloodFuryAbility()
            : base(WoWSpell.FromId(SpellBook.RacialOrcBloodFury), false, true)
        {
           base.Category = AbilityCategory.Buff;
           base.Conditions.Add(new IsRaceCondition(WoWRace.Orc));
           base.Conditions.Add(new BooleanCondition(SettingsManager.Instance.UseOrcRacial));
           base.Conditions.Add(new ConditionOrList(
                        new ConditionOrList(
                            new BloodBathIsUpCondition(),
                            new TalentBloodBathNotEnabledCondition())
                            ));
       }
       
        }
    }

