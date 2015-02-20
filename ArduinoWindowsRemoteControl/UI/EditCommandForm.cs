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
        private bool _isKeyStrokeEnabled = false;

        public EditCommandForm()
        {
            InitializeComponent();
            cbRemoteCommand.Items.AddRange(EnumHelpers.GetAvailableEnumValues<RemoteCommand>()
                .Select(tuple => new ComboboxItem { Text = tuple.Item1, Value = tuple.Item2 }).ToArray());
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_pressedButtons.Contains(e.KeyValue))
            {
                //key command ended, start new one
                if (_pressedButtons.Count == 0)
                {
                    _isKeyStrokeEnabled = false;
                }

                if (_isKeyStrokeEnabled)
                {
                    tbCommand.Text += "-";
                }
                else
                {
                    if (tbCommand.Text.Length > 0)
                        tbCommand.Text += ",";
                }               

                tbCommand.Text += WinAPIHelpers.GetKeyStringForVirtualCode((byte)e.KeyValue);                
                tbCommand.SelectionStart = tbCommand.Text.Length;
                _pressedButtons.Add(e.KeyValue);
            }
            else
            {
                if (_pressedButtons.Last() == e.KeyValue)
                {
                    _isKeyStrokeEnabled = true;
                }
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
