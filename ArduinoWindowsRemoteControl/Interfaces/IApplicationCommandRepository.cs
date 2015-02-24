using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoWindowsRemoteControl.Interfaces
{
    /// <summary>
    /// Data Transfer Object for IApplicationCommand entity
    /// USed for retrieving information from Data Source
    /// </summary>
    public class ApplicationCommandDTO
    {
        public string ApplicationName { get; set; }
        public RemoteCommand RemoteCommand { get; set; }
        public string Command { get; set; }
    }

    /// <summary>
    /// Represents repository for IApplicationCommand objects
    /// </summary>
    public interface IApplicationCommandRepository
    {
        /// <summary>
        /// Save commands
        /// </summary>
        /// <param name="commands">Commands to be saved</param>
        void Save(IEnumerable<IApplicationCommand> commands);

        /// <summary>
        /// Retrieve a list of commands
        /// </summary>
        /// <returns>List of ApplicationCommandDTO objects</returns>
        List<ApplicationCommandDTO> Load();
    }
}
