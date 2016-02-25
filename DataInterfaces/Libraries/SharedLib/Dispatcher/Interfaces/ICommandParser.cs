using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedLib.Commands;

namespace SharedLib.Dispatcher
{
    #region ICommandParser
    /// <summary>
    /// Base interface for an command parser.
    /// </summary>
    public interface ICommandParser
    {
        /// <summary>
        /// Tries to parse specified command.
        /// </summary>
        /// <param name="cmd">Command to parse.</param>
        /// <returns>True if parsed sucessfully; otherwise, false.</returns>
        bool TryParse(IDispatcherCommand cmd);
    } 
    #endregion
}
