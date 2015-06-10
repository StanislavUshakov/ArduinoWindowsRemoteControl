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
    public class ArduinoRemoteCommandParser : IRemoteCommandParser<RemoteCommand>
    {
        #region Private Fields

        private Dictionary<string, RemoteCommand> _commandsMapping;

        #endregion

        #region Constructor

        public ArduinoRemoteCommandParser(Dictionary<string, RemoteCommand> commandsMapping)
        {
            _commandsMapping = commandsMapping;
        }

        #endregion

        #region Public Properties

        public Dictionary<string, RemoteCommand> CommandsMapping
        {
            get
            {
                return new Dictionary<string, RemoteCommand>(_commandsMapping);
            }
        }

        #endregion

        #region IRemoteCommandParser Members

        public RemoteCommand Parse(string commandCode)
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
