using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public static class IApplicationCommandConstants
    {
        /// <summary>
        /// This application name represents default commands - when there is no
        /// command for specific application
        /// </summary>
        public const string DEFAULT_APPLICATION = "DEFAULT";
    }


    /// <summary>
    /// Represents simple association that connects application, remote command and feedback to this command.
    /// If ApplicationName is null - this is a default behaviour.
    /// </summary>
    public interface IApplicationCommand
    {
        /// <summary>
        /// Name of the application
        /// </summary>
        string ApplicationName { get; }

        /// <summary>
        /// Remote command
        /// </summary>
        RemoteCommand RemoteCommand { get; }

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
