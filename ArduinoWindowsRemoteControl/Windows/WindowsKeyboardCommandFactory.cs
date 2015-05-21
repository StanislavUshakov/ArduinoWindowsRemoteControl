using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoWindowsRemoteControl.Windows
{
    /// <summary>
    /// Factory creates WindowsKeyboardCommand objects
    /// </summary>
    public class WindowsKeyboardCommandFactory : ICommandFactory
    {
        /// <summary>
        /// Create WindowsKeyboardCommand object
        /// </summary>
        /// <param name="command">Command representation</param>
        /// <returns>WindowsKeyboardCommand object</returns>
        public ICommand Create(string command)
        {
            return new WindowsKeyboardCommand(command);
        }
    }
}
