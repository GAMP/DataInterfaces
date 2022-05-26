using System;
using System.Windows.Controls;
using System.Windows;
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

        public virtual IApplicationLicenseKey GetLicense(ILicenseProfile profile, ref bool additionHandled, Window owner)
        {
            return null;
        }

        public virtual IApplicationLicenseKey EditLicense(IApplicationLicenseKey key, ILicenseProfile profile, ref bool additionHandled, Window owner)
        {
            return null;
        }

        public virtual bool CanEdit
        {
            get { return false; }
        }

        public virtual bool CanAdd
        {
            get { return true; }
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
            this.Settings = settings ?? throw new ArgumentNullException("Plugin settings may not be null");
            this.OnInitialized(settings);
        }

        /// <summary>
        /// Called once plugin was initialized to stored settings.
        /// </summary>
        /// <param name="settings"></param>
        public virtual void OnInitialized(IPluginSettings settings)
        {
        }

        /// <summary>
        /// When ovveriden should return a new instance of plugin settings.
        /// <remarks>Plugin settings instance must be marked serializable and implement IPluginSettings.</remarks>
        /// </summary>
        /// <returns>IPlugin settings instance for this plugin.</returns>
        public abstract IPluginSettings GetSettingsInstance();

        /// <summary>
        /// This method will be called internaly when Configuration ui is requested.
        /// </summary>
        /// <returns></returns>
        public abstract UserControl GetConfigurationUI();

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
