using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    /// <summary>
    /// Represents action that can be triggered by the remote control.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Execute command
        /// </summary>
        void Do();
    }
}
