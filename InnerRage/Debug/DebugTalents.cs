using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InnerRage.Core.Utilities;
using InnerRage.Core.Conditions.Talents;

namespace InnerRage.Debug
{
    class DebugTalents
    {
        /// <summary>
        /// Logs all learned Talent conditions.
        /// </summary>
        public void Debug()
        {
           Log.Diagnostics("Learned Avatar: "+ new TalentAvatarEnabledCondition().Satisfied());
           Log.Diagnostics("Learned BladeStorm: "+ new TalentBladeStormEnabledCondition().Satisfied());                                                                                                            
        }
    }
}
