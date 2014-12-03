using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedLib
{
    #region RoleAssignableAttribute
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class RoleAssignableAttribute : Attribute
    {
        #region Constructor
        public RoleAssignableAttribute(bool assignable)
        {
            this.Assignable = assignable;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets if role is assignable.
        /// </summary>
        public bool Assignable
        {
            get;
            protected set;
        }
        #endregion
    }
    #endregion

    #region CanUserAssignAttribute
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class CanUserAssignAttribute : Attribute
    {
        public CanUserAssignAttribute(bool assignable)
        {
            this.Assignable = assignable;
        }

        /// <summary>
        /// Gets if item can be assigned by the user.
        /// </summary>
        public bool Assignable
        {
            get;
            protected set;
        }
    } 
    #endregion

    #region IgnorePropertyModificationAttribute
    /// <summary>
    /// This attribute should be used on properties that not to be considered as modified during property change.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class IgnorePropertyModificationAttribute : Attribute
    {
    } 
    #endregion

    #region GUIDAttribue
    /// <summary>
    /// GUID Attribute.
    /// </summary>
    public class GUIDAttribute : Attribute
    {
        #region Constructor
        public GUIDAttribute(string guid)
        {
            this.Guid = new Guid(guid);
        }
        #endregion

        #region Fields
        private Guid guid;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the GUID for this attribute.
        /// </summary>
        public Guid Guid
        {
            get { return this.guid; }
            protected set { this.guid = value; }
        }
        #endregion
    }
    #endregion

    #region SpecialFolderAttribute
    /// <summary>
    /// Special folder attribute.
    /// </summary>
    public class SpecialFolderAttribute : Attribute
    {
        #region Fields
        private Environment.SpecialFolder folderType = (Environment.SpecialFolder)65535;
        #endregion

        #region Constructor

        public SpecialFolderAttribute()
        {
        }

        public SpecialFolderAttribute(System.Environment.SpecialFolder knownFolderType)
        {
            this.SpecialFolder = knownFolderType;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the folder type for this attribute.
        /// </summary>
        public System.Environment.SpecialFolder SpecialFolder
        {
            get { return this.folderType; }
            protected set { this.folderType = value; }
        }

        #endregion
    }
    #endregion

    #region AgeAttribute
    /// <summary>
    /// Age attribute.
    /// </summary>
    public class AgeRatingAttribute : Attribute
    {
        #region Constructor

        /// <summary>
        /// Creates new age attribute.
        /// </summary>
        /// <param name="value">Age value.</param>
        public AgeRatingAttribute(uint value)
        {
            this.Age = value;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets attributes age value.
        /// </summary>
        public uint Age
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion

    #region PolicyAttribute
    public class PolicyAttribute : Attribute
    {
        #region Constructor
        /// <summary>
        /// Creates new instance of the attribute.
        /// </summary>
        /// <param name="registryPath">Registry path.</param>
        /// <param name="valueName">Value name.</param>
        /// <param name="description">Description.</param>
        public PolicyAttribute(string registryPath,
            string description,
            string valueName)
        {
            #region Validation
            if (String.IsNullOrWhiteSpace(registryPath))
                throw new ArgumentException("Registry path may not be null or empty.", "RegistryPath");
            if (String.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description may not be null or empty.", "Description");
            #endregion

            //registry path of restriction
            this.RegistryPath = registryPath;

            //if value name is emty enum value should be used
            this.ValueName = valueName;

            //set description
            this.Description = description;
        }
        #endregion

        #region Fields
        private Microsoft.Win32.RegistryHive hive = Microsoft.Win32.RegistryHive.CurrentUser;
        #endregion

        #region Properties

        /// <summary>
        /// Gets registry path of restriction attribute.
        /// </summary>
        public string RegistryPath
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets value name of security attribute.
        /// </summary>
        public string ValueName
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the restrictions description.
        /// </summary>
        public string Description
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the restrictions category string.
        /// </summary>
        public string Category
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets registry hive.
        /// </summary>
        public Microsoft.Win32.RegistryHive Hive
        {
            get { return this.hive; }
            protected set { this.hive = value; }
        }

        #endregion

        #region Functions
        /// <summary>
        /// Converts enable flag to registry value object.
        /// </summary>
        /// <param name="enable">Enable flag.</param>
        /// <returns>Returns converted object value.</returns>
        public virtual object GetValueForAttribute(bool enable)
        {
            return enable ? 1 : 0;
        }
        #endregion
    }
    #endregion

    #region MessengerPolicyAttribute
    public class MessengerPolicyAttribute : PolicyAttribute
    {
        #region Constructor
        public MessengerPolicyAttribute(string description, string valueName = "")
            : base("Software\\Policies\\Microsoft\\Messenger\\Client", description, valueName)
        {
            this.Category = "MSN Messenger";
        }
        #endregion
    }
    #endregion

    #region InternetExplorerPolicyAttribute
    public class InternetExplorerPolicyAttribute : PolicyAttribute
    {
        #region Constructor
        public InternetExplorerPolicyAttribute(string description, string valueName = "")
            : base("Software\\Policies\\Microsoft\\Internet Explorer\\Restrictions", description, valueName)
        {
            this.Category = "Internet Explorer";
        }
        #endregion
    }
    #endregion

    #region InternetExplorerToolbarsPolicyAttribute
    public class InternetExplorerToolbarsPolicyAttribute : PolicyAttribute
    {
        #region Constructor
        public InternetExplorerToolbarsPolicyAttribute(string description, string valueName = "")
            : base("Software\\Policies\\Microsoft\\Internet Explorer\\Toolbars\\Restrictions", description, valueName)
        {
            this.Category = "Internet Explorer Toolbars";
        }
        #endregion
    }
    #endregion

    #region ExplorerPolicyAttribute
    public class ExplorerPolicyAttribute : PolicyAttribute
    {
        #region Constructor
        public ExplorerPolicyAttribute(string description, string valueName = "")
            : base("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", description, valueName)
        {
            this.Category = "Windows Explorer";
        }
        #endregion

        #region Ovverdies
        public override object GetValueForAttribute(bool enable)
        {
            var returnValue = base.GetValueForAttribute(enable);
            if (!String.IsNullOrWhiteSpace(this.ValueName))
            {
                switch (this.ValueName)
                {
                    case "NoDriveAutoRun":
                        returnValue = (int)returnValue * (int)(Math.Pow(2, 26));
                        break;
                    case "Btn_Folders":
                        returnValue = (int)returnValue * 2;
                        break;
                    default:
                        break;
                }
            }
            return returnValue;
        }
        #endregion
    }
    #endregion

    #region SystemPolicyAttribute
    public class SystemPolicyAttribute : PolicyAttribute
    {
        #region Constructor

        public SystemPolicyAttribute(string description, string valueName = "")
            : base("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", description, valueName)
        {
            this.Category = "System";
        }

        public SystemPolicyAttribute(string description, Microsoft.Win32.RegistryHive hive, string valueName = "")
            : base("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", description, valueName)
        {
            this.Category = "System";
            this.Hive = hive;
        }

        #endregion

        #region Ovverdies
        public override object GetValueForAttribute(bool enable)
        {
            var returnValue = base.GetValueForAttribute(enable);
            if (!String.IsNullOrWhiteSpace(this.ValueName))
            {
                switch (this.ValueName)
                {
                    case "DisableCMD":
                        returnValue = (int)returnValue * 2;
                        break;
                    default:
                        break;
                }
            }
            return returnValue;
        }
        #endregion
    }
    #endregion

    #region NetworkPolicyAttribute
    public class NetworkPolicyAttribute : PolicyAttribute
    {
        #region Constructor
        public NetworkPolicyAttribute(string description, string valueName = "")
            : base("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Network", description, valueName)
        {
            this.Category = "Network";
        }
        #endregion
    }
    #endregion

    #region CommonDialogPolicyAttribute
    public class CommonDialogPolicyAttribute : PolicyAttribute
    {
        #region Constructor
        public CommonDialogPolicyAttribute(string description, string valueName = "")
            : base("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Comdlg32", description, valueName)
        {
            this.Category = "Common Dialog";
        }
        #endregion
    }
    #endregion

    #region NoEnumPolicyAttribute
    public class NoEnumPolicyAttribute : PolicyAttribute
    {
        #region Constructor
        public NoEnumPolicyAttribute(string description, string valueName = "")
            : base("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\NonEnum", description, valueName)
        {
            this.Category = "Explorer";
        }
        #endregion
    }
    #endregion

    #region UsbStorPolicyAttribute
    public class UsbStorPolicyAttribute : PolicyAttribute
    {
        #region Constructor
        public UsbStorPolicyAttribute(string description, string valueName = "")
            : base("System\\CurrentControlSet\\Services\\UsbStor", description, valueName)
        {
            this.Hive = Microsoft.Win32.RegistryHive.LocalMachine;
            this.Category = "Hardware";
        }
        #endregion

        #region Ovverdies
        public override object GetValueForAttribute(bool enable)
        {
            return enable ? 4 : 3;
        }
        #endregion
    }
    #endregion

    #region UninstallAttribute
    public class UninstallAttribute : PolicyAttribute
    {
        #region Constructor
        public UninstallAttribute(string description, string valueName = "")
            : base(@"Software\Microsoft\Windows\CurrentVersion\Policies\Uninstall", description, valueName)
        {
            this.Category = "Uninstall";
        }
        #endregion
    }
    #endregion
}
