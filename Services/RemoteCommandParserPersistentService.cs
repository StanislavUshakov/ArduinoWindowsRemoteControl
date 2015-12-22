using Arduino;
using Arduino.Parsers;
using Core.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
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

        /// <summary>
        /// Loads ArduinoRemoteCommandParser object from file with specified name
        /// </summary>
        /// <param name="filename">File with the saved ArduinoRemoteCommandParser</param>
        /// <returns></returns>
        public ArduinoRemoteCommandParser LoadArduinoCommandParser(string filename)
        {
            var dictionary = _dictionaryRepository.Load<string, RemoteCommand>(filename);

            return new ArduinoRemoteCommandParser(dictionary);
        }

        /// <summary>
        /// Saves ArduinoRemoteCommandParser object to file
        /// </summary>
        /// <param name="commandParser">Object to be saved</param>
        /// <param name="filename">Filename which will be used for saving</param>
        public void SaveArduinoCommandParser(ArduinoRemoteCommandParser commandParser, string filename)
        {
            _dictionaryRepository.Save(commandParser.CommandsMapping, filename);
        }

        #endregion
    }
}
