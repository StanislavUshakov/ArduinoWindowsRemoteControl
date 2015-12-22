using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino.Parsers
{
    /// <summary>
    /// Class for parser that returns the same string
    /// </summary>
    public class SimpleStringParser : IRemoteCommandParser<string>
    {
        #region IRemoteCommandParser Members

        public string Parse(string command)
        {
            return command.Trim();
        }

        #endregion
    }
}
