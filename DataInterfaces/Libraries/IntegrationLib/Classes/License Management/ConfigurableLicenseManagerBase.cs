using System;

namespace IntegrationLib
{
    /// <summary>
    /// Configurable license manager base class.
    /// </summary>
    /// <remarks>
    /// Use this base class when implementing license manager plugins that require configuration settings.
    /// </remarks>
    public abstract class ConfigurableLicenseManagerBase : LicenseManagerBase, IConfigurableLicenseManager
    {
        private IPluginSettings settings;

        /// <summary>
        /// Gets plugin settings instance.
        /// </summary>
        public IPluginSettings Settings
        {
            get { return settings; }
            protected set
            {
                settings = value;
                RaisePropertyChanged("Settings");
            }
        }

        /// <summary>
        /// Initializes plugin to stored settings.
        /// </summary>
        /// <param name="settings">IPluginSettings instance.</param>
        public void Initialize(IPluginSettings settings)
        {
            Settings = settings ?? throw new ArgumentNullException("Plugin settings may not be null");
            OnInitialized(settings);
        }

        /// <summary>
        /// Called once plugin was initialized to stored settings.
        /// </summary>
        /// <param name="settings"></param>
        public virtual void OnInitialized(IPluginSettings settings)
        {
        }

        /// <summary>
        /// When overridden should return a new instance of plugin settings.
        /// <remarks>Plugin settings instance must be marked serializable and implement IPluginSettings.</remarks>
        /// </summary>
        /// <returns>IPlugin settings instance for this plugin.</returns>
        public abstract IPluginSettings GetSettingsInstance();

        /// <summary>
        /// Casts the settings instance to specified type.
        /// </summary>
        /// <typeparam name="T">Settings class type.</typeparam>
        /// <returns>Settings instance.</returns>
        public T SettingsAs<T>()
        {
            return (T)Settings;
        }

        /// <summary>
        /// Throws argument exception if specified plugin settings type is invalid.
        /// </summary>
        protected void ThrowIfSettingsTypeInvalid()
        {
            if (Settings.GetType() != GetSettingsInstance().GetType())
                throw new ArgumentException("Settings", "Plugin settings type is invalid");
        }
    }
}
