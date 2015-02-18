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
        /// <returns></returns>
        bool AddNewCommandForApplication(string applicationName, RemoteCommand remoteCommand, string command);
    }
}
