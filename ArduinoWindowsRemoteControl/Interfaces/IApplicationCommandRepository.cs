using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoWindowsRemoteControl.Interfaces
{
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
        /// <returns>List of IApplicationCommand objects</returns>
        List<IApplicationCommand> Load();
    }
}
