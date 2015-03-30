using Styx;

namespace InnerRage.Core.Conditions
{
    class BloodBathIsUpCondition : ICondition
    {
        public bool Satisfied()
        {
            return StyxWoW.Me.HasAura(SpellBook.AuraBloodBath);
        }
    }
}
