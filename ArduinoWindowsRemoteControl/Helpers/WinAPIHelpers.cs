using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoWindowsRemoteControl.Helpers
{
    public static class WinAPIHelpers
    {
        /// <summary>
        /// Returns current active application name
        /// </summary>
        /// <returns>Current active application name</returns>
        public static string GetActiveApplicationName()
        {
            IntPtr hWnd = WinAPIMethods.GetForegroundWindow();
            uint procId = 0;
            WinAPIMethods.GetWindowThreadProcessId(hWnd, out procId);
            var process = Process.GetProcessById((int)procId);

            return process.ProcessName;
        }

        /// <summary>
        /// Sends key presses to current active application.
        /// Format: Ctrl-A-B,Shift-C,a,f
        /// </summary>
        /// <param name="message">Sequence of keys to be sent</param>
        public static void SendKeyboardMessage(string message)
        {
            var commands = message.Split(',');
            foreach (string command in commands)
            {
                //get separate keys from Ctrl-A-B
                var keys = command.Split('-');
                foreach (var key in keys)
                {
                    byte keyCode = GetVirtualCodeForKey(key);
                    WinAPIMethods.keybd_event(keyCode, (byte)WinAPIMethods.MapVirtualKey(keyCode, WinAPIMethods.MAPVK_VK_TO_VSC), WinAPIMethods.KEYEVENTF_EXTENDEDKEY, 0);
                }
                Thread.Sleep(100);
                foreach (var key in keys.Reverse())
                {
                    byte keyCode = GetVirtualCodeForKey(key);
                    WinAPIMethods.keybd_event(keyCode, (byte)WinAPIMethods.MapVirtualKey(keyCode, WinAPIMethods.MAPVK_VK_TO_VSC), WinAPIMethods.KEYEVENTF_EXTENDEDKEY | WinAPIMethods.KEYEVENTF_KEYUP, 0);
                }
            }
        }

        public static byte GetVirtualCodeForKey(string key)
        {
            return KeyToVKMapping[key];
        }

        private static Dictionary<string, byte> KeyToVKMapping = new Dictionary<string, byte>
        {
            { "CTRL", (byte)Keys.ControlKey },
            { "ALT", (byte)Keys.Menu },
            { "SHIFT", (byte)Keys.ShiftKey },
            { "ESC", (byte)Keys.Escape },
            { "F4", (byte)Keys.F4 },
            { "A", (byte)Keys.A },
            { "N", (byte)Keys.N }
        };
    }
}
