using Localization;
using System;

namespace Client
{
    /// <summary>
    /// Shared Module activity enumeration.
    /// </summary>
    public enum ClientStartupActivity
    {
        /// <summary>
        /// Starting network services.
        /// </summary>
        [Localized("EN_SMA_STARTING_NETWORK_SERVICES")]
        StartingNetworkServices,
        /// <summary>
        /// Starting UI.
        /// </summary>
        [Localized("EN_SMA_STARTING_UI")]
        StartingUi,
        /// <summary>
        /// Starting shell.
        /// </summary>
        [Obsolete("Shell functionality is no longer used.")]
        [Localized("EN_SMA_STARTING_SHELL")]
        StartingShell,
        /// <summary>
        /// Initiating server connection.
        /// </summary>
        [Localized("EN_SMA_INITIATING_CONNECTION")]
        InitiatingConnection,
        /// <summary>
        /// Installing system drivers.
        /// </summary>
        [Localized("EN_SMA_INSTALLING_DRIVER")]
        InstallingSystemDriver,
        /// <summary>
        /// Uninstalling system drivers.
        /// </summary>
        [Localized("EN_SMA_UNINSTALLING_DRIVER")]
        UninstallingSystemDriver,
        /// <summary>
        /// Checking system drivers.
        /// </summary>
        [Localized("EN_SMA_CHECKING_DRIVER")]
        CheckingSystemDriver,
        /// <summary>
        /// Setting personal user files.
        /// </summary>
        [Localized("EN_SMA_SETTING_USER_PROFILE")]
        SettingPersonalUserFiles,
        /// <summary>
        /// Creating personal user storage.
        /// </summary>
        [Localized("EN_SMA_CREATING_STORAGE")]
        CreatingUserStorage,
        /// <summary>
        /// Destroying personal user storage.
        /// </summary>
        [Localized("EN_SMA_DESTROYING_STORAGE")]
        DestroyingUserStorage,
        /// <summary>
        /// Processing tasks.
        /// </summary>
        [Localized("EN_SMA_PROCESSING_TASKS")]
        ProcessingTasks,
        /// <summary>
        /// Destroying user processes contexts.
        /// </summary>
        [Localized("EN_SMA_DESTROYING_CONTEXTS")]
        DestroyingUserContexts,
        /// <summary>
        /// Executing logout action.
        /// </summary>
        [Localized("EN_SMA_EXECUTING_LOGOUT_ACTION")]
        ExecutingLogoutAction,
        /// <summary>
        /// Terminating user process.
        /// </summary>
        [Localized("EN_SMA_TERMINATING_USER_PROCESSES")]
        TerminatingUserProcesses,
        /// <summary>
        /// Initializing plugins.
        /// </summary>
        [Localized("EN_SMA_INITIALIZING_PLUGINS")]
        InitializingPlugins,
        /// <summary>
        /// Loading plugin files.
        /// </summary>
        [Localized("EN_SMA_LOADING_PLUGINS")]
        LoadingPlugins,
        /// <summary>
        /// Configuring firewall.
        /// </summary>
        [Localized("EN_SMA_CONFIGURING_FIREWALL")]
        ConfiguringFirewall,
        /// <summary>
        /// Parsing command line arguments.
        /// </summary>
        [Localized("EN_SMA_PARSING_ARGUMENTS")]
        ParsingArguments,
        /// <summary>
        /// Expanding variabled.
        /// </summary>
        [Localized("EN_SMA_EXPANDING_VARIABLES")]
        ExpandingVariables,
        /// <summary>
        /// Resolving server ip.
        /// </summary>
        [Localized("EN_SMA_RESOLVING_SERVER_IP")]
        ResolvingServerIp,
        /// <summary>
        /// Mapping drives.
        /// </summary>
        [Localized("EN_SMA_PROCESSING_DRIVE_MAPPINGS")]
        ProcessingDriveMappings,
    }
}
