using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntegrationLib
{
    /// <summary>
    /// Plugin module interface.
    /// </summary>
    public interface IPluginModule : IPlugin
    {
        /// <summary>
        /// Starts the module.
        /// <remarks>Responsible for plugin module initiation.</remarks>
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the module.
        /// <remarks>Responsible for plugin module termination.</remarks>
        /// </summary>
        void Stop();
        
        /// <summary>
        /// Initializes the module.
        /// <remarks>Responsible for plugin module initialization.</remarks>
        /// </summary>
        void Initialize();
    }
}
