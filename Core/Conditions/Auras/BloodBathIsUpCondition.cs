using Styx;

namespace InnerRage.Core.Conditions
{
    internal class BloodBathIsUpCondition : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.HasAura(SpellBook.AuraBloodBath);
        }
    }
}