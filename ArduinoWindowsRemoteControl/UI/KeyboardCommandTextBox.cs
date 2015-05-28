using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoWindowsRemoteControl.UI
{
    /// <summary>
    /// Special TextBox that accepts all keys and shows Keys representations if IsCommandInput is 
    /// set to True. Bahves like common TextBox otherwise
    /// </summary>
    public class KeyboardCommandTextBox : TextBox
    {
        #region Private Fields

        private List<int> _pressedButtons = new List<int>();

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets value indicating if command input is enabled
        /// </summary>
        public bool IsCommandInput { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Setup all needed event handlers
        /// </summary>
        public KeyboardCommandTextBox()
            : base()
        {
            KeyDown += eventHandler_KeyDown;
            KeyUp += eventHandler_KeyUp;
            KeyPress += eventHandler_KeyPress;
        }

        #endregion

        #region Protected Methods

        protected override bool IsInputKey(Keys keyData)
        {
            if (IsCommandInput)
            {
                return true;
            }
            else
            {
                return base.IsInputKey(keyData);
            }
        }

        #endregion

        #region Private Event Handlers

        private void eventHandler_KeyDown(object sender, KeyEventArgs e)
        {
            //if it's not a command input - do nothing
            if (!IsCommandInput)
                return;

            if (!_pressedButtons.Contains(e.KeyValue))
            {
                //if it's a multi-key command - print "-"
                if (e.Alt && e.KeyValue != (int)Keys.Menu || 
                    e.Control && e.KeyValue != (int)Keys.ControlKey || 
                    e.Shift && e.KeyValue != (int)Keys.ShiftKey)
                {
                    Text += "-";
                }
                else
                {
                    if (Text.Length > 0)
                        Text += ",";
                }

                //add string representation for key
                Text += WinAPIHelpers.GetKeyStringForVirtualCode((byte)e.KeyValue);

                //place caret to the end
                SelectionStart = Text.Length;

                _pressedButtons.Add(e.KeyValue);
            }

            e.Handled = true;
        }

        private void eventHandler_KeyUp(object sender, KeyEventArgs e)
        {
            if (IsCommandInput)
            {
                _pressedButtons.Remove(e.KeyValue);
                e.Handled = true;
            }
        }

        private void eventHandler_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (IsCommandInput)
            {
                e.Handled = true;
            }
        }

        #endregion
    }
}
