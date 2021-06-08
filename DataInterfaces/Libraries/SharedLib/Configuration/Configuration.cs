using Client;
using Client.ViewModels;
using Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace SharedLib.Configuration
{
    #region CONFIGBASE
    /// <summary>
    /// Configuration base class.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public abstract class ConfigBase
    {
        /// <summary>
        /// Sets all properties to default values.
        /// </summary>
        public virtual void SetDefaults()
        {
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(this))
                property.ResetValue(this);
        }

        /// <summary>
        /// Setst default value for specified property.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        public void SetDefault(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentNullException(nameof(propertyName));

            var property = TypeDescriptor.GetProperties(this)[propertyName];
            if (property.CanResetValue(this))
                property.ResetValue(this);
        }

        /// <summary>
        /// Gets validation results.
        /// </summary>
        /// <returns>Grouped validation results.</returns>
        public IEnumerable<IGrouping<string, ValidationResult>> GetValidationResults()
        {
            //create new validation contect
            var validationContext = new ValidationContext(this, null, null);

            //create store for validation results
            var validationResults = new List<ValidationResult>();

            //validate using data annotation validator
            Validator.TryValidateObject(this, validationContext, validationResults, true);

            //Group validation results by property names
            var resultsByPropertyNames = from res in validationResults
                                         from mname in res.MemberNames
                                         group res by mname into g
                                         select g;

            return resultsByPropertyNames;
        }

        /// <summary>
        /// Gets names of the properties with invalid values.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetInvalidPropertyNames()
        {
            return GetValidationResults()
                .Select(x => x.Key);
        }

        /// <summary>
        /// Resets invalid properties to its default values.
        /// <remarks>
        /// The reset will only occur if property have an DefaultValue attribute set.
        /// </remarks>
        /// </summary>
        public void ResetInvalidProperties()
        {
            GetInvalidPropertyNames()
                .ToList()
                .ForEach(x => SetDefault(x));
        }
    }
    #endregion

    #region CONFIGURATION
    /// <summary>
    /// Service configuration root class.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class ConfigurationRoot : ConfigBase
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        public ConfigurationRoot()
        {
            Service = new ServiceConfig();
            Client = new ClientConfig();
            Global = new GlobalConfiguration();
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets general network section. 
        /// </summary>
        [Category("Global")]
        [Description("Global configuration")]
        [DataMember(Order = 0)]
        public GlobalConfiguration Global
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets service configuration section.
        /// </summary>
        [Category("Service")]
        [Description("Service configuration.")]
        [DataMember(Order = 1)]
        public ServiceConfig Service
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets client configuration section.
        /// </summary>
        [Category("Client")]
        [Description("Client configuration.")]
        [DataMember(Order = 2)]
        public ClientConfig Client
        {
            get;
            set;
        }

        #endregion

        #region OVERRIDES
        /// <summary>
        /// Sets default values.
        /// </summary>
        public override void SetDefaults()
        {
            base.SetDefaults();
            Service.SetDefaults();
            Client.SetDefaults();
            Global.SetDefaults();
        }
        #endregion
    }
    #endregion

    #region GLOBALCONFIGURATION

    /// <summary>
    /// Global configuration class.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class GlobalConfiguration : ConfigBase
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        public GlobalConfiguration()
        {
            Network = new GlobalNetworkCfg();
            Subscription = new GlobalSubscriptionConfig();
            Reservation = new ReservationConfig();
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets general network section. 
        /// </summary>
        [Category("Network")]
        [Description("Network configuration.")]
        [DataMember(Order = 0)]
        public GlobalNetworkCfg Network
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets subscription configuration.
        /// </summary>
        [Category("Subscription")]
        [Description("Subscription configuration.")]
        [DataMember(Order = 1)]
        public GlobalSubscriptionConfig Subscription
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets financial configuration.
        /// </summary>
        [Category("Financial")]
        [Description("Financial configuration.")]
        [DataMember(Order = 2)]
        public FinancialConfig Financial
        {
            get; set;
        }

        /// <summary>
        /// Waiting lines configuration.
        /// </summary>
        [Category("Waiting Line")]
        [Description("Waiting line configuration.")]
        [DataMember(Order = 2)]
        public WaitingLineConfig WaitingLine
        {
            get; set;
        }

        /// <summary>
        /// Reservation configuration.
        /// </summary>
        [Category("Reservations")]
        [Description("Reservations configuration.")]
        [DataMember(Order = 3)]
        public ReservationConfig Reservation
        {
            get; set;
        }

        #endregion

        #region OVERRIDES
        /// <summary>
        /// Sets default values.
        /// </summary>
        public override void SetDefaults()
        {
            Network.SetDefaults();
            Subscription.SetDefaults();
        }
        #endregion
    }

    /// <summary>
    /// Waiting line configuration class.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class WaitingLineConfig : ConfigBase
    {
        /// <summary>
        /// Gets or sets if logout grace period should be enabled.
        /// </summary>
        [DefaultValue(false)]
        [DataMember()]
        public bool EnableLogoutGreacePeriod
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets logout grace period in minutes.
        /// </summary>
        [DefaultValue(30)]
        [Range(1, int.MaxValue)]
        [DataMember()]
        public int LogoutGracePeriod
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if user should be removed from all waiting lines on login.
        /// </summary>
        [DefaultValue(true)]
        [DataMember()]
        public bool RemoveFromAllOnLogin
        {
            get; set;
        }

        /// <summary>
        /// Gets waiting line next in line time.
        /// </summary>
        [DefaultValue(30)]
        [Range(1, int.MaxValue)]
        [DataMember()]
        public int NextInLineTime
        {
            get; set;
        }

        /// <summary>
        /// Gets global waiting line remove time.
        /// </summary>
        [DefaultValue(30)]
        [Range(1, int.MaxValue)]
        [DataMember()]
        public int RemoveTime
        {
            get; set;
        }
    }

    /// <summary>
    /// Global network configuration class.
    /// </summary>
    [DataContract()]
    [Serializable()]
    public class GlobalNetworkCfg : ConfigBase
    {
        #region PROPERTIES
        /// <summary>
        /// Enables or Disables keep alive.
        /// </summary>
        [Category("Network")]
        [Description("Enables or disables TCP keep alive.")]
        [DefaultValue(true)]
        [DataMember(Order = 0)]
        public virtual bool EnableKeepAlive
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets kepp alive timeout value.
        /// </summary>
        [Category("Network")]
        [Description("Specifies TCP keep alive timeout.")]
        [DefaultValue(1000)]
        [DataMember(Order = 1)]
        public virtual long KeepAliveTimeout
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets keep alive period time.
        /// </summary>
        [Category("Network")]
        [Description("Specifies TCP keep alive period.")]
        [DefaultValue(1000)]
        [DataMember(Order = 2)]
        public virtual long KeepAlivePeriod
        {
            get;
            set;
        }
        #endregion
    }

    /// <summary>
    /// Global subcscription configuration class.
    /// </summary>
    [DataContract()]
    [Serializable()]
    public class GlobalSubscriptionConfig : ConfigBase
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets license username.
        /// </summary>
        [Category("Subscription")]
        [DefaultValue(null)]
        [Description("Subscription username.")]
        [DataMember()]
        public string SubscriptionUsername
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets license password.
        /// </summary>
        [Category("Subscription")]
        [DefaultValue(null)]
        [Description("Subscription password.")]
        [DataMember()]
        public string SubscriptionPassword
        {
            get;
            set;
        }

        #endregion
    }

    #region RESERVATIONCONFIG
    /// <summary>
    /// Reservation configuration class.
    /// </summary>
    [Category("Reservations")]
    [Serializable()]
    [DataContract()]
    public class ReservationConfig : ConfigBase
    {
        #region PROPERTIES

        /// <summary>
        /// Enables blocking login on hosts with upcoming reservations.
        /// </summary>
        [DataMember(Order = 0)]
        [DefaultValue(true)]
        public bool EnableLoginBlock
        {
            get; set;
        }

        /// <summary>
        /// Time in minutes before upcoming reservation to block login.
        /// </summary>
        [DataMember(Order = 1)]
        [DefaultValue(30)]
        [Range(0, int.MaxValue)]
        public int LoginBlockTime
        {
            get; set;
        }

        /// <summary>
        /// Enables unblocking login for active reservation.
        /// </summary>
        [DataMember(Order = 2)]
        [DefaultValue(false)]
        public bool EnableLoginUnblock
        {
            get; set;
        }

        /// <summary>
        /// Time in minutes before unblocking login for active reservation.
        /// </summary>
        [DataMember(Order = 3)]
        [DefaultValue(30)]
        [Range(0, int.MaxValue)]
        public int LoginUnblockTime
        {
            get; set;
        }

        #endregion
    }
    #endregion

    #endregion

    #region SERVICECONFIGURATION

    /// <summary>
    /// Service configuration class.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class ServiceConfig : ConfigBase
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        public ServiceConfig()
        {
            Network = new ServiceNetworkConfig();
            Database = new ServiceDatabaseConfig();
            Web = new ServiceWebConfig();
            FileSystem = new ServiceFileSystemConfig();
            General = new ServiceGeneralConfig();
            Web = new ServiceWebConfig();
            Backup = new ServiceBackupConfig();
            SMTP = new SMTPConfig();
            SMSGateway = new SMSGatewayConfig();
            Scheduler = new SchedulerConfig();
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets network configuration.
        /// </summary>
        [Category("Network")]
        [Description("Network configuraton.")]
        [DataMember(Order = 0)]
        public ServiceNetworkConfig Network
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets database configuration.
        /// </summary>
        [Category("Database")]
        [Description("Network configuration.")]
        [DataMember(Order = 1)]
        public ServiceDatabaseConfig Database
        {
            get;
            set;
        }

        /// <summary>
        /// Web configuration.
        /// </summary>
        [Category("Web")]
        [Description("Web configuration.")]
        [DataMember(Order = 2)]
        public ServiceWebConfig Web
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets file system configuration.
        /// </summary>
        [Category("File System")]
        [Description("File system configration.")]
        [DataMember(Order = 3)]
        public ServiceFileSystemConfig FileSystem
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets general configuration.
        /// </summary>
        [Category("General")]
        [Description("General configuration.")]
        [DataMember(Order = 4)]
        public ServiceGeneralConfig General
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets backup configuration.
        /// </summary>
        [Category("Backup")]
        [Description("Backup configuration.")]
        [DataMember(Order = 5)]
        public ServiceBackupConfig Backup
        {
            get; set;
        }

        /// <summary>
        /// SMTP configuration.
        /// </summary>
        [Category("SMTP Server")]
        [Description("SMTP Server configuration.")]
        [DataMember(Order = 6)]
        public SMTPConfig SMTP
        {
            get; set;
        }

        /// <summary>
        /// SMS Gateway configuration.
        /// </summary>
        [Category("SMS Gateway")]
        [Description("SMS Gateway configuration.")]
        [DataMember(Order = 7)]
        public SMSGatewayConfig SMSGateway
        {
            get; set;
        }

        /// <summary>
        /// Scheduler configuration.
        /// </summary>
        [Category("Scheduler")]
        [Description("Scheduler configuration.")]
        [DataMember(Order = 8)]
        public SchedulerConfig Scheduler
        {
            get; set;
        }

        #endregion

        #region OVERRIDE
        /// <summary>
        /// Sets default values.
        /// </summary>
        public override void SetDefaults()
        {
            base.SetDefaults();
            Network.SetDefaults();
            Database.SetDefaults();
            Web.SetDefaults();
            FileSystem.SetDefaults();
            General.SetDefaults();
            Backup.SetDefaults();
            SMTP.SetDefaults();
            SMSGateway.SetDefaults();
        }
        #endregion
    }

    /// <summary>
    /// Service network configuration class.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class ServiceNetworkConfig : ConfigBase
    {
        #region PROPERTIES

        /// <summary>
        /// Gtes or Sets the network interface id that the service is bound to.
        /// </summary>
        [Category("Network")]
        [DefaultValue(null)]
        [Description("Bind interface id.")]
        [DataMember(Order = 0)]
        public string BindInterfaceID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets bind network address.
        /// </summary>
        [Category("Network")]
        [DefaultValue("0.0.0.0")]
        [Description("Network bind address for client connections.")]
        [DataMember(Order = 1)]
        [IPV4Annotation()]
        public string BindIpAddress
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets integer binding port value.
        /// </summary>
        [Category("Network")]
        [DefaultValue(44966)]
        [Description("Network bind port for client connections.")]
        [Range(1, 65536)]
        [DataMember(Order = 2)]
        public int BindPort
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets manager connections bind port.
        /// </summary> 
        [Category("Network")]
        [DefaultValue(44967)]
        [Description("Network bind port for manager connections.")]
        [Range(1, 65536)]
        [DataMember(Order = 3)]
        public int ManagerBindPort
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets ineteger backlog value.
        /// </summary>
        [Category("Network")]
        [Description("Specifies listener connections backlog.")]
        [DefaultValue(10)]
        [Range(1, 255)]
        [DataMember(Order = 4)]
        public int BackLog
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Multicasting Ip Address string.
        /// </summary>
        [Category("Network")]
        [DefaultValue("224.0.0.0")]
        [Description("Multicast data transmission address.")]
        [IPV4Annotation()]
        [DataMember(Order = 5)]
        public string MulticastIpAddress
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Multicasting port.
        /// </summary>
        [Category("Network")]
        [DefaultValue(47874)]
        [Description("Multicast data transmission port.")]
        [Range(1, 65536)]
        [DataMember(Order = 6)]
        public int MulticastPort
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Multicasting Time to live. 
        /// </summary>
        [Category("Network")]
        [DefaultValue(0)]
        [Description("Multicast time to live.")]
        [DataMember(Order = 7)]
        [Range(0, 255)]
        public int MulticastTtl
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets registered only option.
        /// </summary>
        [DefaultValue(false)]
        [Category("Network")]
        [Description("Disables connection of unregistered client hosts.")]
        [DataMember(Order = 8)]
        public bool RegisteredOnly
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if the hostnames should be restored on client machines.
        /// </summary>
        [Category("Network")]
        [DefaultValue(false)]
        [Description("Enables hostname restoring.")]
        [DataMember(Order = 9)]
        public bool RestoreHostnames
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if client auto discovery should be enabled.
        /// </summary>
        [Category("Network")]
        [DefaultValue(true)]
        [Description("Enables client auto discovery.")]
        [DataMember(Order = 10)]
        public bool AutoDiscoverClients
        {
            get;
            set;
        }

        #endregion
    }

    /// <summary>
    /// Service database configuration class.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class ServiceDatabaseConfig : ConfigBase
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or Sets type of this database.          
        /// </summary>
        /// <remarks>
        /// 0 MySQL 1 MSSQL
        /// </remarks>
        [Category("Database")]
        [DefaultValue(DatabaseType.MSSQLEXPRESS)]
        [Description("Specifies database type.")]
        [DataMember()]
        public DatabaseType DbType
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets database connection string.
        /// </summary>
        [Category("Database")]
        [DefaultValue(null)]
        [Description("Specifies database connection string.")]
        [DataMember()]
        public string DbConnectionString
        {
            get;
            set;
        }

        /// <summary>
        /// Database command timeout.
        /// </summary>
        [Category("Database")]
        [DefaultValue(null)]
        [Description("Specifies database command timeout.")]
        [DataMember()]
        public int? CommandTimeout
        {
            get; set;
        }

        #endregion
    }

    /// <summary>
    /// Service general configuration class.
    /// </summary>
    [DataContract()]
    [Serializable()]
    public class ServiceGeneralConfig : ConfigBase
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets if pending session should terminate.
        /// </summary>
        [DefaultValue(true)]
        [Category("General")]
        [Description("Enable or disable termination of pending user sessions.")]
        [DataMember(Order = 0)]
        public bool TerminatePendingSessions
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets timeout for pending user sessions.
        /// </summary>
        [DefaultValue(180)]
        [Category("General")]
        [Description("Specifies pending session timeout.")]
        [DataMember(Order = 1)]
        public int PendingSessionTimeout
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if user balance reprocessing should be forced.
        /// </summary>
        [Category("General")]
        [Description("Forces user balance reprocess.")]
        [DataMember(Order = 2)]
        public bool ForceUserBalanceReprocess
        {
            get; set;
        }

        /// <summary>
        /// Enables or disables client auto update.
        /// </summary>
        [DefaultValue(true)]
        [Category("General")]
        [Description("Enable or disable automatic client update.")]
        [DataMember(Order = 3)]
        public bool AutoUpdateClient
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets client auto downgrade should be enabled.
        /// </summary>
        [DefaultValue(true)]
        [Category("General")]
        [Description("Specifies client auto downgrade should be enabled.")]
        [DataMember(Order = 4)]
        public bool AutoDowngradeClient
        {
            get; set;
        }

        /// <summary>
        /// Memebr auto invoice.
        /// </summary>
        [Category("General")]
        [Description("Members auto invoice settings.")]
        [DataMember(Order = 5)]
        public AutoInvoiceConfig MemberAutoInvoice
        {
            get; set;
        }

        /// <summary>
        /// Guest auto invoice.
        /// </summary>
        [Category("General")]
        [Description("Guets auto invoice settings.")]
        [DataMember(Order = 6)]
        public AutoInvoiceConfig GuestAutoInvoice
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if members should relogin automatically.
        /// </summary>
        [DefaultValue(false)]
        [Category("General")]
        [Description("Enable or disable members automatic relogin.")]
        [DataMember(Order = 7)]
        public bool AutomaticReloginMembers
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if guests should relogin automatically.
        /// </summary>
        [DefaultValue(false)]
        [Category("General")]
        [Description("Enable or disable guests automatic relogin.")]
        [DataMember(Order = 8)]
        public bool AutomaticReloginGuests
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if disconnected clients should logout.
        /// </summary>
        [DefaultValue(false)]
        [Category("General")]
        [Description("Enable or disable logout for disconnected clients.")]
        [DataMember(Order = 9)]
        public bool LogoutDisconnectedClients
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if should withhold unpaid session deposits.
        /// </summary>
        [DefaultValue(false)]
        [Category("General")]
        [Description("Enable or disable withhold unpaid session deposits.")]
        [DataMember(Order = 10)]
        public bool WithholdUnpaidSessionDeposits
        {
            get;
            set;
        }
        #endregion
    }

    /// <summary>
    /// Service backup configuration class.
    /// </summary>
    [DataContract()]
    [Serializable()]
    public class ServiceBackupConfig : ConfigBase
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets if backup is enabled.
        /// </summary>
        [DataMember()]
        [DefaultValue(true)]
        public bool IsEnabled
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets backup folder.
        /// </summary>
        [DataMember()]
        public string BackupFolder
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets maximum amount of backup files to keep.
        /// </summary>
        [DefaultValue(30)]
        [DataMember()]
        public int MaxFiles
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets backup time.
        /// </summary>
        [DataMember()]
        public TimeSpan? Time
        {
            get; set;
        }

        #endregion

        #region OVERRIDES

        /// <summary>
        /// Sets default values.
        /// </summary>
        public override void SetDefaults()
        {
            base.SetDefaults();

            Time = new TimeSpan(6, 0, 0);
        }

        #endregion
    }

    /// <summary>
    /// Auto invoice configuration class.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class AutoInvoiceConfig : ConfigBase
    {
        #region PROPERTIES

        /// <summary>
        /// Auto invoice.
        /// </summary>
        [DataMember(Order = 0)]
        [DefaultValue(true)]
        public bool AutoInvoice
        {
            get; set;
        }

        /// <summary>
        /// After minutes.
        /// </summary>
        [DataMember(Order = 1)]
        [Range(0, int.MaxValue)]
        [DefaultValue(0)]
        public int AfterMinutes
        {
            get; set;
        }

        /// <summary>
        /// Auto pay.
        /// </summary>
        [DataMember(Order = 2)]
        [DefaultValue(true)]
        public bool AutoPay
        {
            get; set;
        }

        #endregion
    }

    #region SERVICEWEBCONFIG
    /// <summary>
    /// Service web configuration class.
    /// </summary>
    [DataContract()]
    [Serializable()]
    public class ServiceWebConfig : ConfigBase
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets or sets if web portal enabled.
        /// </summary>
        [DefaultValue(true)]
        [DataMember(Order = 0)]
        public bool EnableWebProtal
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets web portal port.
        /// </summary>
        [DefaultValue(80)]
        [Range(1, 65536)]
        [DataMember(Order = 1)]
        public int WebPortalPort
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if HTTPs connections should be enabled.
        /// </summary>
        [DefaultValue(false)]
        [DataMember(Order = 2)]
        public bool EnableSSL
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if HTTPs port.
        /// </summary>
        [DefaultValue(443)]
        [Range(1, 65536)]
        [DataMember(Order = 3)]
        public int SSLPort
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets PFX file path.
        /// </summary>
        [DefaultValue(null)]
        [DataMember(Order = 4)]
        public string PFXPath
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets PFX file password.
        /// </summary>
        [DefaultValue(null)]
        [DataMember(Order = 5)]
        public string PFXPassword
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets Token secret.
        /// </summary>
        [DefaultValue(null)]
        [DataMember(Order = 6, IsRequired = false)]
        public string TokenSecret
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets external host name.
        /// </summary>
        [DefaultValue("localhost")]
        [DataMember(Order = 7, IsRequired = false)]
        public string ExternalHostName
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets external port.
        /// </summary>
        [DefaultValue(80)]
        [Range(1, 65536)]
        [DataMember(Order = 7, IsRequired = false)]
        public int? ExternalPort
        {
            get; set;
        } 

        #endregion
    }
    #endregion

    #region SERVICEFILESYSTEMCONFIG
    /// <summary>
    /// Service file system configuration class.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class ServiceFileSystemConfig : ConfigBase
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets path to the user data storage.
        /// </summary>
        [DefaultValue("UserData")]
        [Category("File System")]
        [StringLength(255)]
        [Required()]
        [DataMember()]
        public string UsersDataPath
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the path to users profile defaults directory.
        /// </summary>
        [DefaultValue("DefaultUserFiles")]
        [Category("File System")]
        [StringLength(255)]
        [Required()]
        [DataMember()]
        public string DefaultsUserDataPath
        {
            get;
            set;
        }

        #endregion
    }
    #endregion

    #region SMTPCONFIG
    /// <summary>
    /// Service SMTP configuration class.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class SMTPConfig : ConfigBase
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets SMTP server host.
        /// </summary>
        [DataMember()]
        [Required()]
        public string Host
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets mail server port.
        /// </summary>
        [DataMember()]
        [DefaultValue(465)]
        [Range(1, 65536)]
        public int Port
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets username.
        /// </summary>
        [DataMember()]
        [StringLength(255)]
        public string Username
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets password.
        /// </summary>
        [DataMember()]
        [StringLength(255)]
        public string Password
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if authentication should be used.
        /// </summary>
        [DataMember()]
        [DefaultValue(false)]
        public bool EnableAuthentication
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if SSL should be used.
        /// </summary>
        [DataMember()]
        [DefaultValue(true)]
        public bool UseSSL
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if SMTP is enabled.
        /// </summary>
        [DataMember()]
        [DefaultValue(false)]
        public bool IsEnabled
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets reply to address.
        /// </summary>
        [DataMember()]
        [EmailNullEmpty()]
        public string ReplyToAddress
        {
            get; set;
        }

        #endregion
    }
    #endregion

    #region SMSGATEWAYCONFIG
    /// <summary>
    /// SMS gateway configuration class.
    /// </summary>
    [DataContract()]
    [Serializable()]
    public class SMSGatewayConfig : ConfigBase
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        public SMSGatewayConfig()
        {
        }
        #endregion

        #region FIELDS
        private IList<SMSGatewayParameter> parameters;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets if gateway is enabled.
        /// </summary>
        [DefaultValue(false)]
        [DataMember()]
        public bool IsEnabled
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets gateway url.
        /// </summary>
        [DataMember()]
        public string GatewayUrl
        {
            get; set;
        }

        /// <summary>
        /// Gets gateway parameters.
        /// </summary>
        [DataMember()]
        public IList<SMSGatewayParameter> Parameters
        {
            get
            {
                if (parameters == null)
                    parameters = new List<SMSGatewayParameter>();
                return parameters;
            }
            set
            {
                parameters = value;
            }
        }

        /// <summary>
        /// Gets or sets selected provider.
        /// </summary>
        [DefaultValue(SMSGatewayProvider.Custom)]
        [DataMember()]
        public SMSGatewayProvider Provider
        {
            get; set;
        }

        #endregion
    }
    #endregion

    #region SCHEDULERCONFIG
    /// <summary>
    /// Scheduler configuration class.
    /// </summary>
    [DataContract()]
    [Serializable()]
    public class SchedulerConfig : ConfigBase
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        public SchedulerConfig()
        {
        }
        #endregion

        #region FIELDS
        private IList<ServerService.Reporting.ReportScheduledTask> tasks;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets scheduler tasks.
        /// </summary>
        [DataMember()]
        public IList<ServerService.Reporting.ReportScheduledTask> Tasks
        {
            get
            {
                if (tasks == null)
                    tasks = new List<ServerService.Reporting.ReportScheduledTask>();
                return tasks;
            }
            set
            {
                tasks = value;
            }
        }

        #endregion
    }
    #endregion

    #region SMSGATEWAYPARAMETER
    /// <summary>
    /// SMS Gateway parameter configuration class.
    /// </summary>
    [DataContract()]
    [Serializable()]
    public class SMSGatewayParameter
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets parameter name.
        /// </summary>
        [DataMember()]
        [Required()]
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets parameter value.
        /// </summary>
        [DataMember()]
        [Required()]
        public string Value
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets parameter options.
        /// </summary>
        [DefaultValue(SMSGatewayParameterOption.None)]
        [DataMember(EmitDefaultValue = false)]
        public SMSGatewayParameterOption Options
        {
            get; set;
        }

        #endregion
    }
    #endregion    

    #endregion

    #region FINANCIALCONFIG
    /// <summary>
    /// Global financial configuration.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class FinancialConfig : ConfigBase
    {
        #region PROPERTIES
        /// <summary>
        /// Gets or sets time sale vat.
        /// </summary>
        [DataMember()]
        [Range(0, 100)]
        public decimal TimeSaleVAT
        {
            get; set;
        }
        #endregion
    }
    #endregion

    #region CLIENTCONFIGURATION

    /// <summary>
    /// Client configuration class.
    /// </summary>
    [Category("Client")]
    [Description("Client configuration.")]
    [Serializable()]
    [DataContract()]
    public class ClientConfig : ConfigBase
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        public ClientConfig()
        {
            General = new ClientGeneralConfig();
            Shell = new ClientShellConfig();
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets file path to the virtual image mounting executable.
        /// </summary>
        [Category("Client")]
        [Description("Specifies virtual cd image mounter path.")]
        [DefaultValue(@"C:\Program Files\DAEMON Tools Lite\daemon.exe")]
        [StringLength(255)]
        [DataMember()]
        public string MounterPath
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets virtual image mounter options.
        /// </summary>
        [Category("Client")]
        [Description("Specifies virtual cd image mounter command line parameters.")]
        [DefaultValue("-mount")]
        [StringLength(255)]
        [DataMember()]
        public string MounterOptions
        {
            get;
            set;
        }

        /// <summary>
        /// Enables or disables personal personal storage.
        /// </summary>
        [Category("Client")]
        [Description("Enables or disables personal storage.")]
        [DefaultValue(false)]
        [DataMember()]
        public bool IsPersonalStorageEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets personal user storage drive letter.
        /// </summary>
        [Category("Client")]
        [Description("Specifies personal storage drive letter.")]
        [DefaultValue("U:")]
        [DataMember()]
        public string PersonalStorageDriveLetter
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets personal drive quouta.
        /// </summary>
        [Category("Client")]
        [Description("Specifies personal storage size.")]
        [DefaultValue(2000)]
        [Range(1, int.MaxValue)]
        [DataMember()]
        public int PersonalStorageSize
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the system folders that should be redirected to the perasonal user storage.
        /// </summary>
        [Category("Client")]
        [Description("Specifies shell to personal storage redirected folders.")]
        [DefaultValue(KnownFolderTypes.None)]
        [DataMember()]
        public KnownFolderTypes RedirectedFolders
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if idle computers should be turned off.
        /// </summary>
        [Category("Client")]
        [Description("Specifies if idle computers should be turned off.")]
        [DefaultValue(false)]
        [DataMember()]
        public bool TurnOffIdleComputers
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets time before unused system shutdown.
        /// </summary>
        [Category("Client")]
        [Description("Specifies computer turn off timeout.")]
        [DefaultValue(10)]
        [DataMember()]
        public int TurnOffTimeOut
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if computers should sleep on idle turn off.
        /// </summary>
        [Category("Client")]
        [Description("Specifies if computers should sleep on idle turn off.")]
        [DefaultValue(false)]
        [DataMember()]
        public bool TurnOffIdleSleepEnable
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if free disk space should be allocated.
        /// </summary>
        [Category("Client")]
        [Description("Enables or disables disk space allocation.")]
        [DefaultValue(false)]
        [DataMember()]
        public bool AllocateDiskSpace
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or set free space allocation size percentage.
        /// </summary>
        [Category("Client")]
        [Description("Specifies free space allocation type.")]
        [DefaultValue(FreeSpaceAllocations.Zero)]
        [DataMember()]
        public FreeSpaceAllocations DiskAllocation
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if logout should be confirmed by the user.
        /// </summary>
        [Category("Client")]
        [Description("Enables or disables logout confirmation.")]
        [DefaultValue(true)]
        [DataMember()]
        public bool ConfirmLogout
        {
            get;
            set;
        }

        /// <summary>
        /// General configuration.
        /// </summary>
        [Category("Client")]
        [Description("General settings.")]
        [DataMember()]
        public ClientGeneralConfig General
        {
            get;
            set;
        }

        /// <summary>
        /// Shell configuration.
        /// </summary>
        [Category("Client")]
        [Description("Shell settings.")]
        [DataMember()]
        public ClientShellConfig Shell
        {
            get;
            set;
        }

        #endregion

        #region OVERRIDES

        /// <summary>
        /// Sets default values.
        /// </summary>
        public override void SetDefaults()
        {
            base.SetDefaults();
            General.SetDefaults();
            Shell.SetDefaults();
        }

        #endregion
    }

    /// <summary>
    /// Client general configuration class.
    /// </summary>
    [Category("General")]
    [Serializable()]
    [DataContract()]
    public class ClientGeneralConfig : ConfigBase
    {
        #region PROPERTIES
        /// <summary>
        /// Gets or sets clients data path.
        /// </summary>
        /// <remarks>
        /// Data path points to the folder when all client data such cahche, plugins etc will be saved.
        /// </remarks>
        [Category("General")]
        [Description("Specifies client data path.")]
        [DefaultValue(@"%ALLUSERSPROFILE%\Application Data\NETProjects\Gizmo Client\")]
        [StringLength(255)]
        [Required()]
        [DataMember(Order = 0)]
        public string DataPath
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets client manager password.
        /// </summary>
        [Category("General")]
        [DefaultValue("password")]
        [Required()]
        [DataMember(Order = 1)]
        public string ManagerPassword
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if age ratings are enabled.
        /// </summary>
        [Category("General")]
        [Description("Enables or disables age rating.")]
        [DefaultValue(true)]
        [DataMember(Order = 2)]
        public bool IsAgeRatingsEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if client ordering is enabled.
        /// </summary>
        [Category("General")]
        [Description("Enables or disables client ordering.")]
        [DefaultValue(true)]
        [DataMember(Order = 3)]
        public bool IsOrderingEnabled
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if client registrations are enabled.
        /// </summary>
        [Category("General")]
        [Description("Enables or disables client user registration.")]
        [DefaultValue(false)]
        [DataMember(Order = 4)]
        public bool IsClientRegistrationEnabled
        {
            get; set;
        }
        
        /// <summary>
        /// Gets or set client registration verification method.
        /// </summary>
        [Category("General")]
        [Description("Gets or sets client registration verification method.")]
        [DefaultValue(RegistrationVerificationMethod.None)]
        [DataMember(Order = 5)]
        public RegistrationVerificationMethod VerificationMethod
        {
            get; set;
        }

        /// <summary>
        /// Gets or set if concurrent execution limit is enabled.
        /// </summary>
        [Category("General")]
        [Description("Gets or set if concurrent execution limit is enabled.")]
        [DefaultValue(false)]
        [DataMember(Order = 6)]
        public bool IsConcurrentExecutionLimitEnabled
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets if web registrations are enabled.
        /// </summary>
        [Category("General")]
        [Description("Enables or disables web user registration.")]
        [DefaultValue(false)]
        [DataMember(Order = 7)]
        public bool IsWebRegistrationEnabled
        {
            get; set;
        }

        #endregion
    }

    /// <summary>
    /// Client shell configuration class.
    /// </summary>
    [Category("Shell")]
    [Serializable()]
    [DataContract()]
    public class ClientShellConfig : ConfigBase
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        public ClientShellConfig()
        {
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets name of the current GUI Skin.
        /// </summary>
        [Category("Shell")]
        [Description("Specifies shell skin name.")]
        [DefaultValue("Material")]
        [DataMember(Order = 0)]
        public string SkinName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if shell desktop is enabled.
        /// </summary>
        [Category("Shell")]
        [Description("Enables or disables desktop.")]
        [DefaultValue(true)]
        [DataMember(Order = 1)]
        public bool IsDesktopEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets client language.
        /// </summary>
        [Category("Shell")]
        [Description("Specifies client language")]
        [DefaultValue("English")]
        [DataMember(Order = 2)]
        public string Language
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the logout action.
        /// </summary>
        [Category("Shell")]
        [Description("Specifies user logout action.")]
        [DefaultValue(LogoutAction.Reboot)]
        [DataMember(Order = 3)]
        public LogoutAction LogoutAction
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets user time notification message.
        /// </summary>
        [Category("Shell")]
        [Description("Specifies time notification message.")]
        [DefaultValue(null)]
        [DataMember(Order = 4)]
        public string TimeNotificationMessage
        {
            get;
            set;
        }

        /// <summary>
        /// Get or sets time left warning minutes.
        /// </summary>
        [Category("Shell")]
        [DefaultValue(0)]
        [DataMember(Order = 5)]
        public int TimeLeftWarning
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets time left warning type.
        /// </summary>
        [Category("Shell")]
        [DefaultValue(TimeLeftWarningType.All)]
        [DataMember(Order = 6)]
        public TimeLeftWarningType TimeLeftWarningType
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets virtual desktop items.
        /// </summary>
        [Category("Shell")]
        [Description("Specifies virtual desktop items.")]
        [DefaultValue(null)]
        [DataMember(Order = 7)]
        public List<int> VirtualDesktopItems
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if star menu is disabled.
        /// </summary>
        [Category("Shell")]
        [Description("Enables or disables shell start menu.")]
        [DefaultValue(false)]
        [DataMember(Order = 8)]
        public bool DisableStarMenu
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if sticky shell is enabled.
        /// </summary>
        [Category("Shell")]
        [Description("Enables or disables sticky shell.")]
        [DefaultValue(false)]
        [DataMember(Order = 9)]
        public bool StickyShell
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if desktop switching is disabled.
        /// </summary>
        [Category("Shell")]
        [Description("Enables or disables desktop switching.")]
        [DefaultValue(true)]
        [DataMember(Order = 10)]
        public bool DisableDesktopSwitching
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets user time notifications.
        /// </summary>
        [Category("Shell")]
        [Description("Specifies time notifications.")]
        [DataMember(Order = 11)]
        public List<ServerService.TimeNotification> TimeNotifications
        {
            get;
            set;
        }

        #endregion       
    }

    #endregion

    #region SERVICECONNECTIONCONFIG
    /// <summary>
    /// Service configuration class.
    /// </summary>
    [Category("Services")]
    [Serializable()]
    [DataContract()]
    public class ServiceConnectionConfig : ConfigBase, IComparable<ServiceConnectionConfig>
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets servers ip address or hostname.
        /// </summary>
        [DataMember()]
        [Required()]
        public string HostName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets servers port.
        /// </summary>
        [DataMember()]
        [DefaultValue(44967)]
        [Range(1, 65536)]
        public int Port
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets servers friendly name.
        /// </summary>
        [DataMember()]
        public string FriendlyName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets connection compression level.
        /// </summary>
        [DefaultValue(0)]
        [DataMember()]
        [Range(1, 9)]
        public int CompressionLevel
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if connection should be secured.
        /// </summary>
        [DefaultValue(false)]
        [DataMember()]
        public bool SecureConnection
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if keep alive should be enabled.
        /// </summary>
        [DefaultValue(true)]
        [DataMember()]
        public bool KeepAlive
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets keep alive timeout.
        /// </summary>
        [DataMember()]
        [DefaultValue(250)]
        public int KeepAliveTimeout
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets keep alive interval.
        /// </summary>
        [DataMember()]
        [DefaultValue(150)]
        public int KeepAliveInterval
        {
            get; set;
        }

        #endregion

        #region IComparable
        /// <summary>
        /// Compares configuration.
        /// </summary>
        /// <param name="other">Other instance.</param>
        /// <returns>True if configuration equals the <paramref name="other"/>, otherwise false.</returns>
        public int CompareTo(ServiceConnectionConfig other)
        {
            int result;

            result = string.Compare(HostName, other.HostName, true);
            if (result != 0)
                return result;

            result = string.Compare(FriendlyName, other.FriendlyName, true);
            if (result != 0)
                return result;

            result = Port != other.Port ? Port < other.Port ? -1 : 1 : 0;
            if (result != 0)
                return result;

            result = CompressionLevel != other.CompressionLevel ? CompressionLevel < other.CompressionLevel ? -1 : 1 : 0;
            if (result != 0)
                return result;

            result = SecureConnection != other.SecureConnection ? SecureConnection != true ? -1 : 1 : 0;
            if (result != 0)
                return result;

            return result;
        }
        #endregion
    }
    #endregion

    #region MANAGERCONFIG
    /// <summary>
    /// Mamager configuration class.
    /// </summary>
    [Category("Manager")]
    [Serializable()]
    [DataContract()]
    public class ManagerConfig : ConfigBase
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        public ManagerConfig()
        {
            Modules = new List<ManagerModuleConfig>();
            Services = new List<ServiceConnectionConfig>();
        }
        #endregion

        #region FIELDS
        private List<ServiceConnectionConfig> services;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets a list of configured servers.
        /// </summary>
        [DataMember()]
        public List<ServiceConnectionConfig> Services
        {
            get
            {
                if (services == null)
                    services = new List<ServiceConnectionConfig>();
                return services;
            }
            set
            {
                services = value;
            }
        }

        /// <summary>
        /// Gets or sets last used operator name.
        /// </summary>
        [Category("Manager")]
        [DataMember(Order = 0, IsRequired = false, EmitDefaultValue = false)]
        public string LastOperator
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets manager language.
        /// </summary>
        [Category("Manager")]
        [DataMember(Order = 0, IsRequired = false, EmitDefaultValue = false)]
        public string Language
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets manager modules configurations.
        /// </summary>
        [Category("Modules")]
        [DataMember(EmitDefaultValue = true)]
        public List<ManagerModuleConfig> Modules
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if overlay detail is enabled.
        /// </summary>
        [Category("User Interface")]
        [DataMember()]
        public bool OverlayDetailEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets extended user search fields.
        /// </summary>
        [Category("Functionality")]
        [DataMember()]
        public UserSearchFields ExtendedUserSearchFields
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if user search should be prefered.
        /// </summary>
        [Category("Functionality")]
        [DataMember()]
        public bool PreferUserSearch
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets new user action.
        /// </summary>
        [Category("Functionality")]
        [DataMember()]
        public NewUserAction NewUserAction
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if user info requested is default option.
        /// </summary>
        [Category("Functionality")]
        [DataMember()]
        public bool IsUserInfoRequestedByDefault
        {
            get; set;
        }

        /// <summary>
        /// POS Devices config.
        /// </summary>
        [Category("Devices")]
        [DataMember()]
        public DevicesConfig Devices
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets notification settings.
        /// </summary>
        [Category("Notifications")]
        [DataMember()]
        public ManagerNotificationsConfig Notifications
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets financial settings.
        /// </summary>
        [Category("Financial")]
        [DataMember()]
        public ManagerFinancialConfig Financial
        {
            get; set;
        }

        #endregion
    }
    #endregion    

    #region MANAGERMODULECONFIG
    /// <summary>
    /// Manager modules configuration class.
    /// </summary>
    [Category("Modules")]
    [Serializable()]
    [DataContract()]
    public class ManagerModuleConfig
    {
        /// <summary>
        /// Gets or sets module type.
        /// </summary>
        [DataMember(Order = 0)]
        public string ModuleType
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if module is hidden.
        /// </summary>
        [DataMember(Order = 0)]
        public bool IsHidden
        {
            get; set;
        }
    }
    #endregion

    #region DEVICESCONFIG
    /// <summary>
    /// Manager devices configuration class.
    /// </summary>
    [Category("Devices")]
    [Serializable()]
    [DataContract()]
    public class DevicesConfig : ConfigBase
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets cash drawer configuration.
        /// </summary>
        [Category("Cash Drawer")]
        [DataMember()]
        public POSDeviceConfig CashDrawer
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets barcode scanner configuration.
        /// </summary>
        [Category("Barcode Scanner")]
        [DataMember()]
        public POSDeviceConfig BarcodeScanner
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets pos printer configuration.
        /// </summary>
        [Category("POS Printer")]
        [DataMember()]
        public POSDevicePrinterConfig Printer
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets RFID scanner configuration.
        /// </summary>
        [Category("RFID Scanner")]
        [DataMember()]
        public POSDeviceRFIDConfig RFIDScanner
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets pos fiscal printer configuration.
        /// </summary>
        [Category("POS Printer")]
        [DataMember()]
        public POSDeviceFiscalPrinterConfig FiscalPrinter
        {
            get; set;
        }

        #endregion
    }
    #endregion

    #region POSDEVICECONFIG
    /// <summary>
    /// POS device configuration.
    /// </summary>
    [Category("Devices")]
    [Serializable()]
    [DataContract()]
    public class POSDeviceConfig
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets device name.
        /// </summary>
        [DataMember(Order = 0)]
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets device provider.
        /// </summary>
        [DataMember(Order = 1)]
        public string Provider
        {
            get; set;
        }

        #endregion
    }
    #endregion

    #region POSDEVICEPRINTERCONFIG
    /// <summary>
    /// POS printer configuration.
    /// </summary>
    [Category("Devices")]
    [Serializable()]
    [DataContract()]
    public class POSDevicePrinterConfig : POSDeviceConfig
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets if receipt printing is enabled.
        /// </summary>
        [DefaultValue(true)]
        [DataMember()]
        public bool ReceiptPrintEnabled
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets raw commands to send to printer after printing.
        /// </summary>
        [DefaultValue("27;112;0;25;25")]
        [DataMember()]
        public string OpenCashDrawerCommand
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if deposit receipts should be printed.
        /// </summary>
        [DefaultValue(false)]
        [DataMember()]
        public bool DepositReceiptEnabled
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets receipt count.
        /// </summary>
        [DataMember()]
        public int? ReceiptCount
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets deposit receipt count.
        /// </summary>
        [DataMember()]
        public int? DepositReceiptCount
        {
            get; set;
        }

        #endregion
    }
    #endregion

    #region POSDEVICERFIDCONFIG
    /// <summary>
    /// POS RFID configuration.
    /// </summary>
    [Category("Devices")]
    [Serializable()]
    [DataContract()]
    public class POSDeviceRFIDConfig : POSDeviceConfig
    {
        #region PROPERTIES

        /// <summary>
        /// RFID Scan User Card Default Action.
        /// </summary>
        [DefaultValue(RFIDScanUserCardActions.OpenUserInfoWindow)]
        [DataMember()]
        public RFIDScanUserCardActions ScanUserCardDefaultAction
        {
            get; set;
        }

        #endregion
    }
    #endregion

    #region POSDEVICEFISCALPRINTERCONFIG
    /// <summary>
    /// POS printer configuration.
    /// </summary>
    [Category("Devices")]
    [Serializable()]
    [DataContract()]
    public class POSDeviceFiscalPrinterConfig : POSDeviceConfig
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets access password.
        /// </summary>
        [DataMember()]
        public string AccessPassword
        {
            get; set;
        }

        #endregion
    }
    #endregion

    #region MANAGERNOTIFICATIONSCONFIG
    /// <summary>
    /// Manager notifications config.
    /// </summary>
    [DataContract()]
    [Serializable()]
    public class ManagerNotificationsConfig : ConfigBase
    {
        #region PROPERTIES

        /// <summary>
        /// Indicates if new order sound is enabled.
        /// </summary>
        [DefaultValue(false)]
        [DataMember()]
        public bool NewOrderSoundEnabled
        {
            get; set;
        }

        /// <summary>
        /// New order sound file path.
        /// </summary>
        [DataMember()]
        public string NewOrderSoundFile
        {
            get; set;
        }

        /// <summary>
        /// Indicates if guest logout sound is enabled.
        /// </summary>
        [DefaultValue(false)]
        [DataMember()]
        public bool GuestLogoutSoundEnabled
        {
            get; set;
        }

        /// <summary>
        /// Guest logout sound file path.
        /// </summary>
        [DataMember()]
        public string GuestLogoutSoundFile
        {
            get; set;
        }

        /// <summary>
        /// Guest logout sound balance.
        /// </summary>
        [DefaultValue(SoundNotificationBalanceOptions.All)]
        [DataMember()]
        public SoundNotificationBalanceOptions GuestLogoutSoundBalance
        {
            get; set;
        }

        /// <summary>
        /// Indicates if member logout sound is enabled.
        /// </summary>
        [DefaultValue(false)]
        [DataMember()]
        public bool MemberLogoutSoundEnabled
        {
            get; set;
        }

        /// <summary>
        /// Member logout sound file path.
        /// </summary>
        [DataMember()]
        public string MemberLogoutSoundFile
        {
            get; set;
        }

        /// <summary>
        /// Member logout sound balance.
        /// </summary>
        [DefaultValue(SoundNotificationBalanceOptions.All)]
        [DataMember()]
        public SoundNotificationBalanceOptions MemberLogoutSoundBalance
        {
            get; set;
        }

        /// <summary>
        /// Indicates if client disconnect sound is enabled.
        /// </summary>
        [DefaultValue(false)]
        [DataMember()]
        public bool ClientDisconnectSoundEnabled
        {
            get; set;
        }

        /// <summary>
        /// Client disconnect sound file path.
        /// </summary>
        [DataMember()]
        public string ClientDisconnectSoundFile
        {
            get; set;
        }
        
        #endregion
    }
    #endregion

    #region MANAGERFINANCIALCONFIG
    /// <summary>
    /// Manager financial config.
    /// </summary>
    [DataContract()]
    [Serializable()]
    public class ManagerFinancialConfig : ConfigBase
    {
        #region PROPERTIES

        /// <summary>
        /// Indicates whether deposits are always used for payments.
        /// </summary>
        [DefaultValue(true)]
        [DataMember()]
        public bool AlwaysUseDeposits
        {
            get; set;
        }

        #endregion
    }
    #endregion

    #region SKINCONFIG
    /// <summary>
    /// Client skin configuration.
    /// </summary>
    [Category("Skin")]
    [Serializable()]
    [DataContract()]
    public class SkinConfig : ConfigBase
    {
        #region FIELDS 
        private string[] noload,
            supressModule;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets disabled modules.
        /// </summary>
        [DataMember()]
        public string[] SupressModule
        {
            get
            {
                if (supressModule == null)
                    supressModule = new string[0];
                return supressModule;
            }
            set
            {
                supressModule = value;
            }
        }

        /// <summary>
        /// Gets or sets list of dlls that should not be loaded.
        /// </summary>
        [DataMember()]
        public string[] NoLoadDll
        {
            get
            {
                if (noload == null)
                    noload = new string[0];
                return noload;
            }
            set
            {
                noload = value;
            }
        }

        /// <summary>
        /// Gets or sets default wallpaper.
        /// </summary>
        [DataMember()]
        [DefaultValue("wallpaper.jpg")]
        public string Wallpaper
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if software redndering should be preferred.
        /// </summary>
        [DefaultValue(false)]
        [DataMember()]
        public bool SoftwareRendering
        {
            get; set;
        }

        /// <summary>
        /// Rotator configuration.
        /// </summary>
        [DataMember()]
        public RotatorConfig Rotator
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets default app sorting.
        /// </summary>
        [DefaultValue(AppSort.DateAdded)]
        [DataMember()]
        public AppSort DefaultAppSort
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets default product sorting.
        /// </summary>
        [DefaultValue(ProductSort.Name)]
        [DataMember()]
        public ProductSort DefaultProductSort
        {
            get; set;
        }

        #endregion

        #region OVERRIDES

        /// <summary>
        /// Sets default values.
        /// </summary>
        public override void SetDefaults()
        {
            base.SetDefaults();

            Rotator?.SetDefaults();
        }

        #endregion
    }
    #endregion

    #region ROTATORCONFIG
    /// <summary>
    /// Rotator configuration.
    /// </summary>
    [Category("Rotator")]
    [Serializable()]
    [DataContract()]
    public class RotatorConfig : ConfigBase
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets source path for the rotator.
        /// </summary>
        [DefaultValue("rotator")]
        [DataMember()]
        public string RotatorSource
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets rotate seconds.
        /// </summary>
        [DefaultValue(5)]
        [DataMember()]
        public int RotateEverySeconds
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets rotator file order.
        /// </summary>
        [DefaultValue(RotatorFileOrder.Random)]
        [DataMember()]
        public RotatorFileOrder FileOrder
        {
            get; set;
        }

        #endregion
    }
    #endregion
}
