﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using InnerRage.Core.Abilities.Shared;
using Styx;
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
                StyxWoW.Overlay.AddToast((NoAoe ? "Aoe Mode Disabled" : "Aoe Mode Enabled"), 2000);
            });
           
            HotkeysManager.Register("Test Ability", Keys.G, ModifierKeys.Control, ret =>
            {
               AbilityManager.Instance.Cast<DieByTheSwordAbility>(StyxWoW.Me);

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
