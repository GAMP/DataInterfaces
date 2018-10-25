using Localization;
using System;

namespace Client
{
    #region MESSAGEDIALOGBUTTONS
    [Flags()]
    public enum MessageDialogButtons
    {
        None = 0,
        Accept = 1,
        Cancel = 2,
        AcceptCancel = Accept | Cancel,
    } 
    #endregion

    #region CLIENTSTARTUPACTIVITY
    /// <summary>
    /// Shared Module activity enumeration.
    /// </summary>
    public enum ClientStartupActivity
    {
        [Localized("EN_SMA_STARTING_NETWORK_SERVICES")]
        StartingNetworkServices,
        [Localized("EN_SMA_STARTING_UI")]
        StartingUi,
        [Localized("EN_SMA_STARTING_SHELL")]
        StartingShell,
        [Localized("EN_SMA_INITIATING_CONNECTION")]
        InitiatingConnection,
        [Localized("EN_SMA_INSTALLING_DRIVER")]
        InstallingSystemDriver,
        [Localized("EN_SMA_UNINSTALLING_DRIVER")]
        UninstallingSystemDriver,
        [Localized("EN_SMA_CHECKING_DRIVER")]
        CheckingSystemDriver,
        [Localized("EN_SMA_SETTING_USER_PROFILE")]
        SettingPersonalUserFiles,
        [Localized("EN_SMA_CREATING_STORAGE")]
        CreatingUserStorage,
        [Localized("EN_SMA_DESTROYING_STORAGE")]
        DestroyingUserStorage,
        [Localized("EN_SMA_PROCESSING_TASKS")]
        ProcessingTasks,
        [Localized("EN_SMA_DESTROYING_CONTEXTS")]
        DestroyingUserContexts,
        [Localized("EN_SMA_EXECUTING_LOGOUT_ACTION")]
        ExecutingLogoutAction,
        [Localized("EN_SMA_TERMINATING_USER_PROCESSES")]
        TerminatingUserProcesses,
        [Localized("EN_SMA_INITIALIZING_PLUGINS")]
        InitializingPlugins,
        [Localized("EN_SMA_LOADING_PLUGINS")]
        LoadingPlugins,
        [Localized("EN_SMA_CONFIGURING_FIREWALL")]
        ConfiguringFirewall,
        [Localized("EN_SMA_PARSING_ARGUMENTS")]
        ParsingArguments,
        [Localized("EN_SMA_EXPANDING_VARIABLES")]
        ExpandingVariables,
        [Localized("EN_SMA_RESOLVING_SERVER_IP")]
        ResolvingServerIp,
        [Localized("EN_SMA_PROCESSING_DRIVE_MAPPINGS")]
        ProcessingDriveMappings,
    }
    #endregion
}
