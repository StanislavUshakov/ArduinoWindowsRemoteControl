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
        private int _firstColumnWidth = 220;
        private int _secondColumnWidth = 280;
        private int _thirdColumnWidth = 75;
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

        public void ShowCommandsForApplication(IEnumerable<IApplicationCommand> commands, EventHandler removeHandler, EventHandler editHandler)
        {
            int y = _verticalStart;
            var font = new Font(FontFamily.GenericMonospace, _fontSize);

            _panel.Controls.Clear();

            foreach (var command in commands)
            {
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
                lbCommand.AutoEllipsis = true;
                _toolTip.SetToolTip(lbCommand, command.Command.ToString());

                Button btEdit = new Button();
                btEdit.Tag = command;
                btEdit.Text = "Edit";
                btEdit.Top = y;
                btEdit.Left = _leftStart + _firstColumnWidth + 2 * _space + _secondColumnWidth;
                btEdit.Font = font;
                btEdit.Click += editHandler;


                Button btRemove = new Button();
                btRemove.Tag = command;
                btRemove.Text = "Remove";
                btRemove.Top = y;
                btRemove.Left = _leftStart + _firstColumnWidth + 3 * _space + _secondColumnWidth + _thirdColumnWidth;
                btRemove.Font = font;
                btRemove.Click += removeHandler;                
                
                _panel.Controls.Add(lbRemote);
                _panel.Controls.Add(lbCommand);
                _panel.Controls.Add(btEdit);
                _panel.Controls.Add(btRemove);

                y += _verticalStep;
            }
        }

        #endregion
    } 
}
