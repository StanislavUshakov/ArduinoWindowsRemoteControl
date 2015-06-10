using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteInputTuner.Models
{
    /// <summary>
    /// Class for storing association between HEX command code (received form the 
    /// </summary>
    public class RemoteCommandBinding
    {
        #region Constructor

        public RemoteCommandBinding(string hexCode, RemoteCommand command)
        {
            HexCode = hexCode;
            RemoteCommand = command;
        }

        #endregion

        #region Public Properties

        public string HexCode { get; set; }

        public RemoteCommand RemoteCommand { get; set; }

        #endregion
    }
}
