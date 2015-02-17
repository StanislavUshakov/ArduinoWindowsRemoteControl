using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoWindowsRemoteControl.Interfaces
{
    /// <summary>
    /// Represents simple association that connects application, remote command and feedback to this command.
    /// If ApplicationName is null - this is a default behaviour.
    /// </summary>
    interface IApplicationCommand
    {
        /// <summary>
        /// Name of the application
        /// </summary>
        string ApplicationName { get; }

        /// <summary>
        /// Remote command
        /// </summary>
        RemoteCommand CommandType { get; }

        /// <summary>
        /// Command to be executed
        /// </summary>
        ICommand Command { get; }

        /// <summary>
        /// Executes associated command
        /// </summary>
        void Do();
    }
}
