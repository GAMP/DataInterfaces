using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedLib;

namespace CoreLib
{
    #region KnownArgumentType
    /// <summary>
    /// Enumeration of shared command line agument types.
    /// </summary>
    [Obsolete()]
    public enum KnownArgumentType : int
    {
        Load = 0,
        Connect = 1,
        Exit = 2,
        Login = 3,
        Logout = 4,
        Install = 5,
        Uninstall = 6,
        FirstRun = 7,
    }
    #endregion

    #region OperatingSystems
    /// <summary>
    /// Operating system type enumeration.
    /// </summary>
    public enum OperatingSystems
    {
        Unknown = 0,
        WindowsXp,
        WindowsVista,
        Windows7,
        Windows8,
        Windows2000,
        WindowsMe,
        Windows98,
        WindowsNT,
        Windows95,
        WindowsServer2003,
        WindowsServer2003R2,
        WindowsHomeServer,
        WindowsServer2008,
        WindowsServer2008R2,
        WindowsServer2012,
    }
    #endregion

    #region ProcessExitCode
    /// <summary>
    /// Process exit codes.
    /// </summary>
    public enum ProcessExitCode
    {
        /// <summary>
        /// Application was shutdown.
        /// </summary>
        ShutDown = -512,
        /// <summary>
        /// Application was restarted.
        /// </summary>
        Restart = -513,
        /// <summary>
        /// Application error occurred.
        /// </summary>
        Error = -514,
        /// <summary>
        /// Update exit code.
        /// </summary>
        Update=-515,
    }
    #endregion    

    #region ValueSource
    /// <summary>
    /// Value source enumerations.
    /// </summary>
    public enum KeyValueSource
    {
        /// <summary>
        /// Indicates file source.
        /// </summary>
        File,
        /// <summary>
        /// Indicates registry source.
        /// </summary>
        Registry,
        /// <summary>
        /// Indicates memory source.
        /// </summary>
        Memory,
    }
    #endregion

    #region KeyboardLayoutHotKey
    /// <summary>
    /// Keyboard switching sequence.
    /// </summary>
    public enum KeyboardLayoutHotKey
    {
        /// <summary>
        /// Disabled.
        /// </summary>
        Disabled = 3,
        /// <summary>
        /// Alt+Shift.
        /// </summary>
        Alt_Shift = 1,
        /// <summary>
        /// Ctrl_Shift.
        /// </summary>
        Ctrl_Shift = 2,
    }
    #endregion    

    #region RestrictionType
    /// <summary>
    /// Restriction type enumeration.
    /// </summary>
    public enum RestrictionType
    {
        [CanUserAssign(false)]
        Unset = 0,
        [CanUserAssign(true)]
        FileName = 1,
        [CanUserAssign(true)]
        ClassName = 2,
        [CanUserAssign(true)]
        WindowName = 3,
        [CanUserAssign(true)]
        TrayIcon = 4
    }
    #endregion

    #region SecurityPolicyType
    public enum SecurityPolicyType
    {
        #region Messenger

        [MessengerPolicyAttribute("Disable Collaboration Applications")]
        DisableCollaborationApps = 1,

        [MessengerPolicyAttribute("Disable File Transfer")]
        DisableFileTransfer = 2,

        [MessengerPolicyAttribute("Disable PC2PCAudio")]
        DisablePC2PCAudio = 3,

        [MessengerPolicyAttribute("Disable PC2Phone")]
        DisablePC2Phone = 4,

        [MessengerPolicyAttribute("Disable Video")]
        DisableVideo = 5,

        [MessengerPolicyAttribute("Prevent Auto Update")]
        PreventAutoUpdate = 6,

        [MessengerPolicyAttribute("Prevent Background Download")]
        PreventBackgroundDownload = 7,

        [MessengerPolicyAttribute("Prevent Consumer Version")]
        PreventConsumerVersion = 8,

        #endregion

        #region Internet Explorer Toolbars

        [InternetExplorerToolbarsPolicy("Disable the ability to change toolbar selection")]
        NoToolbarOptions = 9,

        [InternetExplorerToolbarsPolicy("Disable the address bar")]
        NoAddressBar = 10,

        [InternetExplorerToolbarsPolicy("Disable the tool bar")]
        NoToolBar = 11,

        [InternetExplorerToolbarsPolicy("Disable the links bar")]
        NoLinksBar = 12,

        #endregion

        #region Internet Explorer Security

        [InternetExplorerPolicy("Always prompt user when downloading files")]
        AlwaysPromptWhenDownload = 13,

        [InternetExplorerPolicy("Disable changes to browsers bars")]
        NoBrowserBars = 14,

        [InternetExplorerPolicy("Disable the option of closing Internet Explorer")]
        NoBrowserClose = 15,

        [InternetExplorerPolicy("Disable right-click context menu")]
        NoBrowserContextMenu = 16,

        [InternetExplorerPolicy("Disable the Tools > Internet Options menu")]
        NoBrowserOptions = 17,

        [InternetExplorerPolicy("Disable the ability to Save As")]
        NoBrowserSaveAs = 18,

