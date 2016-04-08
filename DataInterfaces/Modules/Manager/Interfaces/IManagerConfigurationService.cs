using SharedLib.Configuration;
using System;

namespace Manager.Services
{
    public interface IManagerConfigurationService
    {
        /// <summary>
        /// Gets configuration.
        /// </summary>
        /// <returns>Configuration instance.</returns>
        ManagerConfig GetConfiguration();

        /// <summary>
        /// Occurs on configuration change.
        /// </summary>
        event EventHandler<EventArgs> ConfigurationChanged;
        
        /// <summary>
        /// Saves configuration.
        /// </summary>
        /// <param name="config">Configuration isntance.</param>
        void Save(ManagerConfig config);
        
        /// <summary>
        /// Gets current configuration.
        /// </summary>
        ManagerConfig Current { get; }
        
        /// <summary>
        /// Saves current configuration.
        /// </summary>
        void Save();

        /// <summary>
        /// Gets if configuration is in initial state.
        /// </summary>
        bool IsInitial
        {
            get;
        }
     }
}
