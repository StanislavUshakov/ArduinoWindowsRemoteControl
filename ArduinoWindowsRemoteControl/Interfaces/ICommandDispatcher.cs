using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoWindowsRemoteControl.Interfaces
{
    /// <summary>
    /// Dispatches the received remote command
    /// </summary>
    public interface ICommandDispatcher
    {
        /// <summary>
        /// Add associated command
        /// </summary>
        /// <param name="applicationCommand">Command to be added</param>
        /// <returns>True, if was changed, False, if added new</returns>
        bool AddApplicationCommand(IApplicationCommand applicationCommand);

        /// <summary>
        /// Process remote command
        /// </summary>
        /// <param name="command">Received command</param>
        void DispatchCommand(RemoteCommand command);

        /// <summary>
        /// Return commands for specific application. If no commands for this application - return empty Dictionary
        /// </summary>
        /// <param name="applicationName">Application name</param>
        /// <returns>Mapping for remote commands for specific application</returns>
        Dictionary<RemoteCommand, IApplicationCommand> GetCommandsForApplication(string applicationName);

        /// <summary>
        /// Return list of application names that are associated with commands
        /// </summary>
        /// <returns>List of strings - names of applications</returns>
        List<string> GetApplicationNames();
    }
}