        [InternetExplorerPolicy("Disable the Favorites")]
        NoFavorites = 19,

        [InternetExplorerPolicy("Disable the File > New command")]
        NoFileNew = 20,

        [InternetExplorerPolicy("Disable the File > Open command")]
        NoFileOpen = 21,

        [InternetExplorerPolicy("Disable the Find Files command")]
        NoFindFiles = 22,

        [InternetExplorerPolicy("Disables the Forward and Back navigation buttons")]
        NoNavButtons = 23,

        [InternetExplorerPolicy("Disable Open in New Window option")]
        NoOpeninNewWnd = 24,

        [InternetExplorerPolicy("Remove Print and Print Preview from the File menu")]
        NoPrinting = 25,

        [InternetExplorerPolicy("Disable the option of selecting a download directory")]
        NoSelectDownloadDir = 26,

        [InternetExplorerPolicy("Disable the Full Screen view option")]
        NoTheaterMode = 27,

        [InternetExplorerPolicy("Disable the ability to view the page source HTML")]
        NoViewSource = 28,

        [InternetExplorerPolicy("Remove Mail and News menu item")]
        RestGoMenu = 29,

        #endregion

        #region Explorer

        [ExplorerPolicy("Remove folders button", "Btn_Folders")]
        Btn_Folders = 30,

        [ExplorerPolicy("Remove the Option to Change or Hide Toolbars ")]
        NoBandCustomize = 31,

        [ExplorerPolicy("Disable Shut Down")]
        NoClose = 32,

        [ExplorerPolicy("Disable Desktop")]
        NoDesktop = 33,

        [ExplorerPolicy("Disable Removable Media autorun", "NoDriveAutoRun")]
        NoDriveAutoRun = 34,

        [ExplorerPolicy("Hide Drives in My Computer")]
        NoDrives = 35,

        [ExplorerPolicy("Disable File Menu")]
        NoFileMenu = 36,

        [ExplorerPolicy("Disable File to Url")]
        NoFileUrl = 37,

        [ExplorerPolicyAttribute("Disable search features")]
        NoFind = 38,

        [ExplorerPolicy("Disable Folder Options Menu")]
        NoFolderOptions = 39,

        [ExplorerPolicy("Remove the Map and Disconnect Network Drive Options")]
        NoNetConnectDisconnect = 40,

        [ExplorerPolicy("Disable Network Neighborhood")]
        NoNetHood = 41,

        [ExplorerPolicy("Disable Run")]
        NoRun = 42,

        [ExplorerPolicy("Disable saving settings on exit")]
        NoSaveSettings = 43,

        [ExplorerPolicy("Disable the Ability to Customize Toolbars")]
        NoToolbarCustomize = 44,

        [ExplorerPolicy("Remove shortcut menus from the desktop and from Windows Explorer")]
        NoViewContextMenu = 45,      

        [ExplorerPolicy("Disable Log Off", "NoLogOff")]
        DisableLogOff = 60,

        #endregion

        #region System

        [SystemPolicy("Disable the Change Password Button")]
        DisableChangePassword = 47,

        [SystemPolicy("Disable the Command Prompt","DisableCMD")]
        DisableCMD = 48,

        [SystemPolicy("Disable Workstation Lock")]
        DisableLockWorkstation = 49,

        [SystemPolicy("Disable Registry Tools")]
        DisableRegistryTools = 50,

        [SystemPolicy("Disable Task Manager")]
        DisableTaskMgr = 59, 

        [SystemPolicy("Hide Fast User Switching",  Microsoft.Win32.RegistryHive.LocalMachine)]
        HideFastUserSwitching =61,

        #endregion

        #region Network

        [NetworkPolicy("Hide Entire Network in Network Neighborhood")]
        NoEntireNetwork=51,

        #endregion

        #region Common Dialog

        [CommonDialogPolicy("Remove back button")]
        NoBackButton=52,

        [CommonDialogPolicy("Hide most recently used files")]
        NoFileMRU=53,

        [CommonDialogPolicy("Hide places bar")]
        NoPlacesBar=54,

        #endregion

        #region NoEnum

        [NoEnumPolicy("Hide My Computer", "{20D04FE0-3AEA-1069-A2D8-08002B30309D}")]
        NoMyComputer=55,

        [NoEnumPolicy("Hide Network Places", "{20D04FE0-3AEA-1069-A2D7-08002B30309D}")]
        NoNetworkPlaces = 56,

        [NoEnumPolicy("Hide Control Panel", "{21EC2020-3AEA-1069-A2DD-08002B30309D}")]
        NoControlPanel = 57,

        #endregion

        #region UsbStor
        [UsbStorPolicy("Disable USB Mass Storage","Start")]
        UsbStorage=58,
        #endregion

        #region Uninstall
        [Uninstall("Disable Add/Remove Programs (Windows XP Only)")]
        NoAddRemovePrograms = 46
        #endregion
    }
    #endregion

    #region PowerStates
    public enum PowerStates : byte
    {
        None = 0,
        Reboot = 1,
        Shutdown = 2,
        Suspend = 4,
        Hibernate = 8,
        Logoff = 16,
    }
    #endregion
}
