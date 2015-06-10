using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteInputTuner.Models
{
    /// <summary>
    /// Model for stroing serial port information - name
    /// </summary>
    public class SerialPortModel
    {
        #region Constructor

        public SerialPortModel(string name)
        {
            Name = name;
        }

        #endregion

        #region Public Properties

        public string Name { get; set; }

        #endregion
    }
}
