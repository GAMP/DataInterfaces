namespace IntegrationLib
{
    /// <summary>
    /// Configurable plugin interface.
    /// </summary>
    public interface IConfigurablePlugin : IPlugin
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Initializes the plugin to passed settings instance.
        /// </summary>
        /// <param name="settings">Settings instance.</param>
        void Initialize(IPluginSettings settings);

        /// <summary>
        /// Gets the instance of the settings used to initialize the plugin.
        /// </summary>
        IPluginSettings Settings { get; }

        /// <summary>
        /// This routine called once plugin initialization has completed.
        /// </summary>
        /// <param name="settings">Settings instance used to initialize the plugin.</param>
        void OnInitialized(IPluginSettings settings);

        /// <summary>
        /// Returns new settings instance for this plugin.
        /// </summary>
        /// <returns>IPlugin settings instance.</returns>
        IPluginSettings GetSettingsInstance(); 

        #endregion
    }
}
