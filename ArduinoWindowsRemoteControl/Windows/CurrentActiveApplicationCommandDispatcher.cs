using ArduinoWindowsRemoteControl.Helpers;
using ArduinoWindowsRemoteControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoWindowsRemoteControl.Windows
{
    /// <summary>
    /// Dispacther that sends command to current active application
    /// </summary>
    public class CurrentActiveApplicationCommandDispatcher : ICommandDispatcher
    {
        #region Private Fields

        /// <summary>
        /// Mapping: AppName -> Remote command -> Command
        /// </summary>
        private Dictionary<string, Dictionary<RemoteCommand, IApplicationCommand>> _applicationCommandsMapping;

        #endregion

        #region Constructor

        public CurrentActiveApplicationCommandDispatcher()
        {
            _applicationCommandsMapping = new Dictionary<string, Dictionary<RemoteCommand, IApplicationCommand>>();
        }

        #endregion

        #region Public Methods

        public override bool AddApplicationCommand(IApplicationCommand applicationCommand)
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

        public override void DispatchCommand(RemoteCommand command)
        {
            string currentActiveAppName = WinAPIHelpers.GetActiveApplicationName();

            if (!_applicationCommandsMapping.ContainsKey(currentActiveAppName))
                return;

            var commandsForApp = _applicationCommandsMapping[currentActiveAppName];
            if (!commandsForApp.ContainsKey(command))
                return;

            commandsForApp[command].Do();
        }

        public override Dictionary<RemoteCommand, IApplicationCommand> GetCommandsForApplication(string applicationName)
        {
            if (_applicationCommandsMapping.ContainsKey(applicationName))
            {
                return _applicationCommandsMapping[applicationName];
            }
            else
            {
                return new Dictionary<RemoteCommand, IApplicationCommand>();
            }
        }

        #endregion
    }
}
