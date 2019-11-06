using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using SharedLib;
using SharedLib.Dispatcher;
using Client;
using System.Runtime.Serialization;

namespace IntegrationLib
{
    #region ApplicationLicenseBase
    /// <summary>
    /// Application license base class.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public abstract class ApplicationLicenseBase : ItemBase, IApplicationLicense
    {
        #region FILEDS
        [NonSerialized()]
        private bool mboolIsLocal;
        [NonSerialized()]
        private LicenseStatus status;
        [NonSerialized()]
        private string comment;
        private IApplicationLicenseKey key;
        private Guid guid;
        [OptionalField(VersionAdded = 2)]
        private string licenseProfileName;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or Sets keys local value.
        /// </summary>
        /// <returns>This will be used with multisite license management.</returns>
        [IgnoreDataMember()]
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
        [DataMember()]
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
        /// </summary>
        /// <remarks>
        /// This can be an actual serial number if the license object is binary file.
        /// This can help you track individual licenses.
        /// </remarks>
        [DataMember()]
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
        [IgnoreDataMember()]
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
        /// Gets or sets license profile name.
        /// </summary>
        [DataMember()]
        public string LicenseProfileName
        {
            get { return this.licenseProfileName; }
            set { this.licenseProfileName = value; }
        }

        #endregion

        #region FUNCTIONS

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
    [DataContract()]
    public sealed class ApplicationLicense : ApplicationLicenseBase
    {
        #region CONSTRUCTOR

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
    [DataContract()]
    public abstract class ApplicationLicenseKeyBase : PropertyChangedNotificator,
        IApplicationLicenseKey
    {
        #region FIELDS
        private string value;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets keys string value.
        /// </summary>
        [IgnoreDataMember()]
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
        /// When overriden should return key string representation.
        /// </summary>
        [DataMember()]
        public virtual string KeyString
        {
            get { return this.Value; }
        }

        /// <summary>
        /// When ovveriden returns if current key is valid.
        /// </summary>
        [IgnoreDataMember()]
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
    [DataContract()]
    public class LicenseReservation : ItemObject, ILicenseReservation
    {
        #region CONSTRUCTOR

        public LicenseReservation()
        { }

        public LicenseReservation(int id, Dictionary<int, IApplicationLicense> licenses, IMessageDispatcher dispatcher)
        {
            this.Id = id;
            this.Licenses = licenses;
            this.Dispatcher = dispatcher;
            this.HostId = hostId;
        }

        #endregion

        #region FIELDS
        private Dictionary<int, IApplicationLicense> licenses;
        [NonSerialized()]
        private IMessageDispatcher dispatcher;
        [OptionalField(VersionAdded = 2)]
        private int hostId;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets the list of reserved licenses.
        /// </summary>
        [IgnoreDataMember()]
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
        [IgnoreDataMember()]
        public IMessageDispatcher Dispatcher
        {
            get { return this.dispatcher; }
            protected set { this.dispatcher = value; }
        }

        /// <summary>
        /// Gets application name.
        /// </summary>
        [DataMember(Order = 0)]
        public string Application
        {
            get;
            set;
        }

        /// <summary>
        /// Gets executable name.
        /// </summary>
        [DataMember(Order = 1)]
        public string Executable
        {
            get;
            set;
        }

        /// <summary>
        /// Gets host id.
        /// </summary>
        [DataMember(Order = 3)]
        public int HostId
        {
            get { return this.hostId; }
            set { this.hostId = value; }
        }

        /// <summary>
        /// Gets license keys.
        /// </summary>
        [DataMember(Order = 3)]
        public IEnumerable<IApplicationLicense> LicenseKeys
        {
            get { return this.Licenses.Values; }
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
