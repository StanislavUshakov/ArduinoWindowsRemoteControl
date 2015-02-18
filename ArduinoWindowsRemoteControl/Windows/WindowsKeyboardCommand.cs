using ArduinoWindowsRemoteControl.Helpers;
using ArduinoWindowsRemoteControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoWindowsRemoteControl.Windows
{
    public class WindowsKeyboardCommand : ICommand
    {
        #region Private Fields

        private string _keyboardcommand;

        #endregion

        #region Constructor

        public WindowsKeyboardCommand(string keyboardCommand)
        {
            _keyboardcommand = keyboardCommand;
        }

        #endregion

        #region Public Methods

        public void Do()
        {
            WinAPIHelpers.SendKeyboardMessage(_keyboardcommand);
        }

        public override string ToString()
        {
            return _keyboardcommand;
        }

        #endregion
    }
}
