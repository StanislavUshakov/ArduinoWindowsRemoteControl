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
    }
}
