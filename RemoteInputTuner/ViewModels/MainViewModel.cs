using Core.Interfaces;
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
        private readonly ObservableCollection<RemoteCommandBinding> _commandBindings;
        private SerialPortModel _serialPort;
        private string _currentRemoteCommand;

        #endregion

        #region Constructor

        public MainViewModel()
        {
            var ports = SerialPort.GetPortNames().Select(s => new SerialPortModel(s));
            _serialPorts = new ObservableCollection<SerialPortModel>();
            _commandBindings = new ObservableCollection<RemoteCommandBinding>();
            
            foreach (var port in ports)
                _serialPorts.Add(port);

            _serialPort = ports.FirstOrDefault();

            _commandBindings.Add(new RemoteCommandBinding("ox456745", RemoteCommand.USD));
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
        /// Created command bindings
        /// </summary>
        public ObservableCollection<RemoteCommandBinding> CommandBindings
        {
            get { return _commandBindings; }
        }

        /// <summary>
        /// Currently selected serial port
        /// </summary>
        public SerialPortModel CurrentSerialPort
        {
            get 
            { 
                return _serialPort; 
            }
            set
            {
                if (_serialPort == value) return;
                _serialPort = value;
                OnPropertyChanged("CurrentSerialPort");
            }
        }

        /// <summary>
        /// Current remote command for binding
        /// </summary>
        public string CurrentRemoteCommand
        {
            get
            {
                return _currentRemoteCommand; 
            }
            set
            {
                if (_currentRemoteCommand == value) return;
                _currentRemoteCommand = value;
                OnPropertyChanged("CurrentRemoteCommand");
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
