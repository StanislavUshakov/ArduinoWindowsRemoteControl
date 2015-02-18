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
        public ICommandManager CommandManager { get; set; }

        public CommandUILayout UILayout { get; set; }

        public MainForm(ICommandManager commandManager)
        {
            InitializeComponent();
            CommandManager = commandManager;
            UILayout = new CommandUILayout(panel1, mainTooltip);
            CommandManager.AddNewCommandForApplication("WinWord", RemoteCommand.Play, "A,A,A");
            CommandManager.AddNewCommandForApplication("WinWord", RemoteCommand.TurnOn, "B,B,B");
            UpdateCommandsListView("WinWord");
        }

        private void UpdateCommandsListView(string appName)
        {
            UILayout.ShowCommandsForApplication(CommandManager.GetCommandsForApplication(appName), remove_Click);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArduinoWindowsRemoteControl.Helpers.WinAPIHelpers.SendKeyboardMessage("ALT-TAB-TAB");
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
