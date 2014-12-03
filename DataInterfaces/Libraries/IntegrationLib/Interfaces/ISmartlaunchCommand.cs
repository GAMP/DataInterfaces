using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedLib.Commands;

namespace IntegrationLib
{
    #region ISmartlaunchCommand
    public interface ISmartlaunchCommand : IExecutionCommand
    {
        /// <summary>
        /// Gets command string.
        /// </summary>
        string Command { get; }

        /// <summary>
        /// Gets command arguments.
        /// </summary>
        List<string> Arguments { get; }
        
        /// <summary>
        /// Gets arguments string.
        /// <remarks>
        /// This is raw command arguments representation string.
        /// </remarks>
        /// </summary>
        string ArgumentsString { get; }

        /// <summary>
        /// Gets if command contains arguments.
        /// </summary>
        bool HasArguments { get; }
    } 
    #endregion
}
