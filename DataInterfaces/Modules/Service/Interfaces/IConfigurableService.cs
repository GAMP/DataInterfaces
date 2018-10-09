using SharedLib.Configuration;
using System.Threading.Tasks;

namespace ServerService
{
    #region IConfigurableService
    public interface IConfigurableService
    {
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
