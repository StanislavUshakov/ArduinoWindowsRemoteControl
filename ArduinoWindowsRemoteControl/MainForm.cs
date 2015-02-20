﻿using ArduinoWindowsRemoteControl.Interfaces;
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
        public ICommandManager CommandManager { get; set; }

        public CommandUILayout UILayout { get; set; }

        private EditCommandForm _editForm;

        public MainForm(ICommandManager commandManager)
        {
            InitializeComponent();
            CommandManager = commandManager;
            UILayout = new CommandUILayout(commandListPanel, mainTooltip);
            CommandManager.AddNewCommandForApplication("WinWord", RemoteCommand.PlayPause, "A,A,A,C,Ctrl-A,Ctrl-X,Ctrl-V");
            CommandManager.AddNewCommandForApplication("WinWord", RemoteCommand.TurnOnOff, "B,B,B");
            UpdateCommandsListView("WinWord");
        }

        private void UpdateCommandsListView(string appName)
        {
            UILayout.ShowCommandsForApplication(CommandManager.GetCommandsForApplication(appName), remove_Click);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ArduinoWindowsRemoteControl.Helpers.WinAPIHelpers.SendKeyboardMessage("ALT-TAB-TAB");
            _editForm = new EditCommandForm();
            _editForm.ShowDialog();
        }

        private void remove_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var command = button.Tag as IApplicationCommand;
            CommandManager.DeleteApplicationCommand(command);
            UpdateCommandsListView("WinWord");
        }
    }
}
