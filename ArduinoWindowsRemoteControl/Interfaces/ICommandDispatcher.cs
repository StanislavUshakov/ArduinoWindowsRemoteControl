using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoWindowsRemoteControl.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    interface ICommandDispatcher
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
    }
}
