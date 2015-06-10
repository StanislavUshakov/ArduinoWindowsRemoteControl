using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    /// <summary>
    /// This interface will be used for translating output from the remote input device to another entity (RemoteCommand, string, etc)
    /// </summary>
    /// <typeparam name="T">Type of objects to which messages will be translated</typeparam>
    public interface IRemoteCommandParser<T>
    {
        /// <summary>
        /// For the output from the remote device returns matching RemoteCommand
        /// </summary>
        /// <param name="command">Output from the remote device</param>
        /// <returns>Matching Value</returns>
        T Parse(string command);
    }
}
