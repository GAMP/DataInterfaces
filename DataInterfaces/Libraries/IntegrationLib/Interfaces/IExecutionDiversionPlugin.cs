using Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntegrationLib
{
    public interface IExecutionDivertPlugin
    {
        /// <summary>
        /// Diverts process creation to plugin.
        /// </summary>
        /// <param name="context">Execution context.</param>
        /// <returns>True if execution diverted , false otherwise.</returns>
        bool DivertExecution(IExecutionContext context);
    }
}
