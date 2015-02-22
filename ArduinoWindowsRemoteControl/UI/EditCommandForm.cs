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
        #region Constructor

        public EditCommandForm()
        {
            InitializeComponent();
            cbRemoteCommand.Items.AddRange(EnumHelpers.GetAvailableEnumValues<RemoteCommand>()
                .Select(tuple => new ComboboxItem { Text = tuple.Item1, Value = tuple.Item2 }).ToArray());
        }

        #endregion

        #region Public Methods

        public void SetCommand(IApplicationCommand command)
        {
            if (command != null)
            {
                SetupFromCommand(command);
            }
            else
            {
                SetupDefault();
            }
        }

        #endregion

        #region Private Event Handlers

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rbCommandInput_CheckedChanged(object sender, EventArgs e)
        {
            tbCommand.IsCommandInput = rbCommandInput.Checked;
        }

        #endregion

        #region Private Methods

        private void SetupFromCommand(IApplicationCommand command)
        {
            Text = "Edit Command For " + command.ApplicationName;
            tbCommand.Text = command.Command.ToString();
            int selectedIndex = -1;
            for (int i = 0; i < cbRemoteCommand.Items.Count; i++)
            {
                var item = (ComboboxItem)cbRemoteCommand.Items[i];
                if ((RemoteCommand)item.Value == command.RemoteCommand)
                {
                    selectedIndex = i;
                    break;
                }
            }
            cbRemoteCommand.SelectedIndex = selectedIndex;
        }

        private void SetupDefault()
        {
            Text = "Add New Command";
            tbCommand.Text = "";
            rbCommandInput.Checked = true;
            cbRemoteCommand.SelectedIndex = -1;
        }

        #endregion
    }
}
