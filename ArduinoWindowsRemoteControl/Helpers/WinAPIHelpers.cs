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
            var commands = message.ToUpper().Split(',');
            foreach (string command in commands)
            {
                //get separate keys from Ctrl-A-B
                var keys = command.Split('-');

                //send key down event
                foreach (var key in keys)
                {
                    byte keyCode = GetVirtualCodeForKey(key);
                    WinAPIMethods.keybd_event(keyCode, 
                        (byte)WinAPIMethods.MapVirtualKey(keyCode, WinAPIMethods.MAPVK_VK_TO_VSC), 
                        WinAPIMethods.KEYEVENTF_EXTENDEDKEY, 
                        0);
                }

                //wait some time for processing
                Thread.Sleep(100);

                //relsease key in reversed order
                foreach (var key in keys.Reverse())
                {
                    byte keyCode = GetVirtualCodeForKey(key);
                    WinAPIMethods.keybd_event(keyCode, 
                        (byte)WinAPIMethods.MapVirtualKey(keyCode, WinAPIMethods.MAPVK_VK_TO_VSC), 
                        WinAPIMethods.KEYEVENTF_EXTENDEDKEY | WinAPIMethods.KEYEVENTF_KEYUP, 
                        0);
                }
            }
        }

        /// <summary>
        /// Returns byte value for key
        /// </summary>
        /// <param name="key">Key to be mapped</param>
        /// <returns>Byte value</returns>
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
            { "TAB", (byte)Keys.Tab },
            { "F1", (byte)Keys.F1 },
            { "F2", (byte)Keys.F2 },
            { "F3", (byte)Keys.F3 },
            { "F4", (byte)Keys.F4 },
            { "F5", (byte)Keys.F5 },
            { "F6", (byte)Keys.F6 },
            { "F7", (byte)Keys.F7 },
            { "F8", (byte)Keys.F8 },
            { "F9", (byte)Keys.F9 },
            { "F10", (byte)Keys.F10 },
            { "F11", (byte)Keys.F11 },
            { "F12", (byte)Keys.F12 },
            { "A", (byte)Keys.A },
            { "N", (byte)Keys.N },
            { "PLAY", (byte)Keys.MediaPlayPause }
        };
    }
}
