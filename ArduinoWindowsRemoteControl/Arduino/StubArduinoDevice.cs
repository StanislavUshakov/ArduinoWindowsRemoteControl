using ArduinoWindowsRemoteControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArduinoWindowsRemoteControl.Arduino
{
    /// <summary>
    /// Represents stub remote control device that sends PlayPause and Next commands
    /// every 5 seconds.
    /// </summary>
    public class StubArduinoDevice : IArduinoDevice
    {
        public StubArduinoDevice()
        {
            ThreadPool.QueueUserWorkItem((state) =>
                {
                    while (true)
                    {
                        Thread.Sleep(2500);
                        if (OnCommandReceived != null)
                            OnCommandReceived(RemoteCommand.PlayPause);
                        Thread.Sleep(2500);
                        if (OnCommandReceived != null)
                            OnCommandReceived(RemoteCommand.Mode);
                    }
                });
        }

        public event Action<RemoteCommand> OnCommandReceived;
    }
}
