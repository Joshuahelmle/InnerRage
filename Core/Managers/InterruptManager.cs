using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Media;
using InnerRage.Core.Abilities.Shared;
using Styx;
using Styx.WoWInternals.WoWObjects;
using InnerRage.Core.Utilities;

namespace InnerRage.Core.Managers
{
    /// <summary>
    /// Provides the management of interrupt timers, targets, and methods.
    /// </summary>
    public static class InterruptManager
    {
        private static Stopwatch _interruptTimer = new Stopwatch();
        
        private static LocalPlayer Me { get { return StyxWoW.Me; } }
        private static WoWUnit MyCurrentTarget { get { return Me.CurrentTarget; } }
        private static AbilityManager Abilities { get { return AbilityManager.Instance; } }

        /// <summary>
        /// <para> Checks the target to determine if it is a candidate for interrupting the current spell.</para>
        /// <para>If the target is a candidate, it will attempt to interrupt based on the condition of the settings and available interrupt abilities.</para>
        /// </summary>
        /// <returns>Returns true on a successful interrupt</returns>
        public static async Task<bool> CheckMyTarget()
        {
            if(Main.Debug) Log.Diagnostics("in CheckMyTarget() call:");
            if (Me.CanActuallyInterruptCurrentTargetSpellCast(SettingsManager.Instance.InterruptDelay))
            {
                if (Main.Debug) Log.Diagnostics("in CheckMyTarget() call:");
                _interruptTimer.Start();

                if (_interruptTimer.ElapsedMilliseconds >= SettingsManager.Instance.InterruptDelay)
                {


                    if (await Abilities.Cast<Pummel>(MyCurrentTarget))
                    {
                        _interruptTimer.Reset();
                        return ReturnSuccessWithMessage(_interruptTimer.ElapsedMilliseconds);
                    }





                    return false;
                }
                return false;
            }
            return false;
        }




        /// <summary>
        /// Helper method to return a success message back to the caller.
        /// </summary>
        private static bool ReturnSuccessWithMessage(double elapsedMs)
        {
            Log.AppendLine(string.Format("Interrupted {0} after {1} milliseconds.", MyCurrentTarget.SafeName, elapsedMs), Colors.Gold);

            _interruptTimer.Reset();
           
            return true;
        }
    }
}
