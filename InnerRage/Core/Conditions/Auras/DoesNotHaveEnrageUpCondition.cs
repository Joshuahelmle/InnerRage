using InnerRage.Core.Utilities;
using Styx;

namespace InnerRage.Core.Conditions
{
    class DoesNotHaveEnrageUpCondition :ICondition
    {
        public bool Satisfied()
        {
            if (Main.Debug) { 
            if(!StyxWoW.Me.HasAura(SpellBook.AuraEnrage)) Log.Diagnostics("Enrage is Not Up, should cast it now.");
            }
            return !StyxWoW.Me.HasAura(SpellBook.AuraEnrage);
        }
    }
}
