using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
