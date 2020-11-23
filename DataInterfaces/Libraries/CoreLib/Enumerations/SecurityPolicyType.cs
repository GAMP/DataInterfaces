using SharedLib;
using System;

namespace CoreLib
{
    /// <summary>
    /// Security policies types.
    /// </summary>
    public enum SecurityPolicyType
    {
        #region MESSENGER

        /// <summary>
        /// Disable Collaboration Applications.
        /// </summary>
        [Obsolete()]
        [MessengerPolicy("Disable Collaboration Applications")]
        DisableCollaborationApps = 1,

        /// <summary>
        /// Disable File Transfer.
        /// </summary>
        [Obsolete()]
        [MessengerPolicy("Disable File Transfer")]
        DisableFileTransfer = 2,

        /// <summary>
        /// Disable PC2PCAudio.
        /// </summary>
        [Obsolete()]
        [MessengerPolicy("Disable PC2PCAudio")]
        DisablePC2PCAudio = 3,

        /// <summary>
        /// Disable PC2Phone.
        /// </summary>
        [Obsolete()]
        [MessengerPolicyAttribute("Disable PC2Phone")]
        DisablePC2Phone = 4,

        /// <summary>
        /// Disable Video.
        /// </summary>
        [Obsolete()]
        [MessengerPolicy("Disable Video")]
        DisableVideo = 5,

        /// <summary>
        /// Prevent Auto Update.
        /// </summary>
        [Obsolete()]
        [MessengerPolicy("Prevent Auto Update")]
        PreventAutoUpdate = 6,

        /// <summary>
        /// Prevent Background Download.
        /// </summary>
        [Obsolete()]
        [MessengerPolicy("Prevent Background Download")]
        PreventBackgroundDownload = 7,

        /// <summary>
        /// Prevent Consumer Version.
        /// </summary>
        [Obsolete()]
        [MessengerPolicy("Prevent Consumer Version")]
        PreventConsumerVersion = 8,

        #endregion

        #region INTERNET EXPLORER TOOLBARS

        /// <summary>
        /// Disable the ability to change toolbar selection.
        /// </summary>
        [Obsolete()]
        [InternetExplorerToolbarsPolicy("Disable the ability to change toolbar selection")]
        NoToolbarOptions = 9,

        /// <summary>
        /// Disable the address bar.
        /// </summary>
        [Obsolete()]
        [InternetExplorerToolbarsPolicy("Disable the address bar")]
        NoAddressBar = 10,

        /// <summary>
        /// Disable the tool bar.
        /// </summary>
        [Obsolete()]
        [InternetExplorerToolbarsPolicy("Disable the tool bar")]
        NoToolBar = 11,

        /// <summary>
        /// Disable the links bar.
        /// </summary>
        [Obsolete()]
        [InternetExplorerToolbarsPolicy("Disable the links bar")]
        NoLinksBar = 12,

        #endregion

        #region INTERNET EXPLORER SECURITY

        /// <summary>
        /// Always prompt user when downloading files.
        /// </summary>
        [Obsolete()]
        [InternetExplorerPolicy("Always prompt user when downloading files")]
        AlwaysPromptWhenDownload = 13,

        /// <summary>
        /// Disable changes to browsers bars.
        /// </summary>
        [Obsolete()]
        [InternetExplorerPolicy("Disable changes to browsers bars")]
        NoBrowserBars = 14,

        /// <summary>
        /// Disable the option of closing Internet Explorer.
        /// </summary>
        [Obsolete()]
        [InternetExplorerPolicy("Disable the option of closing Internet Explorer")]
        NoBrowserClose = 15,

        /// <summary>
        /// Disable right-click context menu.
        /// </summary>
        [Obsolete()]
        [InternetExplorerPolicy("Disable right-click context menu")]
        NoBrowserContextMenu = 16,

        /// <summary>
        /// Disable the Tools > Internet Options menu.
        /// </summary>
        [Obsolete()]
        [InternetExplorerPolicy("Disable the Tools > Internet Options menu")]
        NoBrowserOptions = 17,

        /// <summary>
        /// Disable the ability to Save As.
        /// </summary>
        [Obsolete()]
        [InternetExplorerPolicy("Disable the ability to Save As")]
        NoBrowserSaveAs = 18,

        /// <summary>
        /// Disable the Favorites.
        /// </summary>
        [Obsolete()]
        [InternetExplorerPolicy("Disable the Favorites")]
        NoFavorites = 19,

        /// <summary>
        /// Disable the File > New command.
        /// </summary>
        [Obsolete()]
        [InternetExplorerPolicy("Disable the File > New command")]
        NoFileNew = 20,

