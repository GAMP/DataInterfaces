using SharedLib.Configuration;
using System;
using System.Threading.Tasks;

namespace ServerService
{
    #region IConfigurableService
    /// <summary>
    /// Configurable service interface.
    /// </summary>
    public interface IConfigurableService
    {
        #region EVENTS

        /// <summary>
        /// Occurs on settings file (service.json) change.
        /// </summary>
        event EventHandler<SettingsChangedEventArgs> SettingsChange;

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Gets service configuration.
        /// </summary>
        /// <returns>Root service configuration.</returns>
        ConfigurationRoot ConfigurationGet();

        /// <summary>
        /// Sets service configuration.
        /// </summary>
        /// <param name="configuration">Service configuration root.</param>
        void ConfigurationSet(ConfigurationRoot configuration);

        #endregion        
    }
    #endregion

    #region IConfigurableServiceAsync
    /// <summary>
    /// Configurable service async interface.
    /// </summary>
    public interface IConfigurableServiceAsync : IConfigurableService
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Gets service configuration asynchronously.
        /// </summary>
        /// <returns>Configuration instance.</returns>
        Task<ConfigurationRoot> ConfigurationGetAsync();

        /// <summary>
        /// Sets service configuration asynchronously.
        /// </summary>
        /// <param name="settings">Configuration instance.</param>
        /// <returns>Associated task.</returns>
        Task ConfigurationSetAsync(ConfigurationRoot settings); 

        #endregion
    } 
    #endregion
}
