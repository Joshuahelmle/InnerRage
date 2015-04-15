using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnerRage.Core.Conditions;
using InnerRage.Core.Managers;
using Styx;
using Styx.WoWInternals;

namespace InnerRage.Core.Abilities.Shared.Racials
{
    class RacialHumanAbility : AbilityBase
    {
        public RacialHumanAbility() 
            : base(WoWSpell.FromId(SpellBook.RacialHumanEveryManForHimself), false, true)
        {
            base.Category = AbilityCategory.Buff;
            base.Conditions.Add(new BooleanCondition(StyxWoW.Me.Race == WoWRace.Human));
            base.Conditions.Add(new BooleanCondition(SettingsManager.Instance.UseHumanRacial));
        }
    }
}