        /// <summary>
        /// Disable the File > Open command.
        /// </summary>
        [Obsolete()]
        [InternetExplorerPolicy("Disable the File > Open command")]
        NoFileOpen = 21,

        /// <summary>
        /// Disable the Find Files command.
        /// </summary>
        [Obsolete()]
        [InternetExplorerPolicy("Disable the Find Files command")]
        NoFindFiles = 22,

        /// <summary>
        /// Disables the Forward and Back navigation buttons.
        /// </summary>
        [Obsolete()]
        [InternetExplorerPolicy("Disables the Forward and Back navigation buttons")]
        NoNavButtons = 23,

        /// <summary>
        /// Disable Open in New Window option.
        /// </summary>
        [Obsolete()]
        [InternetExplorerPolicy("Disable Open in New Window option")]
        NoOpeninNewWnd = 24,

        /// <summary>
        /// Remove Print and Print Preview from the File menu.
        /// </summary>
        [Obsolete()]
        [InternetExplorerPolicy("Remove Print and Print Preview from the File menu")]
        NoPrinting = 25,

        /// <summary>
        /// Disable the option of selecting a download directory.
        /// </summary>
        [Obsolete()]
        [InternetExplorerPolicy("Disable the option of selecting a download directory")]
        NoSelectDownloadDir = 26,

        /// <summary>
        /// Disable the Full Screen view option.
        /// </summary>
        [Obsolete()]
        [InternetExplorerPolicy("Disable the Full Screen view option")]
        NoTheaterMode = 27,

        /// <summary>
        /// Disable the ability to view the page source HTML.
        /// </summary>
        [Obsolete()]
        [InternetExplorerPolicy("Disable the ability to view the page source HTML")]
        NoViewSource = 28,

        /// <summary>
        /// Remove Mail and News menu item.
        /// </summary>
        [Obsolete()]
        [InternetExplorerPolicy("Remove Mail and News menu item")]
        RestGoMenu = 29,

        #endregion

        #region EXPLORER

        /// <summary>
        /// Remove folders button.
        /// </summary>
        [ExplorerPolicy("Remove folders button", "Btn_Folders")]
        Btn_Folders = 30,

        /// <summary>
        /// Remove the Option to Change or Hide Toolbars
        /// </summary>
        [ExplorerPolicy("Remove the Option to Change or Hide Toolbars")]
        NoBandCustomize = 31,

        /// <summary>
        /// Disable Shut Down.
        /// </summary>
        [ExplorerPolicy("Disable Shut Down , Restart or Sleep")]
        NoClose = 32,

        /// <summary>
        /// Disable Desktop.
        /// </summary>
        [ExplorerPolicy("Disable Desktop")]
        NoDesktop = 33,

        /// <summary>
        /// Disable Removable Media autorun.
        /// </summary>
        [ExplorerPolicy("Disable Removable Media autorun", "NoDriveAutoRun")]
        NoDriveAutoRun = 34,

        /// <summary>
        /// Hide Drives in My Computer.
        /// </summary>
        [ExplorerPolicy("Hide Drives in My Computer")]
        NoDrives = 35,

        /// <summary>
        /// Disable File Menu.
        /// </summary>
        [ExplorerPolicy("Disable File Menu")]
        NoFileMenu = 36,

        /// <summary>
        /// Disable File to Url.
        /// </summary>
        [ExplorerPolicy("Disable File to Url")]
        NoFileUrl = 37,

        /// <summary>
        /// Disable search features.
        /// </summary>
        [ExplorerPolicy("Disable search features")]
        NoFind = 38,

        /// <summary>
        /// Disable Folder Options Menu.
        /// </summary>
        [ExplorerPolicy("Disable Folder Options Menu")]
        NoFolderOptions = 39,

        /// <summary>
        /// Remove the Map and Disconnect Network Drive Options.
        /// </summary>
        [ExplorerPolicy("Remove the Map and Disconnect Network Drive Options")]
        NoNetConnectDisconnect = 40,

        /// <summary>
        /// Disable Network Neighborhood.
        /// </summary>
        [ExplorerPolicy("Disable Network Neighborhood")]
        NoNetHood = 41,

        /// <summary>
        /// Disable Run.
        /// </summary>
        [ExplorerPolicy("Disable Run")]
        NoRun = 42,

        /// <summary>
        /// Disable saving settings on exit.
        /// </summary>
        [ExplorerPolicy("Disable saving settings on exit")]
        NoSaveSettings = 43,

        /// <summary>
        /// Disable the Ability to Customize Toolbars.
        /// </summary>
        [ExplorerPolicy("Disable the Ability to Customize Toolbars")]
        NoToolbarCustomize = 44,

