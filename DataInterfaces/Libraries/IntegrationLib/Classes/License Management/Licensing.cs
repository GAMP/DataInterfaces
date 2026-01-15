using System;
using SharedLib;
using Client;

namespace IntegrationLib
{
    #region LicenseManagerBase
    /// <summary>
    /// License manager base class.
    /// </summary>
    public abstract class LicenseManagerBase : PropertyChangedNotificator, ILicenseManagerPlugin
    {
        #region Functions

        public virtual void Install(IApplicationLicense license, IExecutionContext context, ref bool processCreated)
        {
            //do nothing
        }

        public virtual void Uninstall(IApplicationLicense license)
        {
            //do nothing
        }

        #endregion
    }
    #endregion

    #region ConfigurableLicenseManagerBase
    public abstract class ConfigurableLicenseManagerBase : LicenseManagerBase, IConfigurableLicenseManager
    {
        #region Fields
        private IPluginSettings settings;
        #endregion

        #region Properties
        /// <summary>
        /// Gets plugin settings instance.
        /// </summary>
        public IPluginSettings Settings
        {
            get { return this.settings; }
            protected set
            {
                this.settings = value;
                this.RaisePropertyChanged("Settings");
            }
        }
        #endregion

        #region Functions

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
            return (T)this.Settings;
        }

        /// <summary>
        /// Throws argument exception if specified plugin settings type is invalid.
        /// </summary>
        protected void ThrowIfSettingsTypeInvalid()
        {
            if (this.Settings.GetType() != this.GetSettingsInstance().GetType())
                throw new ArgumentException("Settings", "Plugin settings type is invalid");
        }

        #endregion
    }
    #endregion
}
