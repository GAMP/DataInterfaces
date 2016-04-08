using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.Configuration
{
    #region CONFIGBASE
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
            if(property.CanResetValue(this))
                property.ResetValue(this);
        }

        /// <summary>
        /// Gets validation results.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IGrouping<string,ValidationResult>> GetValidationResults()
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
            return this.GetValidationResults()
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
            this.GetInvalidPropertyNames()
                .ToList()
                .ForEach(x => this.SetDefault(x));
        }
    } 
    #endregion

    #region CONFIGURATION
    [Serializable()]
    [DataContract()]
    public class ConfigurationRoot : ConfigBase
    {
        #region CONSTRUCTOR
        public ConfigurationRoot()
        {
            this.Service = new ServiceConfig();
            this.Client = new ClientConfig();
            this.Global = new GlobalConfiguration();
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

        #region OVVERIDES
        public override void SetDefaults()
        {
            base.SetDefaults();
            this.Service.SetDefaults();
            this.Client.SetDefaults();
            this.Global.SetDefaults();
        }
        #endregion
    } 
    #endregion

    #region GLOBALCONFIGURATION

    [Serializable()]
    [DataContract()]
    public class GlobalConfiguration : ConfigBase
    {
        #region CONSTRUCTOR
        public GlobalConfiguration()
        {
            this.Network = new GlobalNetworkCfg();
            this.Subscription = new GlobalSubscriptionConfig();
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

        #endregion

        #region OVVERIDES
        public override void SetDefaults()
        {
            this.Network.SetDefaults();
            this.Subscription.SetDefaults();
        } 
        #endregion
    }

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

    #endregion

    #region SERVICECONFIGURATION
    
    [Serializable()]
    [DataContract()]
    public class ServiceConfig : ConfigBase
    {
        #region CONSTRUCTOR
        public ServiceConfig()
        {
            this.Network = new ServiceNetworkConfig();
            this.Database = new ServiceDatabaseConfig();
            this.WebApi = new ServiceWebApiConfig();
            this.FileSystem = new ServiceFileSystemConfig();
            this.General = new ServiceGeneralConfig();
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
        /// Gets or sets web api configuration.
        /// </summary>
        [Category("Web API")]
        [Description("Web API configuration.")]
        [DataMember(Order = 2)]
        public ServiceWebApiConfig WebApi
        {
            get;
            set;
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

        #endregion

        #region OVERRIDE
        public override void SetDefaults()
        {
            base.SetDefaults();
            this.Network.SetDefaults();
            this.Database.SetDefaults();
            this.WebApi.SetDefaults();
            this.FileSystem.SetDefaults();
            this.General.SetDefaults();
        } 
        #endregion
    }

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
        [Range(1,255)]
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
        /// Gets or sets if the service should resolve the incoming client hostnames.
        /// </summary>
        /// <remarks>
        /// In some cases resolving hostnames may lead to slowdowns in incomming client connection processing.
        /// </remarks>
        [Category("Network")]
        [Description("Enables hostname resolving.")]
        [DefaultValue(false)]
        [DataMember(Order = 9)]
        public bool ResolveHostnames
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
        [DataMember(Order = 10)]
        public bool RestoreHostnames
        {
            get;
            set;
        }

        #endregion
    }

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
        [DefaultValue(0)]
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

        #endregion
    }

    [DataContract()]
    [Serializable()]
    public class ServiceGeneralConfig : ConfigBase
    {
        #region PROPERTIES

        /// <summary>
        /// Enables or disables client auto update.
        /// </summary>
        [DefaultValue(true)]
        [Category("General")]
        [Description("Enable or disable automatic client update.")]
        [DataMember()]
        public bool AutoUpdateClient
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if pending session should terminate.
        /// </summary>
        [DefaultValue(true)]
        [Category("General")]
        [Description("Enable or disable termination of pending user sessions.")]
        [DataMember()]
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
        [DataMember()]
        public int PendingSessionTimeout
        {
            get;
            set;
        }

        #endregion
    }

    [DataContract()]
    [Serializable()]
    public class ServiceWebApiConfig : ConfigBase
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets if Server WEB API Enabled.
        /// </summary>
        [Category("Web API")]
        [DefaultValue(false)]
        [Description("Enables or disables WEB API.")]
        [DataMember()]
        public bool EnableWebAPI
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets WEB API port.
        /// </summary>
        [Category("Web API")]
        [Description("Specifies WEB API listening port.")]
        [DefaultValue(8080)]
        [Range(1,65536)]
        [DataMember()]
        public int WebAPIPort
        {
            get;
            set;
        }

        #endregion
    }

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

    #region CLIENTCONFIGURATION
    
    [Category("Client")]
    [Description("Client configuration.")]
    [Serializable()]
    [DataContract()]
    public class ClientConfig : ConfigBase
    {
        #region CONSTRUCTOR
        public ClientConfig()
        {
            this.Integration = new ClientIntegrationConfig();
            this.General = new ClientGeneralConfig();
            this.Shell = new ClientShellConfig();
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
        [Range(1,int.MaxValue)]
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
        /// Gets or sets time before unused system shutdown.
        /// </summary>
        [Category("Client")]
        [Description("Specifies computer turn off timeout.")]
        [DefaultValue(180)]
        [DataMember()]
        public int TurnOffTimeOut
        {
            get;
            set;
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
        /// Gets or sets integration settings.
        /// </summary>
        [Category("Client")]
        [Description("Integration configuration.")]
        [DataMember()]
        public ClientIntegrationConfig Integration
        {
            get;
            set;
        }

        [Category("Client")]
        [Description("General settings.")]
        [DataMember()]
        public ClientGeneralConfig General
        {
            get;
            set;
        }

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
        public override void SetDefaults()
        {
            base.SetDefaults();
            this.Integration.SetDefaults();
            this.General.SetDefaults();
            this.Shell.SetDefaults();
        } 
        #endregion
    }

    [Category("Integration")]
    [Description("Integration configuration.")]
    [Serializable()]
    [DataContract()]
    public class ClientIntegrationConfig : ConfigBase
    {
        #region PROPERTIES

        /// <summary>
        /// Enables or disable integration.
        /// </summary>
        [DefaultValue(false)]
        [DataMember()]
        public bool IsEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets contract name.
        /// </summary>
        [DefaultValue(null)]
        [DataMember()]
        public string Provider
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets server IPAddress string.
        /// </summary>
        [DefaultValue("localhost")]
        [Required()]
        [StringLength(255)]
        [DataMember()]
        public string ServerIp
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets server port.
        /// </summary>
        [DefaultValue(7831)]
        [Range(1, 65536)]
        [DataMember()]
        public int ServerPort
        {
            get;
            set;
        }

        #endregion
    }
    
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
        [DataMember(Order=0)]
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
        [DataMember(Order=1)]
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
        [DataMember(Order=2)]
        public bool IsAgeRatingsEnabled
        {
            get;
            set;
        } 
        #endregion
    }

    [Category("Shell")]
    [Serializable()]
    [DataContract()]
    public class ClientShellConfig : ConfigBase
    {
        #region CONSTRUCTOR
        public ClientShellConfig()
        {
            this.VirtualDesktopItems = new List<int>();
        } 
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets or sets if client GUI should be enabled.
        /// </summary>
        [Category("Shell")]
        [Description("Enables or disables shell.")]
        [DefaultValue(true)]
        [DataMember(Order=0)]
        public bool IsShellEnabled
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets name of the current GUI Skin.
        /// </summary>
        [Category("Shell")]
        [Description("Specifies shell skin name.")]
        [DefaultValue("Default")]
        [DataMember(Order=1)]
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
        [DataMember(Order=2)]
        public bool IsDesktopEnabled
        {
            get;
            set;
        }

        [Category("Shell")]
        [Description("Specifies client language")]
        [DefaultValue("English")]
        [DataMember(Order=3)]
        public string Language
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if logout button should be shown.
        /// </summary>
        [Category("Shell")]
        [Description("Specifies if logout button should be displaid.")]
        [DefaultValue(true)]
        [DataMember(Order=4)]
        public bool DisplayLogoutButton
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
        [DataMember(Order = 5)]
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
        [DataMember(Order=6)]
        public string TimeNotificationMessage
        {
            get;
            set;
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
    public class ServiceConnectionConfig : IComparable<ServiceConnectionConfig>
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
        [DefaultValue(1)]
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

        #endregion

        #region IComparable
        public int CompareTo(ServiceConnectionConfig other)
        {
            int result;

            result = string.Compare(this.HostName, other.HostName, true);
            if (result != 0)
                return result;

            result = string.Compare(this.FriendlyName, other.FriendlyName, true);
            if (result != 0)
                return result;

            result = this.Port != other.Port ? this.Port < other.Port ? -1 : 1 : 0;
            if (result != 0)
                return result;

            result = this.CompressionLevel != other.CompressionLevel ? this.CompressionLevel < other.CompressionLevel ? -1 : 1 : 0;
            if (result != 0)
                return result;

            result = this.SecureConnection != other.SecureConnection ? this.SecureConnection != true ? -1 : 1 : 0;
            if (result != 0)
                return result;

            return result;
        }
        #endregion
    }
    #endregion

    #region MANAGERCONFIG
    [Category("Manager")]
    [Serializable()]
    [DataContract()]
    public class ManagerConfig : ConfigBase
    {
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
                if (this.services == null)
                    this.services = new List<ServiceConnectionConfig>();
                return services;
            }
            set
            {
                this.services = value;
            }
        }
        #endregion
    }
    #endregion
}
