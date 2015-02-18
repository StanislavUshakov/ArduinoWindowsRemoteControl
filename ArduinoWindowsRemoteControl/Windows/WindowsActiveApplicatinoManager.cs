﻿using ArduinoWindowsRemoteControl.Interfaces;
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
    public class WindowsActiveApplicatinoManager : ICommandManager
    {
        #region Private Fields

        private IApplicationCommandFactory _appCommandFactory;
        private ICommandDispatcher _commandDispatcher;
        private IArduinoDevice _arduinoDevice;

        #endregion

        #region Constructor

        public WindowsActiveApplicatinoManager(IApplicationCommandFactory appCommandFactory, ICommandDispatcher commandDispatcher, IArduinoDevice arduinoDevice)
        {
            _appCommandFactory = appCommandFactory;
            _commandDispatcher = commandDispatcher;
            _arduinoDevice = arduinoDevice;
            _arduinoDevice.OnCommandReceived += _commandDispatcher.DispatchCommand;
        }

        #endregion

        #region Public Methods

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

        #endregion
    }
}
