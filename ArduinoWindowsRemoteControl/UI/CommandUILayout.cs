using ArduinoWindowsRemoteControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoWindowsRemoteControl.UI
{
    public class CommandUILayout
    {
        private Panel _panel;

        public CommandUILayout(Panel panel)
        {
            _panel = panel;
        }

        public void ShowCommandsForApplication(IEnumerable<IApplicationCommand> commands)
        {
            int y = 10;
            int x = 10;
            foreach (var command in commands)
            {
                Button b = new Button();
                b.Tag = command;
                b.Name = b.Text = "bt" + command.ApplicationName + "-" + command.Command + "-" + command.RemoteCommand;
                b.Top = y;
                b.Left = 100;
                y += 30;
                _panel.Controls.Add(b);
            }
        }
    } 
}
