using RemoteInputTuner.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RemoteInputTuner.ViewModels
{
    /// <summary>
    /// The main ViewModel which is used for data binding in the app.
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Private Fields

        private readonly ObservableCollection<SerialPortModel> _serialPorts;
        private SerialPortModel _serialPort;

        #endregion

        #region Constructor

        public MainViewModel()
        {
            var ports = SerialPort.GetPortNames().Select(s => new SerialPortModel(s));
            _serialPorts = new ObservableCollection<SerialPortModel>();

            foreach (var port in ports)
                _serialPorts.Add(port);

            _serialPort = ports.FirstOrDefault();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Available serial ports
        /// </summary>
        public ObservableCollection<SerialPortModel> SerialPorts
        {
            get { return _serialPorts; }
        }

        /// <summary>
        /// Currently selected serial port
        /// </summary>
        public SerialPortModel CurrentSerialPort
        {
            get { return _serialPort; }
            set
            {
                if (_serialPort == value) return;
                _serialPort = value;
                OnPropertyChanged("CurrentSerialPort");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Private Methods

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
