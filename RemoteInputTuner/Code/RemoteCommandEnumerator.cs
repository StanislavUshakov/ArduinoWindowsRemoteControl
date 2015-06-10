using Core.Interfaces;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteInputTuner.Code
{
    /// <summary>
    /// Enumerates available remote commands
    /// </summary>
    public class RemoteCommandEnumerator
    {
        #region Private Fields

        private List<string> _remoteCommands;
        private int _currentRemoteCommandIndex = 0;

        #endregion

        #region Constructor

        public RemoteCommandEnumerator()
        {
            _remoteCommands = EnumHelpers.GetAvailableEnumValues<RemoteCommand>().Select(t => t.Item1).ToList();
            _currentRemoteCommandIndex = 0;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns next available remote command
        /// </summary>
        /// <returns>String representation of the next remote command; null - if all remote commands have been enumerated</returns>
        public string GetNext()
        {
            if (_currentRemoteCommandIndex >= _remoteCommands.Count)
                return null;

            return _remoteCommands[_currentRemoteCommandIndex++];
        }

        #endregion
    }
}
