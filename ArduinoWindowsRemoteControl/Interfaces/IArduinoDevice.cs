using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoWindowsRemoteControl.Interfaces
{
    /// <summary>
    /// Represents received remote command
    /// </summary>
    enum RemoteCommand
    {
        TurnOn,
        TurnOf, 
        Play
    }

    /// <summary>
    /// Represents device that is connected with the remote control
    /// </summary>
    interface IArduinoDevice
    {
        /// <summary>
        /// This event is fired when remote command is received
        /// </summary>
        event Action<RemoteCommand> OnCommandReceived;
    }
}
