using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    /// <summary>
    /// Factory for creating ICommand objects
    /// </summary>
    public interface ICommandFactory
    {
        /// <summary>
        /// Creates an instance of ICommand
        /// </summary>
        /// <param name="command">Command specification</param>
        /// <returns>ICommand object</returns>
        ICommand Create(string command);
    }
}
