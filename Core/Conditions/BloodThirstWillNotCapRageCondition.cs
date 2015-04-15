using Styx;

namespace InnerRage.Core.Conditions
{

    /// <summary>
    /// Used to determine if the rage will be capped after casting.
    /// </summary>
    class BloodThirstWillNotCapRageCondition: ICondition
    {
       

        public bool Satisfied()
        {
            return StyxWoW.Me.CurrentRage + 40 < StyxWoW.Me.MaxRage;
        }
    }
}
