using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helpers
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
            string error = string.Empty;
            bool isValidMessage = IsValidKeyboardMessage(message, out error);
            if (!isValidMessage)
            {
                throw new ArgumentException(error);
            }

            var commands = message.ToUpper().Split(',');
            foreach (string command in commands)
            {
                //get separate keys from Ctrl-A-B
                var keys = command.Split('-').ToList();

                //keys to be released
                var keysToUp = new List<byte>();

                //send key down event
                for (int i = 0; i < keys.Count; i++)
                {
                    string key = keys[i];
                    byte keyCode = GetVirtualCodeForKey(key);

                    //if this key is contained in the command more than once, release it before the next press
                    if (keys.IndexOf(key) < i)
                    {
                        WinAPIMethods.keybd_event(keyCode,
                        (byte)WinAPIMethods.MapVirtualKey(keyCode, WinAPIMethods.MAPVK_VK_TO_VSC),
                        WinAPIMethods.KEYEVENTF_EXTENDEDKEY | WinAPIMethods.KEYEVENTF_KEYUP,
                        0);
                    }
                    else
                    {
                        keysToUp.Add(keyCode);
                    }

                    WinAPIMethods.keybd_event(keyCode,
                        (byte)WinAPIMethods.MapVirtualKey(keyCode, WinAPIMethods.MAPVK_VK_TO_VSC),
                        WinAPIMethods.KEYEVENTF_EXTENDEDKEY,
                        0);
                }

                //wait some time for processing
                Thread.Sleep(100);

                keysToUp.Reverse();
                //release key in reversed order
                foreach (var keyCode in keysToUp)
                {
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

        /// <summary>
        /// Returns string representation for virtual code.
        /// </summary>
        /// <param name="keyCode">Virtual code</param>
        /// <returns>String representation</returns>
        public static string GetKeyStringForVirtualCode(byte keyCode)
        {
            if (KeyToVKMapping.ContainsValue(keyCode))
            {
                return KeyToVKMapping.First(kvp => kvp.Value == keyCode).Key;
            }

            throw new ArgumentException("There is no mapping for this code!");
        }

        /// <summary>
        /// Validation for keyboard message
        /// </summary>
        /// <param name="message">Message to be validated</param>
        /// <param name="error">Out parameter - first error description, if no errors - empty string</param>
        /// <returns>True, if passed keyboard message is valid; False, otherwise</returns>
        public static bool IsValidKeyboardMessage(string message, out string error)
        {
            var commands = message.ToUpper().Split(',');
            foreach (string command in commands)
            {
                //get separate keys from Ctrl-A-B
                var keys = command.Split('-').ToList();
                foreach (var key in keys)
                {
                    if (!KeyToVKMapping.ContainsKey(key))
                    {
                        error = "There is no mapping for key = " + key;
                        return false;
                    }
                }
            }

            error = string.Empty;
            return true;
        }

        private static Dictionary<string, byte> KeyToVKMapping = new Dictionary<string, byte>
        {
            { "CTRL", (byte)Keys.ControlKey },
            { "ALT", (byte)Keys.Menu },
            { "SHIFT", (byte)Keys.ShiftKey },
            { "ESC", (byte)Keys.Escape },
            { "TAB", (byte)Keys.Tab },
            { "LWIN", (byte)Keys.LWin },
            { "RWIN", (byte)Keys.RWin },
            { "ENTER", (byte)Keys.Enter },
            { "BACKSPACE", (byte)Keys.Back },
            { "DOWN", (byte)Keys.Down },
            { "UP", (byte)Keys.Up },
            { "LEFT", (byte)Keys.Left },
            { "RIGHT", (byte)Keys.Right },
            { "INSERT", (byte)Keys.Insert },
            { "DELETE", (byte)Keys.Delete },
            { "HOME", (byte)Keys.Home },
            { "END", (byte)Keys.End },
            { "PAGEUP", (byte)Keys.PageUp },
            { "PAGEDOWN", (byte)Keys.PageDown },
            { "CAPSLOCK", (byte)Keys.CapsLock },
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
            { "B", (byte)Keys.B },
            { "C", (byte)Keys.C },
            { "D", (byte)Keys.D },
            { "E", (byte)Keys.E },
            { "F", (byte)Keys.F },
            { "G", (byte)Keys.G },
            { "H", (byte)Keys.H },
            { "I", (byte)Keys.I },
            { "J", (byte)Keys.J },
            { "K", (byte)Keys.K },
            { "L", (byte)Keys.L },
            { "M", (byte)Keys.M },
            { "N", (byte)Keys.N },
            { "O", (byte)Keys.O },
            { "P", (byte)Keys.P },
            { "Q", (byte)Keys.Q },
            { "R", (byte)Keys.R },
            { "S", (byte)Keys.S },
            { "T", (byte)Keys.T },
            { "U", (byte)Keys.U },
            { "V", (byte)Keys.V },
            { "W", (byte)Keys.W },
            { "X", (byte)Keys.X },
            { "Y", (byte)Keys.Y },
            { "Z", (byte)Keys.Z },            
            { "1", (byte)Keys.D1 },
            { "2", (byte)Keys.D2 },
            { "3", (byte)Keys.D3 },
            { "4", (byte)Keys.D4 },
            { "5", (byte)Keys.D5 },
            { "6", (byte)Keys.D6 },
            { "7", (byte)Keys.D7 },
            { "8", (byte)Keys.D8 },
            { "9", (byte)Keys.D9 },
            { "0", (byte)Keys.D0 },
            { "PLAY", (byte)Keys.MediaPlayPause },
            { "PREVIOUS", (byte)Keys.MediaPreviousTrack },
            { "NEXT", (byte)Keys.MediaNextTrack }
        };
    }
}
