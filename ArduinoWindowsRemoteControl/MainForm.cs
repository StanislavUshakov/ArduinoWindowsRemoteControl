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

        private string _currentAppplicationName;
        private ICommandManager _commandManager;
        private CommandUILayout _UILayout;
        private EditCommandForm _editForm;

        #endregion

        #region Constructor

        public MainForm(ICommandManager commandManager, EditCommandForm editForm)
        {
            InitializeComponent();
            _commandManager = commandManager;
            _UILayout = new CommandUILayout(commandListPanel, mainTooltip);
            _commandManager.AddNewCommandForApplication("WinWord", RemoteCommand.PlayPause, "A,A,A,C,Ctrl-A,Ctrl-X,Ctrl-V");
            _commandManager.AddNewCommandForApplication("WinWord", RemoteCommand.Next, "B,B,B");
            _editForm = editForm;

            //temp
            _currentAppplicationName = "WinWord";
            UpdateCommandsListView(_currentAppplicationName);
        }

        #endregion

        private void UpdateCommandsListView(string appName)
        {
            _UILayout.ShowCommandsForApplication(_commandManager.GetCommandsForApplication(appName), remove_Click, edit_Click);
        }

        private void btAddNew_Click(object sender, EventArgs e)
        {
            //ArduinoWindowsRemoteControl.Helpers.WinAPIHelpers.SendKeyboardMessage("ALT-TAB-TAB");
            OpenEditForm(null);
        }

        private void remove_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var command = button.Tag as IApplicationCommand;
            _commandManager.DeleteApplicationCommand(command);
            UpdateCommandsListView(_currentAppplicationName);
        }

        private void edit_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var command = button.Tag as IApplicationCommand;
            OpenEditForm(command);
        }

        /// <summary>
        /// Open form for editing and adding the command.
        /// If null - adding.
        /// </summary>
        /// <param name="command">Command to be edited or null if new command is being created</param>
        private void OpenEditForm(IApplicationCommand command)
        {
            _editForm.SetUp(_currentAppplicationName, command);
            _editForm.ShowDialog();
            UpdateCommandsListView(_currentAppplicationName);
        }
    }
}
