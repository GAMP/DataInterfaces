using System;

namespace SharedLib
{
    #region PolicyAttribute
    /// <summary>
    /// Policy attribute.
    /// </summary>
    public abstract class PolicyAttribute : Attribute
    {
        #region CONSTRUCTOR
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

            if (string.IsNullOrWhiteSpace(registryPath))
                throw new ArgumentException("Registry path may not be null or empty.", "RegistryPath");

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description may not be null or empty.", "Description");

            #endregion

            //registry path of restriction
            RegistryPath = registryPath;

            //if value name is emty enum value should be used
            ValueName = valueName;

            //set description
            Description = description;
        }
        #endregion

        #region FIELDS
        private Microsoft.Win32.RegistryHive hive = Microsoft.Win32.RegistryHive.CurrentUser;
        #endregion

        #region PROPERTIES

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
            get { return hive; }
            protected set { hive = value; }
        }

        #endregion

        #region FUNCTIONS
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
            Category = "MSN Messenger";
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
            Category = "Internet Explorer";
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
            Category = "Internet Explorer Toolbars";
        }
        #endregion
    }
    #endregion

    #region ExplorerPolicyAttribute
    public class ExplorerPolicyAttribute : PolicyAttribute
    {
        #region CONSTRUCTOR
        public ExplorerPolicyAttribute(string description, string valueName = "")
            : base("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", description, valueName)
        {
            Category = "Windows Explorer";
        }
        #endregion

        #region OVERRIDES
        public override object GetValueForAttribute(bool enable)
        {
            var returnValue = base.GetValueForAttribute(enable);
            if (!string.IsNullOrWhiteSpace(ValueName))
            {
                switch (ValueName)
                {
                    case "NoDriveAutoRun":
                        returnValue = (int)returnValue * (int)Math.Pow(2, 26);
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
    /// <summary>
    /// System policy attribute.
    /// </summary>
    public class SystemPolicyAttribute : PolicyAttribute
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="description">Dscription.</param>
        /// <param name="valueName">Value name.</param>
        public SystemPolicyAttribute(string description, string valueName = "")
            : base("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", description, valueName)
        {
            Category = "System";
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="description">Dscription.</param>
        /// <param name="hive">Registry hive.</param>
        /// <param name="valueName">Value name.</param>
        public SystemPolicyAttribute(string description, Microsoft.Win32.RegistryHive hive, string valueName = "")
            : base("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", description, valueName)
        {
            Category = "System";
            Hive = hive;
        }

        #endregion
    }
    #endregion

    #region WindowsSystemPolicyAttribute
    /// <summary>
    /// Windows security policy attribute.
    /// </summary>
    public class WindowsSystemPolicyAttribute : PolicyAttribute
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="description">Dscription.</param>
        /// <param name="valueName">Value name.</param>
        public WindowsSystemPolicyAttribute(string description, string valueName = "")
            : base(@"Software\Policies\Microsoft\Windows\System", description, valueName)
        {
            Category = "System";
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="description">Dscription.</param>
        /// <param name="hive">Registry hive.</param>
        /// <param name="valueName">Value name.</param>
        public WindowsSystemPolicyAttribute(string description, Microsoft.Win32.RegistryHive hive, string valueName = "")
            : base(@"Software\Policies\Microsoft\Windows\System", description, valueName)
        {
            Category = "System";
            Hive = hive;
        }

        #endregion

        #region OVERRIDES
        public override object GetValueForAttribute(bool enable)
        {
            var returnValue = base.GetValueForAttribute(enable);
            if (!string.IsNullOrWhiteSpace(ValueName))
            {
                switch (ValueName)
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
    /// <summary>
    /// Network policy attribute.
    /// </summary>
    public class NetworkPolicyAttribute : PolicyAttribute
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="description">Dscription.</param>
        /// <param name="valueName">Value name.</param>
        public NetworkPolicyAttribute(string description, string valueName = "")
            : base("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Network", description, valueName)
        {
            Category = "Network";
        }
        #endregion
    }
    #endregion

    #region CommonDialogPolicyAttribute
    /// <summary>
    /// Common dialog policy attribute.
    /// </summary>
    public class CommonDialogPolicyAttribute : PolicyAttribute
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="description">Dscription.</param>
        /// <param name="valueName">Value name.</param>
        public CommonDialogPolicyAttribute(string description, string valueName = "")
            : base("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Comdlg32", description, valueName)
        {
            Category = "Common Dialog";
        }
        #endregion
    }
    #endregion

    #region NoEnumPolicyAttribute
    /// <summary>
    /// No enumeration policy attribute.
    /// </summary>
    public class NoEnumPolicyAttribute : PolicyAttribute
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="description">Dscription.</param>
        /// <param name="valueName">Value name.</param>
        public NoEnumPolicyAttribute(string description, string valueName = "")
            : base("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\NonEnum", description, valueName)
        {
            Category = "No Enum (Pre Windows 10)";
        }
        #endregion
    }
    #endregion

    #region UninstallPolicyAttribute
    /// <summary>
    /// Uninstall policy attribute.
    /// </summary>
    public class UninstallPolicyAttribute : PolicyAttribute
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="description">Dscription.</param>
        /// <param name="valueName">Value name.</param>
        public UninstallPolicyAttribute(string description, string valueName = "")
            : base(@"Software\Microsoft\Windows\CurrentVersion\Policies\Uninstall", description, valueName)
        {
            Category = "Uninstall";
        }
        #endregion
    }
    #endregion

    #region UsbStorPolicyAttribute
    /// <summary>
    /// USB Stor policy attribute.
    /// </summary>
    public class UsbStorPolicyAttribute : PolicyAttribute
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="description">Dscription.</param>
        /// <param name="valueName">Value name.</param>
        public UsbStorPolicyAttribute(string description, string valueName = "")
            : base("System\\CurrentControlSet\\Services\\UsbStor", description, valueName)
        {
            Hive = Microsoft.Win32.RegistryHive.LocalMachine;
            Category = "Hardware";
        }
        #endregion

        #region OVERRIDES
        /// <summary>
        /// Gets value for the attribute.
        /// </summary>
        /// <param name="enable">Enable parameter.</param>
        /// <returns>Value.</returns>
        public override object GetValueForAttribute(bool enable)
        {
            return enable ? 4 : 3;
        }
        #endregion
    }
    #endregion    

    #region ChromePolicyAttribute
    public class ChromePolicyAttribute : PolicyAttribute
    {
        #region CONSTRUCTOR
        public ChromePolicyAttribute(string description, string valueName = "") : base(@"SOFTWARE\Policies\Google\Chrome", description, valueName)
        {
            Category = "Chrome";
        }
        #endregion

        #region OVERRIDES
        public override object GetValueForAttribute(bool enable)
        {
            return enable ? 3 : PolicyValueDeleteResult.Instance;
        }
        #endregion
    }
    #endregion
 
}
