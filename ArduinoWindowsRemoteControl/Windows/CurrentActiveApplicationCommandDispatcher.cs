using Core.Interfaces;
using Helpers;
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
            _applicationCommandsMapping = new Dictionary<string, Dictionary<RemoteCommand, IApplicationCommand>>(StringComparer.InvariantCultureIgnoreCase);
        }

        #endregion

        #region Public Methods

        public bool AddApplicationCommand(IApplicationCommand applicationCommand)
        {
            if (_applicationCommandsMapping.ContainsKey(applicationCommand.ApplicationName))
            {
                //there are commands for this app
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

        public bool DeleteApplicationCommand(IApplicationCommand applicationCommand)
        {
            if (_applicationCommandsMapping.ContainsKey(applicationCommand.ApplicationName))
            {
                //there are commands for this app
                var commandsForApp = _applicationCommandsMapping[applicationCommand.ApplicationName];
                if (commandsForApp.ContainsKey(applicationCommand.RemoteCommand))
                {
                    //remove
                    commandsForApp.Remove(applicationCommand.RemoteCommand);

                    //if there's no commands for this applictaion left - delete
                    if (commandsForApp.Count == 0)
                    {
                        _applicationCommandsMapping.Remove(applicationCommand.ApplicationName);
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                //no commands for this app
                return false;
            }
        }

        public void DispatchCommand(RemoteCommand command)
        {
            string currentActiveAppName = WinAPIHelpers.GetActiveApplicationName();
            Dictionary<RemoteCommand, IApplicationCommand> commandsForApp = null;

            if (_applicationCommandsMapping.ContainsKey(currentActiveAppName))
            {
                commandsForApp = _applicationCommandsMapping[currentActiveAppName];
            }
            else if (_applicationCommandsMapping.ContainsKey(IApplicationCommandConstants.DEFAULT_APPLICATION))
            {
                commandsForApp = _applicationCommandsMapping[IApplicationCommandConstants.DEFAULT_APPLICATION];
            }


            if (commandsForApp == null || !commandsForApp.ContainsKey(command))
                return;

            commandsForApp[command].Do();
        }

        public Dictionary<RemoteCommand, IApplicationCommand> GetCommandsForApplication(string applicationName)
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

        public List<string> GetApplicationNames()
        {
            return _applicationCommandsMapping.Keys.ToList();
        }

        public void DeleteAllCommands()
        {
            _applicationCommandsMapping = new Dictionary<string, Dictionary<RemoteCommand, IApplicationCommand>>();
        }

        #endregion
    }
}
