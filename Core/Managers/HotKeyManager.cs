using System.Windows.Forms;
using System.Windows.Media;
using InnerRage.Core.Abilities.Shared;
using InnerRage.Core.Routines;
using Styx;
using Styx.Common;
using Styx.Patchables;
using Styx.WoWInternals;

namespace InnerRage.Core.Managers
{
    internal class HotKeyManager
    {
        public static bool NoAoe { get; set; }
        public static bool CooldownsOn { get; set; }
        public static bool ManualOn { get; set; }
        public static bool KeysRegistered { get; set; }
        public static bool AlreadyQueued { get; set; }

        #region [Method] - Hotkey Registration

        public static void RegisterHotKeys()
        {
            if (KeysRegistered)
                return;
            HotkeysManager.Register("noAoe", Keys.V, ModifierKeys.Alt, ret =>
            {
                NoAoe = !NoAoe;
                StyxWoW.Overlay.AddToast((NoAoe ? "Aoe Mode Disabled" : "Aoe Mode Enabled"), 2000);
            });

            HotkeysManager.Register("Test Ability", Keys.G, ModifierKeys.Control,
                ret =>
                {
                    RallyingCryAbility cast = new RallyingCryAbility();
                    cast.Conditions.Clear();
                    cast.initBaseConditions();
                    AlreadyQueued = Combat.AbilityQueue.Contains(cast);
                    if (!AlreadyQueued)
                    {
                        Combat.AbilityQueue.Add(cast);
                        StyxWoW.Overlay.AddToast("Queued Rallying Cry", 2000);
                    }
                    else
                    {
                        StyxWoW.Overlay.AddToast("Rallying Cry already queued up", 2000);
                        Combat.AbilityQueueDone.Add(cast);
                    }
                });

            HotkeysManager.Register("Debug Mode", Keys.NumPad0, ModifierKeys.Alt, ret =>
            {
                Main.Debug = !Main.Debug;
                StyxWoW.Overlay.AddToast((Main.Debug ? "Debug in Log Activated" : "Debug in Log deactivated"), 2000);
            });
        }

        #endregion

        #region [Method] - Hotkey Removal

        public static void RemoveHotkeys()
        {
            if (!KeysRegistered)
                return;
            HotkeysManager.Unregister("noAoe");
            NoAoe = false;
            KeysRegistered = false;
            Lua.DoString(@"print('Hotkeys: \124cFFE61515 Removed!')");
            Logging.Write(Colors.OrangeRed, "Hotkeys: Removed!");
        }

        #endregion
    }
}