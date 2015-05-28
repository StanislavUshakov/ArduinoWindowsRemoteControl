using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arduino
{
    /// <summary>
    /// This class is used for communication with the Arduino device via serial port.
    /// Arduino device sends hexadecimal values that represent pushed buttons.
    /// </summary>
    public class ArduinoInputDevice : IRemoteInputDevice
    {
        #region Private Fields

        private readonly SerialPort _port;
        private bool _isOpened;
        private Thread _readingThread;

        #endregion

        #region Constructor

        public ArduinoInputDevice(string portName)
        {
            _port = new SerialPort(portName);
        }

        #endregion

        #region IRemoteInputDevice members

        public event Action<RemoteCommand> CommandReceived;
        
        public void Open()
        {
            try
            {
                _port.Open();
                _isOpened = true;
                _readingThread = new Thread(ReadInformationFromDevice);
                _readingThread.Start();
            }
            catch (Exception ex)
            {
                throw new ArduinoInputDeviceException("Arduino device cannot be opened", ex);
            }
        }

        public void Close()
        {
            try
            {
                _port.Close();
                _readingThread.Abort();
                _isOpened = false;
            }
            catch (Exception ex)
            {
                throw new ArduinoInputDeviceException("Arduino device cannot be closed", ex);
            }
        }
        
        public bool IsOpened
        {
            get { return _isOpened; }
        }

        #endregion

        #region Private Methods

        private void ReadInformationFromDevice()
        {
            while (true)
            {
                string command = _port.ReadLine();
                //TODO: parse command, rise event
            }
        }

        #endregion
    }

    #region ArduinoInputDeviceException

    public class ArduinoInputDeviceException : Exception
    {
        public ArduinoInputDeviceException(string message = "", Exception innerException = null) : base(message, innerException) { }
    }

    #endregion
}
