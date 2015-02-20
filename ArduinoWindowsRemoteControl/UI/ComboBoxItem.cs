using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoWindowsRemoteControl.UI
{
    /// <summary>
    /// Auxiliary class for ComboBox control
    /// </summary>
    public class ComboboxItem
    {
        /// <summary>
        /// Gets and sets user friendly string representation
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets value
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Simply returns user friendly string representation
        /// </summary>
        /// <returns>User friendly string representation</returns>
        public override string ToString()
        {
            return Text;
        }
    }
}
