using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoWindowsRemoteControl
{
    /// <summary>
    /// This form is used only for selecting serial port
    /// </summary>
    public partial class SelectPortForm : Form
    {
        #region Constructor

        public SelectPortForm()
        {
            InitializeComponent();

            cbSerialPorts.Items.AddRange(SerialPort.GetPortNames());
            cbSerialPorts.SelectedIndex = 0;
        }

        #endregion

        #region Private Event Handlers

        private void btOk_Click(object sender, EventArgs e)
        {
            Program.PortName = cbSerialPorts.SelectedItem as string; ;
            Close();
        }

        #endregion
    }
}
