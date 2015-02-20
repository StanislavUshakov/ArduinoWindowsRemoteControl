using ArduinoWindowsRemoteControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArduinoWindowsRemoteControl.Arduino
{
    public class StubArduinoDevice : IArduinoDevice
    {
        public StubArduinoDevice()
        {
            ThreadPool.QueueUserWorkItem((state) =>
                {
                    while (true)
                    {
                        Thread.Sleep(5000);
                        if (OnCommandReceived != null)
                            OnCommandReceived(RemoteCommand.PlayPause);
                        Thread.Sleep(5000);
                        if (OnCommandReceived != null)
                            OnCommandReceived(RemoteCommand.TurnOnOff);
                    }
                });
        }

        public event Action<RemoteCommand> OnCommandReceived;
    }
}
