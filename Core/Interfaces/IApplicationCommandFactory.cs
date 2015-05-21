using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    /// <summary>
    /// Factory for creating IApplicationCommand objects
    /// </summary>
    public interface IApplicationCommandFactory
    {
        /// <summary>
        /// Creates an IApplicationCommand object - feedback for special remote command
        /// for special application
        /// </summary>
        /// <param name="applicationName">Application (process) name</param>
        /// <param name="remoteCommand">Received remote command</param>
        /// <param name="command">Command representation</param>
        /// <returns>IApplicationCommand instance</returns>
        IApplicationCommand Create(string applicationName, RemoteCommand remoteCommand, string command);
    }
}
