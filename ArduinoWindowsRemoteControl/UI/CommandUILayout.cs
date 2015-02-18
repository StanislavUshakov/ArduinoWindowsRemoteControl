using ArduinoWindowsRemoteControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoWindowsRemoteControl.UI
{
    public class CommandUILayout
    {
        #region Private Fields

        private Panel _panel;
        private ToolTip _toolTip;
        private int _space = 10;
        private int _firstColumnWidth = 200;
        private int _secondColumnWidth = 150;
        private int _verticalSpaceLabel = 3;
        private int _verticalStart = 10;
        private int _leftStart = 0;
        private int _verticalStep = 30;
        private float _fontSize = 10.0F;

        #endregion

        #region Constructor

        public CommandUILayout(Panel panel, ToolTip toolTip)
        {
            _panel = panel;
            _toolTip = toolTip;
        }

        #endregion

        #region Public Methods

        public void ShowCommandsForApplication(IEnumerable<IApplicationCommand> commands)
        {
            int y = _verticalStart;
            var font = new Font(FontFamily.GenericMonospace, _fontSize);
            foreach (var command in commands)
            {
                Button b = new Button();
                b.Tag = command;
                b.Text = "bt" + command.ApplicationName + "-" + command.Command + "-" + command.RemoteCommand;
                b.Top = y;
                b.Left = _leftStart + _firstColumnWidth + 2 * _space + _secondColumnWidth;
                b.Font = font;

                Label lbRemote = new Label();
                lbRemote.Text = "Remote Command: " + command.RemoteCommand.ToString();
                lbRemote.Top = y + _verticalSpaceLabel;
                lbRemote.Left = _leftStart;
                lbRemote.Width = _firstColumnWidth;
                lbRemote.Font = font;

                Label lbCommand = new Label();
                lbCommand.Text = "Command: " + command.Command;
                lbCommand.Top = y + _verticalSpaceLabel;
                lbCommand.Left = _leftStart + _firstColumnWidth + _space;
                lbCommand.Width = _secondColumnWidth;
                lbCommand.Font = font;
                _toolTip.SetToolTip(lbCommand, command.Command.ToString());

                _panel.Controls.Add(b);
                _panel.Controls.Add(lbRemote);
                _panel.Controls.Add(lbCommand);

                y += _verticalStep;
            }
        }

        #endregion
    } 
}
