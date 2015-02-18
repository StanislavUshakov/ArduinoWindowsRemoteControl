using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoWindowsRemoteControl.Interfaces
{
    /// <summary>
    /// Process and manages commands 
    /// </summary>
    public interface ICommandManager
    {
        /// <summary>
        /// Add new command with the association for application.
        /// </summary>
        /// <param name="applicationName"></param>
        /// <param name="remoteCommand"></param>
        /// <param name="command"></param>
        /// <returns>True, if exisintg command was changed; False, if the new command was added</returns>
        bool AddNewCommandForApplication(string applicationName, RemoteCommand remoteCommand, string command);

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
