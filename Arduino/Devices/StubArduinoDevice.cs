using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arduino.Devices
{
    /// <summary>
    /// Represents stub remote control device that sends PlayPause and Next commands
    /// every 5 seconds.
    /// </summary>
    public class StubArduinoDevice : IRemoteInputDevice<RemoteCommand>
    {
        public StubArduinoDevice()
        {
            ThreadPool.QueueUserWorkItem((state) =>
                {
                    while (true)
                    {
                        Thread.Sleep(2500);
                        if (CommandReceived != null)
                            CommandReceived(RemoteCommand.PlayPause);
                        Thread.Sleep(2500);
                        if (CommandReceived != null)
                            CommandReceived(RemoteCommand.Mode);
                    }
                });
        }

        public event Action<RemoteCommand> CommandReceived;


        public void Open(IRemoteCommandParser<RemoteCommand> commandParser) { }

        public void Close() { }

        public bool IsOpened
        {
            get { return true; }
        }
    }
}
