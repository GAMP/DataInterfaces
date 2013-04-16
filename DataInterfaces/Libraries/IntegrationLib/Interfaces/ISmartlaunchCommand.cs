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
        string Command { get; }
        List<string> Arguments { get; }
        string ArgumentsString { get; }
        bool HasArguments { get; }
    } 
    #endregion
}
