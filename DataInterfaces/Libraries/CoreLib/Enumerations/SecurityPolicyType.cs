using SharedLib;

namespace CoreLib
{
    #region SecurityPolicyType
    public enum SecurityPolicyType
    {
        #region Messenger

        [MessengerPolicy("Disable Collaboration Applications")]
        DisableCollaborationApps = 1,

        [MessengerPolicy("Disable File Transfer")]
        DisableFileTransfer = 2,

        [MessengerPolicy("Disable PC2PCAudio")]
        DisablePC2PCAudio = 3,

        [MessengerPolicyAttribute("Disable PC2Phone")]
        DisablePC2Phone = 4,

        [MessengerPolicy("Disable Video")]
        DisableVideo = 5,

        [MessengerPolicy("Prevent Auto Update")]
        PreventAutoUpdate = 6,

        [MessengerPolicy("Prevent Background Download")]
        PreventBackgroundDownload = 7,

        [MessengerPolicy("Prevent Consumer Version")]
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

        [ExplorerPolicy("Disable search features")]
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

        [ExplorerPolicy("Disable tray contextual menu", "NoTrayContextMenu")]
        NoTrayContextMenu = 62,

        [ExplorerPolicy("Disable control panel (disables both old and new control panels)", "NoControlPanel")]
        NoExplorerControlPanel = 63,

        [ExplorerPolicy("Remove logoff/sign out option from start menu")]
        StartMenuLogOff = 64,

        #endregion

        #region System

        [SystemPolicy("Disable the Change Password Button")]
        DisableChangePassword = 47,

        [WindowsSystemPolicy("Disable the Command Prompt","DisableCMD")]
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
}
