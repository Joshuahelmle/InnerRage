using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using Styx.Common;
using Styx.WoWInternals;

namespace InnerRage.Core.Managers
{
    internal class HotKeyManager
    {
        public static bool NoAoe { get; set; }
        public static bool CooldownsOn { get; set; }
        public static bool ManualOn { get; set; }
        public static bool KeysRegistered { get; set; }

        #region [Method] - Hotkey Registration

        public static void RegisterHotKeys()
        {
            if (KeysRegistered)
                return;
            HotkeysManager.Register("noAoe", Keys.V, ModifierKeys.Alt, ret =>
            {
                NoAoe = !NoAoe;
                Lua.DoString(NoAoe
                    ? @"print('AoE Mode: \124cFF15E61C No AoE allowed!')"
                    : @"print('AoE Mode: \124cFFE61515 AoE is allowed!')");
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
