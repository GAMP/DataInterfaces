using SharedLib.Configuration;
using System;

namespace Manager.Services
{
    /// <summary>
    /// Manager configuration service interface.
    /// </summary>
    public interface IManagerConfigurationService
    {
        #region EVENTS
        
        /// <summary>
        /// Occurs on configuration change.
        /// </summary>
        event EventHandler<EventArgs> ConfigurationChanged;

        #endregion

        #region PROPERTIES
        
        /// <summary>
        /// Gets current configuration.
        /// </summary>
        ManagerConfig Current { get; }

        /// <summary>
        /// Gets if configuration is in initial state.
        /// </summary>
        bool IsInitial
        {
            get;
        }

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Gets configuration.
        /// </summary>
        /// <returns>Configuration instance.</returns>
        ManagerConfig GetConfiguration();

        /// <summary>
        /// Saves configuration.
        /// </summary>
        /// <param name="config">Configuration isntance.</param>
        void Save(ManagerConfig config);

        /// <summary>
        /// Saves current configuration.
        /// </summary>
        void Save(); 

        #endregion
    }
}