        /// <summary>
        /// Remove shortcut menus from the desktop and from Windows Explorer.
        /// </summary>
        [ExplorerPolicy("Remove shortcut menus from the desktop and from Windows Explorer")]
        NoViewContextMenu = 45,

        /// <summary>
        /// Disable Log Off.
        /// </summary>
        [ExplorerPolicy("Disable Log Off", "NoLogOff")]
        DisableLogOff = 60,

        /// <summary>
        /// Disable tray contextual menu.
        /// </summary>
        [ExplorerPolicy("Disable tray contextual menu", "NoTrayContextMenu")]
        NoTrayContextMenu = 62,

        /// <summary>
        /// Disable control panel (disables both old and new control panels).
        /// </summary>
        [ExplorerPolicy("Disable control panel (disables both old and new control panels)", "NoControlPanel")]
        NoExplorerControlPanel = 63,

        /// <summary>
        /// Remove logoff/sign out option from start menu.
        /// </summary>
        [ExplorerPolicy("Remove logoff/sign out option from start menu")]
        StartMenuLogOff = 64,

        #endregion

        #region SYSTEM

        /// <summary>
        /// Disable the Change Password Button.
        /// </summary>
        [SystemPolicy("Disable the Change Password Button")]
        DisableChangePassword = 47,

        /// <summary>
        /// Disable the Command Prompt.
        /// </summary>
        [WindowsSystemPolicy("Disable the Command Prompt", "DisableCMD")]
        DisableCMD = 48,

        /// <summary>
        /// Disable Workstation Lock.
        /// </summary>
        [SystemPolicy("Disable Workstation Lock")]
        DisableLockWorkstation = 49,

        /// <summary>
        /// Disable Registry Tools.
        /// </summary>
        [SystemPolicy("Disable Registry Tools")]
        DisableRegistryTools = 50,

        /// <summary>
        /// Disable Task Manager.
        /// </summary>
        [SystemPolicy("Disable Task Manager")]
        DisableTaskMgr = 59,

        /// <summary>
        /// Hide Fast User Switching.
        /// </summary>
        [SystemPolicy("Hide Fast User Switching", Microsoft.Win32.RegistryHive.LocalMachine)]
        HideFastUserSwitching = 61,

        #endregion

        #region NETWORK

        /// <summary>
        /// Hide Entire Network in Network Neighborhood.
        /// </summary>
        [NetworkPolicy("Hide Entire Network in Network Neighborhood")]
        NoEntireNetwork = 51,

        #endregion

        #region COMMON DIALOG

        /// <summary>
        /// Remove back button.
        /// </summary>
        [CommonDialogPolicy("Remove back button")]
        NoBackButton = 52,

        /// <summary>
        /// Hide most recently used files.
        /// </summary>
        [CommonDialogPolicy("Hide most recently used files")]
        NoFileMRU = 53,

        /// <summary>
        /// Hide places bar.
        /// </summary>
        [CommonDialogPolicy("Hide places bar")]
        NoPlacesBar = 54,

        #endregion

        #region NOENUM

        /// <summary>
        /// Hide My Computer.
        /// </summary>
        [NoEnumPolicy("Hide My Computer", "{20D04FE0-3AEA-1069-A2D8-08002B30309D}")]
        NoMyComputer = 55,

        /// <summary>
        /// Hide Network Places.
        /// </summary>
        [NoEnumPolicy("Hide Network Places", "{20D04FE0-3AEA-1069-A2D7-08002B30309D}")]
        NoNetworkPlaces = 56,

        /// <summary>
        /// Hide Control Panel.
        /// </summary>
        [NoEnumPolicy("Hide Control Panel", "{21EC2020-3AEA-1069-A2DD-08002B30309D}")]
        NoControlPanel = 57,

        #endregion

        #region USBSTOR

        /// <summary>
        /// Disable USB Mass Storage.
        /// </summary>
        [UsbStorPolicy("Disable USB Mass Storage", "Start")]
        UsbStorage = 58,

        #endregion

        #region UNINSTALL

        /// <summary>
        /// Disable Add/Remove Programs (Windows XP Only).
        /// </summary>
        [UninstallPolicy("Disable Add/Remove Programs (Windows XP Only)")]
        NoAddRemovePrograms = 46,

        #endregion

        #region CHROME
        
        /// <summary>
        /// Disable Chrome downloads.
        /// </summary>
        [ChromePolicy("Disable Chrome downloads", "DownloadRestrictions")]
        ChromeNoDownload = 65, 

        #endregion
    }
}
