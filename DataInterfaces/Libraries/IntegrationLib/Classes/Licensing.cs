using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows;
using SharedLib.Applications;
using SharedLib;
using SharedLib.Dispatcher;
using Client;

namespace IntegrationLib
{
    #region ApplicationLicenseBase
    /// <summary>
    /// Application license base class.
    /// </summary>
    [Serializable()]
    public abstract class ApplicationLicenseBase : ItemBase, IApplicationLicense
    {
        #region Fileds
        [NonSerialized()]
        private bool mboolIsLocal;
        [NonSerialized()]
        private LicenseStatus status;
        [NonSerialized()]
        private string comment;
        private IApplicationLicenseKey key;
        private Guid guid;
        #endregion

        #region Properties

        /// <summary>
        /// Gets or Sets keys local value.
        /// </summary>
        /// <returns>This will be used with multisite license management.</returns>
        public virtual bool IsLocal
        {
            get
            {
                return this.mboolIsLocal;
            }
            set
            {
                this.mboolIsLocal = value;
                this.RaisePropertyChanged("IsLocal");
            }
        }

        /// <summary>
        /// Gets or sets license key.
        /// </summary>
        public virtual IApplicationLicenseKey Key
        {
            get { return this.key; }
            set
            {
                this.key = value;
                this.RaisePropertyChanged("Key");
            }
        }

        /// <summary>
        /// Gets or set real time status of license usage.
        /// </summary>
        public LicenseStatus Status
        {
            get { return this.status; }
            set
            {
                this.status = value;
                this.RaisePropertyChanged("Status");
            }
        }

        /// <summary>
        /// Gets or sets licenses comment.
        /// <remarks>
        /// This can be an actual serial number if the license object is binary file.
        /// This can help you track individual licenses.
        /// </remarks>
        public string Comment
        {
            get { return this.comment; }
            set
            {
                this.comment = value;
                this.RaisePropertyChanged("Comment");
            }
        }

        /// <summary>
        /// Gets or sets a unique global license identifier.
        /// </summary>
        public Guid Guid
        {
            get
            {
                if (this.guid == Guid.Empty)
                {
                    this.guid = Guid.NewGuid();
                }
                return this.guid;
            }
            set
            {
                this.guid = value;
                this.RaisePropertyChanged("Guid");
            }
        }

        /// <summary>
        /// Returns key instance as specified T type.
        /// </summary>
        public T KeyAs<T>()
        {
            return (T)this.Key;
        }

        #endregion
    }
    #endregion

    #region ApplicationLicense
    [Serializable()]
    public sealed class ApplicationLicense : ApplicationLicenseBase
    {
        #region Constructor

        /// <summary>
        /// Creates new ApplicationLicense instance.
        /// </summary>
        public ApplicationLicense()
        { }

        /// <summary>
        /// Creates new ApplicationLicense instance.
        /// </summary>
        /// <param name="key">License key.</param>
        public ApplicationLicense(IApplicationLicenseKey key)
        {
            if (key != null)
            {
                this.Key = key;
            }
            else
            {
                throw new ArgumentNullException("Key", "License key may not be null.");
            }
        }

        #endregion
    }
    #endregion

    #region ApplicationLicenseKeyBase
    /// <summary>
    /// License Key Base Class.
    /// </summary>
    [Serializable()]
    public abstract class ApplicationLicenseKeyBase : PropertyChangedNotificator, IApplicationLicenseKey
    {
        #region Fields
        private string value;
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets keys string value.
        /// </summary>
        public string Value
        {
            get { return this.value; }
            set
            {
                this.value = value;
                this.RaisePropertyChanged("Value");
                this.RaisePropertyChanged("KeyString");
            }
        }

        /// <summary>
        /// When ovveriden return key string representation.
        /// </summary>
        public virtual string KeyString
        {
            get { return this.Value; }
        }

        /// <summary>
        /// When ovveriden returns if current key is valid.
        /// </summary>
        public virtual bool IsValid
        {
            get { return !String.IsNullOrWhiteSpace(this.Value); }
        }

        #endregion
    }
    #endregion

    #region LicenseReservation
    /// <summary>
    /// License reservation class.
    /// </summary>
    [Serializable()]
    public class LicenseReservation : ItemObject, ILicenseReservation
    {
        #region Constructor

        public LicenseReservation()
        { }

        public LicenseReservation(int id,
            Dictionary<int, IApplicationLicense> licenses,
            IMessageDispatcher dispatcher)
        {
            this.Id = id;
            this.Licenses = licenses;
            this.Dispatcher = dispatcher;
        }

        #endregion

        #region Fields
        private Dictionary<int, IApplicationLicense> licenses;
        [NonSerialized()]
        private IMessageDispatcher dispatcher;
        #endregion

        #region Properties

        /// <summary>
        /// Gets the list of reserved licenses.
        /// </summary>
        public Dictionary<int, IApplicationLicense> Licenses
        {
            get
            {
                if (this.licenses == null)
                    this.licenses = new Dictionary<int, IApplicationLicense>();
                return this.licenses;
            }
            protected set { this.licenses = value; }
        }

        /// <summary>
        /// Gets the message dispatcher.
        /// </summary>
        public IMessageDispatcher Dispatcher
        {
            get { return this.dispatcher; }
            protected set { this.dispatcher = value; }
        }

        /// <summary>
        /// Gets application name.
        /// </summary>
        public string Application
        {
            get;
            set;
        }

        /// <summary>
        /// Gets executable name.
        /// </summary>
        public string Executable
        {
            get;
            set;
        }

        #endregion
    }
    #endregion

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
            if (settings == null)
                throw new ArgumentNullException("Plugin settings may not be null");

            this.Settings = settings;
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
