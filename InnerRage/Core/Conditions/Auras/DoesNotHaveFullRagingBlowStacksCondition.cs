using Styx;

namespace InnerRage.Core.Conditions.Auras
{
    class DoesNotHaveFullRagingBlowStacksCondition: ICondition
    {
        public bool Satisfied()
        {
            if (StyxWoW.Me.HasAura(SpellBook.AuraRagingBlow))
            {
                return StyxWoW.Me.GetAuraById(SpellBook.AuraRagingBlow).StackCount < 2;
            }
            else return false;
        }
    }
}
