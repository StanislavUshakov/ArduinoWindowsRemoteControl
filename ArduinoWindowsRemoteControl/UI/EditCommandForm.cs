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
        #region Private Fields

        private string _applicationName;
        private ICommandManager _commandManager;
        private IApplicationCommand _command;

        #endregion

        #region Constructor

        public EditCommandForm(ICommandManager commandManager)
        {
            InitializeComponent();
            _commandManager = commandManager;
            cbRemoteCommand.Items.AddRange(EnumHelpers.GetAvailableEnumValues<RemoteCommand>()
                .Select(tuple => new ComboboxItem { Text = tuple.Item1, Value = tuple.Item2 }).ToArray());
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Setup all needed properties.
        /// </summary>
        /// <param name="applicationName">For which application command is adding/editing</param>
        /// <param name="command">Command to be edited or null, if the new command is being added</param>
        public void SetUp(string applicationName, IApplicationCommand command)
        {
            _applicationName = applicationName;
            _command = command;
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
        private void btSave_Click(object sender, EventArgs e)
        {
            //if we're editing the existing command - delete the previous version
            if (_command != null)
            {
                _commandManager.DeleteApplicationCommand(_command);
            }
            _commandManager.AddNewCommandForApplication(_applicationName, (RemoteCommand)(cbRemoteCommand.SelectedItem as ComboboxItem).Value, tbCommand.Text);
            Close();
        }
        #endregion

        #region Private Methods

        private void SetupFromCommand(IApplicationCommand command)
        {
            Text = "Edit Command For " + _applicationName;
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
            Text = "Add New Command For " + _applicationName;
            tbCommand.Text = "";
            rbCommandInput.Checked = true;
            cbRemoteCommand.SelectedIndex = -1;
        }

        #endregion
    }
}
