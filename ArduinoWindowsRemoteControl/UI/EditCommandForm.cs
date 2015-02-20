using ArduinoWindowsRemoteControl.Helpers;
using ArduinoWindowsRemoteControl.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoWindowsRemoteControl.UI
{
    public partial class EditCommandForm : Form
    {
        private List<int> _pressedButtons = new List<int>();

        public EditCommandForm()
        {
            InitializeComponent();
            cbRemoteCommand.Items.AddRange(EnumHelpers.GetAvailableEnumValues<RemoteCommand>().ToArray());
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_pressedButtons.Contains(e.KeyValue))
            {
                tbCommand.Text += WinAPIHelpers.GetKeyStringForVirtualCode((byte)e.KeyValue);
                _pressedButtons.Add(e.KeyValue);
            }
            e.Handled = true;
        }

        private void tbCommand_KeyUp(object sender, KeyEventArgs e)
        {
            _pressedButtons.Remove(e.KeyValue);
            e.Handled = true;
        }

        private void tbCommand_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }        
    }
}
