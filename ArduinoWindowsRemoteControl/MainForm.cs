using ArduinoWindowsRemoteControl.UI;
using Core.Interfaces;
using Services;
using System;
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
        private ApplicationCommandPersistentService _persistentService;

        #endregion

        #region Constructor

        public MainForm(ICommandManager commandManager, ApplicationCommandPersistentService persistentService, EditCommandForm editForm)
        {
            InitializeComponent();
            _commandManager = commandManager;
            _persistentService = persistentService;
            _UILayout = new CommandUILayout(commandListPanel, mainTooltip);
            _editForm = editForm;

            _persistentService.Load(_commandManager);

            cbApplication.Items.AddRange(_commandManager.GetApplicationNames().ToArray());
            cbApplication.SelectedIndex = 0;
            _currentAppplicationName = cbApplication.Items[0].ToString();

            UpdateCommandsListView(_currentAppplicationName);
        }

        #endregion

        #region Private Event Handlers

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

        private void btAddNewApplication_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbNewAppName.Text))
            {
                //if application name is not empty - add and select it
                cbApplication.Items.Add(tbNewAppName.Text);
                cbApplication.SelectedIndex = cbApplication.Items.Count - 1;
                tbNewAppName.Text = "";
            }
        }

        private void cbApplication_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentAppplicationName = cbApplication.SelectedItem.ToString();
            UpdateCommandsListView(_currentAppplicationName);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _persistentService.Save(_commandManager);
        }

        #endregion

        #region Private Methods

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

        private void UpdateCommandsListView(string appName)
        {
            _UILayout.ShowCommandsForApplication(_commandManager.GetCommandsForApplication(appName), remove_Click, edit_Click);
        }

        #endregion        
    }
}
