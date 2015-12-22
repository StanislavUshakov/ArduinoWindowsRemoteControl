using Arduino.Devices;
using Arduino.Parsers;
using Core.Interfaces;
using Microsoft.Win32;
using RemoteInputTuner.Code;
using RemoteInputTuner.ViewModels;
using Services;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

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
        private RemoteCommandParserPersistentService _remoteCommandParserPersistentService;

        #endregion

        #region Constructor

        public MainWindow()
        {
            InitializeComponent();
            _mainViewModel = new MainViewModel();
            DataContext = _mainViewModel;

            _remoteCommandEnumerator = new RemoteCommandEnumerator();
            _remoteCommandParserPersistentService = new RemoteCommandParserPersistentService();
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
                btConnect.IsEnabled = false;
                cbPort.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to " + _mainViewModel.CurrentSerialPort.Name + Environment.NewLine + ex.Message);               
            }            
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "Remote Commands";
            dlg.DefaultExt = ".rmc";
            dlg.Filter = "Remote Commands (.rmc)|*.rmc";

            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;
                var commandMapping = _mainViewModel.CommandBindings.ToDictionary(b => b.HexCode, b => b.RemoteCommand);
                ArduinoRemoteCommandParser parser = new ArduinoRemoteCommandParser(commandMapping);
                _remoteCommandParserPersistentService.SaveArduinoCommandParser(parser, filename);
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
                Dispatcher.Invoke(() => _mainViewModel.CommandBindings.Add(new Models.RemoteCommandBinding(message, _mainViewModel.CurrentRemoteCommand.Value)));
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
            {
                MessageBox.Show("All remote commands were associated.");
                Dispatcher.Invoke(() => btSave.Visibility = Visibility.Visible);
            }
            _mainViewModel.CurrentRemoteCommand = nextCommand;
        }

        #endregion
    }
}
