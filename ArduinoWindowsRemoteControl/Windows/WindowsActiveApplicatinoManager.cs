using ArduinoWindowsRemoteControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoWindowsRemoteControl.Windows
{
    /// <summary>
    /// Represents manager thta gets remotes command and processe it
    /// </summary>
    public class WindowsActiveApplicatinoManager : ICommandManager
    {
        #region Private Fields

        private IApplicationCommandFactory _appCommandFactory;
        private ICommandDispatcher _commandDispatcher;

        #endregion

        #region Constructor

        public WindowsActiveApplicatinoManager(IApplicationCommandFactory appCommandFactory, ICommandDispatcher commandDispatcher)
        {
            _appCommandFactory = appCommandFactory;
            _commandDispatcher = commandDispatcher;
        }

        #endregion

        public bool AddNewCommandForApplication(string applicationName, RemoteCommand remoteCommand, string command)
        {
            return _commandDispatcher.AddApplicationCommand(_appCommandFactory.Create(applicationName, remoteCommand, command));
        }

        public Dictionary<RemoteCommand, IApplicationCommand> GetCommandsForApplication(string applicationName)
        {
            return _commandDispatcher.GetCommandsForApplication(applicationName);
        }

        public List<string> GetApplicationNames()
        {
            return _commandDispatcher.GetApplicationNames();
        }
    }
}
