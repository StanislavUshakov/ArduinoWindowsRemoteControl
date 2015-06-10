using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoWindowsRemoteControl.Windows
{
    /// <summary>
    /// Represents manager that gets remotes command and processe it
    /// </summary>
    public class WindowsActiveApplicationManager : ICommandManager
    {
        #region Private Fields

        private IApplicationCommandFactory _appCommandFactory;
        private ICommandDispatcher _commandDispatcher;
        private IRemoteInputDevice _arduinoDevice;

        #endregion

        #region Constructor

        public WindowsActiveApplicationManager(IApplicationCommandFactory appCommandFactory, ICommandDispatcher commandDispatcher, IRemoteInputDevice arduinoDevice)
        {
            _appCommandFactory = appCommandFactory;
            _commandDispatcher = commandDispatcher;
            _arduinoDevice = arduinoDevice;
            _arduinoDevice.CommandReceived += _commandDispatcher.DispatchCommand;
        }

        #endregion

        #region ICommandManager Members

        public bool AddNewCommandForApplication(string applicationName, RemoteCommand remoteCommand, string command)
        {
            return _commandDispatcher.AddApplicationCommand(_appCommandFactory.Create(applicationName, remoteCommand, command));
        }

        public bool DeleteApplicationCommand(IApplicationCommand applicationCommand)
        {
            return _commandDispatcher.DeleteApplicationCommand(applicationCommand);
        }

        public List<IApplicationCommand> GetCommandsForApplication(string applicationName)
        {
            return _commandDispatcher.GetCommandsForApplication(applicationName).Values.ToList();
        }

        public List<string> GetApplicationNames()
        {
            return _commandDispatcher.GetApplicationNames();
        }

        public void DeleteAllCommands()
        {
            _commandDispatcher.DeleteAllCommands();
        }

        public IRemoteInputDevice InputDeice
        {
            get
            {
                return _arduinoDevice;
            }
        }

        #endregion
    }
}
