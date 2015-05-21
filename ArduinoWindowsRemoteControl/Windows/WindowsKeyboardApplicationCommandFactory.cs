using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoWindowsRemoteControl.Windows
{
    /// <summary>
    /// Factory creates WindowsKeyboardApplicationCommand objects
    /// </summary>
    public class WindowsKeyboardApplicationCommandFactory : IApplicationCommandFactory
    {
        #region Private Fields

        private ICommandFactory _commandFactory;

        #endregion

        #region Constructor

        public WindowsKeyboardApplicationCommandFactory(ICommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Create WindowsKeyboardApplicationCommand object
        /// </summary>
        /// <param name="applicationName">Application name</param>
        /// <param name="remoteCommand">Remote command</param>
        /// <param name="command">Command specification</param>
        /// <returns>IApplicationCommand instance</returns>
        public IApplicationCommand Create(string applicationName, RemoteCommand remoteCommand, string command)
        {
            return new WindowsKeyboardApplicationCommand(applicationName, remoteCommand, _commandFactory.Create(command));
        }

        #endregion
    }
}
