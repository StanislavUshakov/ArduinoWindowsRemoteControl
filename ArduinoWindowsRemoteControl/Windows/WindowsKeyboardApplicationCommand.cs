using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoWindowsRemoteControl.Windows
{
    /// <summary>
    /// Represents connection betwenn remote command, application (to which command is applied) 
    /// and command itself (via ICommand interface)
    /// </summary>
    public class WindowsKeyboardApplicationCommand : IApplicationCommand
    {
        #region Private Fields

        private string _appName;
        private RemoteCommand _remoteCommand;
        private ICommand _command;

        #endregion

        #region Constructor

        public WindowsKeyboardApplicationCommand(string applicationName, RemoteCommand remoteCommand, ICommand command)
        {
            _appName = applicationName;
            _remoteCommand = remoteCommand;
            _command = command;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the associated Application name
        /// </summary>
        public string ApplicationName
        {
            get { return _appName; }
        }

        /// <summary>
        /// Gets the associated remote command
        /// </summary>
        public RemoteCommand RemoteCommand
        {
            get { return _remoteCommand; }
        }

        /// <summary>
        /// Gets the associated ICommand object
        /// </summary>
        public ICommand Command
        {
            get { return _command; }
        }

        #endregion

        #region Public Methods

        public void Do()
        {
            _command.Do();
        }

        #endregion
    }
}
