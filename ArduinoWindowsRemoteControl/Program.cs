using ArduinoWindowsRemoteControl.Unity;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoWindowsRemoteControl
{
    static class Program
    {
        public static string PortName { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var serialPorts = SerialPort.GetPortNames();

            //if no serial ports are found - exit
            if (serialPorts.Length == 0)
            {
                MessageBox.Show("No Serial Ports are found. Please connect your Arduino device and restart application.", "Error", MessageBoxButtons.OK);
                return;
            }

            //if only one port - use it
            if (serialPorts.Length == 1)
            {
                PortName = serialPorts[0];
                var unityContainer = UnityInitializer.ConfigureUnity();
                Application.Run(unityContainer.Resolve<MainForm>());
            }
            else
            {
                //we need to select port
                Application.Run(new SelectPortForm()); 
                var unityContainer = UnityInitializer.ConfigureUnity();
                Application.Run(unityContainer.Resolve<MainForm>());
            }
        }
    }
}
