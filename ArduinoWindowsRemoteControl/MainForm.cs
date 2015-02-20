using ArduinoWindowsRemoteControl.Interfaces;
using ArduinoWindowsRemoteControl.UI;
using ArduinoWindowsRemoteControl.Unity;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoWindowsRemoteControl
{
    public partial class MainForm : Form
    {
        #region Private Fields

        private ICommandManager _commandManager;

        private CommandUILayout _UILayout;

        private EditCommandForm _editForm;

        #endregion

        public MainForm(ICommandManager commandManager)
        {
            InitializeComponent();
            _commandManager = commandManager;
            _UILayout = new CommandUILayout(commandListPanel, mainTooltip);
            _commandManager.AddNewCommandForApplication("WinWord", RemoteCommand.PlayPause, "A,A,A,C,Ctrl-A,Ctrl-X,Ctrl-V");
            _commandManager.AddNewCommandForApplication("WinWord", RemoteCommand.TurnOnOff, "B,B,B");
            UpdateCommandsListView("WinWord");
        }

        private void UpdateCommandsListView(string appName)
        {
            _UILayout.ShowCommandsForApplication(_commandManager.GetCommandsForApplication(appName), remove_Click, edit_Click);
        }

        private void btAddNew_Click(object sender, EventArgs e)
        {
            //ArduinoWindowsRemoteControl.Helpers.WinAPIHelpers.SendKeyboardMessage("ALT-TAB-TAB");
            _editForm = new EditCommandForm();
            _editForm.ShowDialog();
        }

        private void remove_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var command = button.Tag as IApplicationCommand;
            _commandManager.DeleteApplicationCommand(command);
            UpdateCommandsListView("WinWord");
        }

        private void edit_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var command = button.Tag as IApplicationCommand;
        }
    }
}
