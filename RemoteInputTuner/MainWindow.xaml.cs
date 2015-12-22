using Arduino.Devices;
using Arduino.Parsers;
using Core.Interfaces;
using RemoteInputTuner.Code;
using RemoteInputTuner.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RemoteInputTuner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Fields

        private MainViewModel _mainViewModel;
        private RemoteCommandEnumerator _remoteCommandEnumerator;
        private IRemoteInputDevice<string> _arduinoDevice;

        #endregion

        #region Constructor

        public MainWindow()
        {
            InitializeComponent();
            _mainViewModel = new MainViewModel();
            DataContext = _mainViewModel;

            _remoteCommandEnumerator = new RemoteCommandEnumerator();
        }

        #endregion

        #region Private Event Handlers

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _arduinoDevice = new ArduinoInputDevice<string>(_mainViewModel.CurrentSerialPort.Name);
                _arduinoDevice.CommandReceived += MessageReceived;
                _arduinoDevice.Open(new SimpleStringParser());
                _mainViewModel.CurrentRemoteCommand = _remoteCommandEnumerator.GetNext();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to " + _mainViewModel.CurrentSerialPort.Name + Environment.NewLine + ex.Message);               
            }            
        }
        
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (_arduinoDevice != null && _arduinoDevice.IsOpened && e.Key == Key.Tab)
            {
                ShowNextCommand();
                e.Handled = true;
            }
        }

        private void MessageReceived(string message)
        {
            if (_mainViewModel.CurrentRemoteCommand.HasValue)
            {
                _mainViewModel.CommandBindings.Add(new Models.RemoteCommandBinding(message, _mainViewModel.CurrentRemoteCommand.Value));
                ShowNextCommand();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                _arduinoDevice.Close();
            }
            catch { }
        }

        private void ShowNextCommand()
        {
            RemoteCommand? nextCommand = _remoteCommandEnumerator.GetNext();
            if (nextCommand == null)
                MessageBox.Show("All remote commands were associated.");
            _mainViewModel.CurrentRemoteCommand = nextCommand;
        }

        #endregion        
    }
}
