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
            MessageBox.Show(_mainViewModel.CurrentSerialPort.Name);
            _mainViewModel.CurrentRemoteCommand = _remoteCommandEnumerator.GetNext();
        }
        
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
            {
                string nextCommand = _remoteCommandEnumerator.GetNext();
                if (nextCommand == null)
                    MessageBox.Show("All remote commands were associated.");
                _mainViewModel.CurrentRemoteCommand = nextCommand;

                e.Handled = true;
            }
        }

        #endregion
    }
}
