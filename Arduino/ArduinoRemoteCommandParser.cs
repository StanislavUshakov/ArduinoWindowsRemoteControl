using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino
{
    /// <summary>
    /// This class parses output from the Arduino device and returns appropriate RemoteCommand
    /// </summary>
    public class ArduinoRemoteCommandParser : IRemoteCommandParser
    {
        #region Private Fields

        private Dictionary<int, RemoteCommand> _commandsMapping;

        #endregion

        #region Constructor

        public ArduinoRemoteCommandParser(Dictionary<int, RemoteCommand> commandsMapping)
        {
            _commandsMapping = commandsMapping;
        }

        #endregion

        #region Public Properties

        public Dictionary<int, RemoteCommand> CommandsMapping
        {
            get
            {
                return new Dictionary<int,RemoteCommand>(_commandsMapping);
            }
        }

        #endregion

        #region IRemoteCommandParser Members

        public RemoteCommand Parse(int commandCode)
        {
            if (!_commandsMapping.ContainsKey(commandCode))
            {
                throw new ArgumentException("No mapping for command: " + commandCode);
            }

            return _commandsMapping[commandCode];
        }

        #endregion
    }
}
