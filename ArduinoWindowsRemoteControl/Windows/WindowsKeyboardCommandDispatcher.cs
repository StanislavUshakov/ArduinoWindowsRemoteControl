﻿using ArduinoWindowsRemoteControl.Helpers;
using ArduinoWindowsRemoteControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoWindowsRemoteControl.Windows
{
    public class WindowsKeyboardCommandDispatcher : ICommandDispatcher
    {
        #region Private Fields

        /// <summary>
        /// Mapping: AppName -> Remote command -> Command
        /// </summary>
        private Dictionary<string, Dictionary<RemoteCommand, IApplicationCommand>> _applicationCommandsMapping;

        #endregion

        #region Constructor

        public WindowsKeyboardCommandDispatcher()
        {
            _applicationCommandsMapping = new Dictionary<string, Dictionary<RemoteCommand, IApplicationCommand>>();
        }

        #endregion

        #region Public Methods

        public bool AddApplicationCommand(IApplicationCommand applicationCommand)
        {
            if (_applicationCommandsMapping.ContainsKey(applicationCommand.ApplicationName))
            {
                //there is a commands for this app
                var commandsForApp = _applicationCommandsMapping[applicationCommand.ApplicationName];
                if (commandsForApp.ContainsKey(applicationCommand.RemoteCommand))
                {
                    //remove previous one
                    commandsForApp.Remove(applicationCommand.RemoteCommand);
                    commandsForApp.Add(applicationCommand.RemoteCommand, applicationCommand);
                    return true;
                }
                else
                {
                    //add new one
                    commandsForApp.Add(applicationCommand.RemoteCommand, applicationCommand);
                    return false;
                }
            }
            else
            {
                //no commands for this app
                _applicationCommandsMapping.Add(applicationCommand.ApplicationName, 
                    new Dictionary<RemoteCommand, IApplicationCommand> { { applicationCommand.RemoteCommand, applicationCommand } });
                return false;
            }
        }

        public void DispatchCommand(RemoteCommand command)
        {
            string currentActiveAppName = WinAPIHelpers.GetActiveApplicationName();

            if (!_applicationCommandsMapping.ContainsKey(currentActiveAppName))
                return;

            var commandsForApp = _applicationCommandsMapping[currentActiveAppName];
            if (!commandsForApp.ContainsKey(command))
                return;

            commandsForApp[command].Do();
        }

        #endregion
    }
}