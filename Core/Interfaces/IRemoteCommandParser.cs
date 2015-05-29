using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    /// <summary>
    /// This interface will be used for translating output from the remote input device to RemoteCommand
    /// </summary>
    public interface IRemoteCommandParser
    {
        /// <summary>
        /// For the output from the remote device returns matching RemoteCommand
        /// </summary>
        /// <param name="commandCode">Output from the remote device</param>
        /// <returns>Matching RemoteCommand</returns>
        RemoteCommand Parse(int commandCode);
    }
}
