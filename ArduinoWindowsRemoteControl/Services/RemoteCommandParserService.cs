using Arduino;
using ArduinoWindowsRemoteControl.Repositories;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoWindowsRemoteControl.Services
{
    /// <summary>
    /// Service that returns parsers for different remote input devices
    /// </summary>
    public class RemoteCommandParserService
    {
        #region Private Fields

        private DictionaryRepository _dictionaryRepository;

        #endregion

        #region Constructor

        public RemoteCommandParserService()
        {
            _dictionaryRepository = new DictionaryRepository();
        }

        #endregion

        #region Public Methods

        public ArduinoRemoteCommandParser LoadArduinoCommandParser(string filename)
        {
            var dictionary = _dictionaryRepository.Load<int, RemoteCommand>(filename);

            return new ArduinoRemoteCommandParser(dictionary);
        }

        public void SaveArduinoCommandParser(ArduinoRemoteCommandParser commandParser, string filename)
        {

        }

        #endregion
    }
}
