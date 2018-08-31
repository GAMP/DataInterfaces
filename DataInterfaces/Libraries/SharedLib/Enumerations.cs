using System;
using System.ComponentModel;
using Localization;

namespace SharedLib
{
    #region OBSOLETE

    #region ActivationType
    /// <summary>
    /// Common activation deactivation types.
    /// </summary>
    [Flags()]
    public enum ActivationType
    {
        [Description("Disabled")]
        Disabled = 0,
        [Description("Startup")]
        Startup = 1,
        [Description("Shutdown")]
        Shutdown = 2,
        [Description("Login")]
        Login = 4,
        [Description("Logout")]
        Logout = 8,
        [Description("Pre Launch")]
        PreLaunch = 16,
        [Description("Pre Deploy")]
        PreDeploy = 32,
        [Description("Post Termination")]
        PostTermination = 64,
        [Description("Pre License Management")]
        PreLicenseManagement = 128,
    }
    #endregion

    #region TaskType
    [Serializable()]
    public enum TaskType
    {
        [CanUserAssign(true)]
        [Localized("TASK_PROCESS")]
        [Description("Process")]
        Process,
        [CanUserAssign(true)]
        [Localized("TASK_SCRIPT")]
        [Description("Script")]
        Script,
        [Obsolete()]
        [CanUserAssign(false)]
        [Description("File System")]
        FileSystem,
        [Obsolete()]
        [CanUserAssign(false)]
        [Description("Task Chain")]
        Chain,
        [CanUserAssign(true)]
        [Localized("TASK_NOTIFICATION")]
        [Description("Notification")]
        Notification,
        [CanUserAssign(true)]
        [Localized("TASK_JUNCTION")]
        [Description("Junction")]
        Junction,
        [CanUserAssign(false)]
        [Localized("ALL")]
        [Description("All Types")]
        AllTypes = 65535,
    }
    #endregion

    #region ActionState
    /// <summary>
    /// Basic enumeration for actions or operations.
    /// </summary>
    [Obsolete()]
    public enum ActionState
    {
        Inactive,
        Comparing,
        Deploying,
        Aborted,
        Failed,
        Compared,
        Aborting,
    }
    #endregion

    #region ManagementTypesEnum
    [Obsolete()]
    public enum ManagementTypesEnum
    {
        Tasking = 0,
        Registry = 1,
        FileSystem = 2,
        Processes = 3,
        Information = 4,
    }
    #endregion

    #region ManagerViewTypes
    [Obsolete()]
    public enum ManagerViewTypes
    {
        Management = 0,
        Screens = 1,
        Log = 2,
        Deployment = 3,
        Settings = 4,
        Applications = 5,
        Users = 6,
        NewsCenter = 7,
        Statistics = 8,
    }
    #endregion

    #region DialogType
    /// <summary>
    /// Dialogue types.
    /// <remarks>
    /// This is generaly used in view models to mark the current dialogue type.
    /// </remarks>
    /// </summary>
    [Obsolete()]
    [Serializable()]
    public enum DialogType
    {
        None = 0,
        Add = 1,
        Edit = 2,
    }
    #endregion

    #endregion

    #region VIEWMODELS

    #region StartPageViewTypes
    public enum StartPageViewTypes
    {
        Home = 0,
        Applications = 1,
        Favorites = 2,
        ControlPanel = 3,
        Media = 4,
        GameServers = 5,
    }
    #endregion

    #region ContextExecutionViewState
    public enum ContextExecutionViewState
    {
        Initial = 0,
        Working = 1,
        Ready = 2,
    }
    #endregion    

    #endregion

    #region QUEUESTATUS
    /// <summary>
    /// Generic queue status codes.
    /// </summary>
    public enum QueueStatus
    {
        Queued = 0,
        Active = 1,
        Paused = 2,
        Canceled = 3,
        Failed = 4,
        Completed = 5,
    }
    #endregion

    #region QUEUEPRIORITY
    /// <summary>
    /// Generic queue priorities.
    /// </summary>
    public enum QueuePriority
    {
        /// <summary>
        /// Low priority.
        /// </summary>
        [Localized("LOW")]
        Low = 0,
        /// <summary>
        /// Medium priority.
        /// </summary>
        [Localized("MEDIUM")]
        Medium = 1,
        /// <summary>
        /// High priority.
        /// </summary>
        [Localized("HIGH")]
        High = 2,
    }
    #endregion

    #region KNOWNFOLDERTYPES
    /// <summary>
    /// This enumerato is used to combine multiple special folders to unique value.
    /// </summary>
    [Flags()]
    public enum KnownFolderTypes
    {
        /// <summary>
        /// Unset flag.
        /// </summary>
        None = 0,
        /// <summary>
        /// Desktop flag.
        /// </summary>
        [GUID("B4BFCC3A-DB2C-424C-B029-7FE99A87C641")]
        [SpecialFolderAttribute(Environment.SpecialFolder.DesktopDirectory)]
        Desktop = 1,
        /// <summary>
        /// Downloads flag.
        /// </summary>
        [GUID("374DE290-123F-4565-9164-39C4925E467B")]
        Downloads = 2,
        /// <summary>
        /// Favorites flag.
        /// </summary>
        [GUID("1777F761-68AD-4D8A-87BD-30B759FA33DD")]
        [SpecialFolderAttribute(Environment.SpecialFolder.Favorites)]
        Favorites = 4,
        /// <summary>
        /// My Music flag.
        /// </summary>
        [GUID("4BD8D571-6D19-48D3-BE97-422220080E43")]
        [SpecialFolderAttribute(Environment.SpecialFolder.MyMusic)]
        Music = 8,
        /// <summary>
        /// My pictures flag.
        /// </summary>
        [GUID("33E28130-4E1E-4676-835A-98395C3BC3BB")]
        [SpecialFolderAttribute(Environment.SpecialFolder.MyPictures)]
        Pictures = 16,
        /// <summary>
        /// My videos flag.
        /// </summary>
        [GUID("18989B1D-99B5-455B-841C-AB7C74E4DDFC")]
        [SpecialFolderAttribute(Environment.SpecialFolder.MyVideos)]
        Videos = 32,
        /// <summary>
        /// Saved games flag.
        /// </summary>
        [GUID("4C5C32FF-BB9D-43b0-B5B4-2D72E54EAAA4")]
        SavedGames = 64,
        /// <summary>
        /// Personal flag (Equals MyDocuments).
        /// </summary>
        [GUID("FDD39AD0-238F-46AF-ADB4-6C85480369C7")]
        [SpecialFolderAttribute(Environment.SpecialFolder.MyDocuments)]
        Personal = 128,
        /// <summary>
        /// Basic flag containing all the basic enumerations.
        /// </summary>
        Basic = KnownFolderTypes.Desktop |
            KnownFolderTypes.Downloads |
            KnownFolderTypes.Favorites |
            KnownFolderTypes.Music |
            KnownFolderTypes.Personal |
            KnownFolderTypes.Pictures |
            KnownFolderTypes.SavedGames |
            KnownFolderTypes.Videos,
    }
    #endregion

    #region DESKTOPITEMTYPE
    /// <summary>
    /// Desktop item type enumeration.
    /// </summary>
    public enum DesktopItemType
    {
        /// <summary>
        /// View is virtual.
        /// </summary>
        Virtual,
        /// <summary>
        /// View is file or virtual file.
        /// </summary>
        File,
    }
    #endregion

    #region LOGINSTATE
    /// <summary>
    /// Login state enumeration.
    /// </summary>
    [Flags()]
    public enum LoginState
    {
        /// <summary>
        /// Logged out.
        /// </summary>
        LoggedOut = 0,
        /// <summary>
        /// Logged in.
        /// </summary>
        LoggedIn = 1,
        /// <summary>
        /// Logging in.
        /// </summary>
        LoggingIn = 2,
        /// <summary>
        /// Logging out.
        /// </summary>
        LoggingOut = 4,
        /// <summary>
        /// Login failed.
        /// </summary>
        LoginFailed = 8,
        ///<summary>
        /// Login completed.
        /// </summary>
        LoginCompleted = 16 | LoggedIn,
    }
    #endregion

    #region CLIENTEVENTTYPES
    /// <summary>
    /// Enumerator for the types of client events.
    /// </summary>
    public enum ClientEventTypes
    {
        LockState,
        IdChange,
        SecurityState,
        OutOfOrderState,
        Maintenance,
    }
    #endregion

    #region CONTEXTEXECUTIONSTATE
    /// <summary>
    /// Execution context state enumeration.
    /// </summary>
    public enum ContextExecutionState
    {
        /// <summary>
        /// Context is in initial state.
        /// </summary>
        Initial,
        /// <summary>
        /// User profile is being acquired from server.
        /// </summary>
        GettingUserProfile,
        /// <summary>
        /// Cd image is being mounted.
        /// </summary>
        Mounting,
        /// <summary>
        /// Cd image is being unmounted.
        /// </summary>
        Unmounting,
        /// <summary>
        /// Executable has exited. This only occures when all children has exited thus executable is considered dead and finalized.
        /// </summary>
        Finalized,
        /// <summary>
        /// Executable process is started.
        /// </summary>
        Starting,
        /// <summary>
        /// Executable process is started and running.
        /// </summary>
        Started,
        /// <summary>
        /// Deployment profile is executed for the executable.
        /// </summary>
        Deploying,
        /// <summary>
        /// Execution aborted.
        /// </summary>
        Aborted,
        /// <summary>
        /// Aborting state.
        /// </summary>
        Aborting,
        /// <summary>
        /// Context failed. Executable not found.
        /// <remarks>The failed function can be determined by previous state.</remarks>
        /// </summary>
        Failed,
        /// <summary>
        /// Executable activated.
        /// </summary>
        Activated,
        /// <summary>
        /// Process window being activated.
        /// </summary>
        Activating,
        /// <summary>
        /// Checking available space.
        /// </summary>
        ChekingAvailableSpace,
        /// <summary>
        /// Making space.
        /// </summary>
        MakingSpace,
        /// <summary>
        /// Allocating free space.
        /// </summary>
        AllocatingSpace,
        /// <summary>
        /// Importing registry.
        /// </summary>
        ImportingRegistry,
        /// <summary>
        /// Comparing.
        /// </summary>
        Validating,
        /// <summary>
        /// Completed state.
        /// </summary>
        Completed,
        /// <summary>
        /// Destroyed.
        /// </summary>
        Destroyed,
        /// <summary>
        /// Context is released.
        /// </summary>
        Released,
        /// <summary>
        /// Execution processing has bein initiated.
        /// </summary>
        Processing,
        /// <summary>
        /// Execuntion processing reinitiated.
        /// </summary>
        Reprocessing,
        /// <summary>
        /// License reservation state.
        /// </summary>
        ReservingLicense,
        /// <summary>
        /// License released state.
        /// </summary>
        ReleasedLicense,
        /// <summary>
        /// License installation state.
        /// </summary>
        InstallingLicense,
        /// <summary>
        /// Occours when process is created in this context.
        /// </summary>
        ProcessCreated,
        /// <summary>
        /// Occours when process of this context has exited.
        /// </summary>
        ProcessExited,
        /// <summary>
        /// Occours when task of this context being executed.
        /// </summary>
        ExecutingTask,
    }
    #endregion

    #region CONTAINERITEMEVENTTYPE
    [Serializable()]
    public enum ContainerItemEventType
    {
        /// <summary>
        /// Occours when item is added to container.
        /// <remarks>NewItems propery contains added items.</remarks>
        /// </summary>
        Added = 0,
        /// <summary>
        /// Occours when shared item is unasigned.
        /// <remarks>NewItems propery contains unasigned items.</remarks>
        /// </summary>
        UnAssigned = 4,
        /// <summary>
        /// Occours when item is removed from container.
        /// <remarks>NewItems propery contains removed items.</remarks>
        /// </summary>
        Removed = 8,
        /// <summary>
        /// Occours when item is replaced/updated.
        /// </summary>
        Replaced = 16,
    }
    #endregion

    #region LOGOUTACTION
    /// <summary>
    /// Client logout action types.
    /// </summary>
    public enum LogoutAction
    {
        [Localized("LOGOUT_ACTION_NONE")]
        NoAction = -1,
        [Localized("LOGOUT_ACTION_REBOOT")]
        Reboot = 0,
        [Localized("LOGOUT_ACTION_CLOSE_PROGRAMS")]
        ClosePrograms = 1,
        [Localized("LOGOUT_ACTION_TURN_OFF")]
        TurnOff = 2,
        [Localized("LOGOUT_ACTION_LOG_OFF")]
        LogOff = 3,
        [Localized("LOGOUT_ACTION_STAND_BY")]
        StandBy = 4,
        AdminMode = 5,
    }
    #endregion

    #region NOTIFICATIONBUTTONS
    public enum NotificationButtons
    {
        None = 0,
        Ok = 1,
        Yes = 2,
        No = 3,
        Cancel = 4,
    }
    #endregion

    #region TIMELEFTWARNINGTYPE
    [Flags()]
    public enum TimeLeftWarningType
    {
        [Localized("TIME_LEFT_WARNING_TYPE_NONE")]
        None = 0,
        [Localized("TIME_LEFT_WARNING_TYPE_VISUAL")]
        Visual = 1,
        [Localized("TIME_LEFT_WARNING_TYPE_AUDIBLE")]
        Audible = 2,
        All = Visual | Audible
    }
    #endregion

    #region AGERATINGTYPE
    public enum AgeRatingType
    {
        [Description("None")]
        None = 0,
        [Description("Manual")]
        Manual = 1,
        [Description("ESRB")]
        ESRB = 2,
        [Description("PEGI")]
        PEGI = 3,
    }
    #endregion    

    #region PEGI
    public enum PEGI
    {
        [Description("Three (3)")]
        [AgeRating(3)]
        Three = -1,
        [AgeRating(4)]
        [Description("Four (4)")]
        Four = -2,
        [AgeRating(6)]
        [Description("Six (6)")]
        Six = -3,
        [AgeRating(7)]
        [Description("Seven (7)")]
        Seven = -4,
        [AgeRating(12)]
        [Description("Twelve (12)")]
        Twelve = -5,
        [Description("Sixteen (16)")]
        [AgeRating(16)]
        Sixteen = -6,
        [Description("Eighteen (18)")]
        [AgeRating(18)]
        Eighteen = -7,
    }
    #endregion

    #region ESRB
    public enum ESRB
    {
        [Description("Early Childhood (EC)")]
        [AgeRating(3)]
        EarlyChildHood = -21,
        [Description("Everyone (E)")]
        [AgeRating(6)]
        EveryOne = -22,
        [Description("Everyone 10+ (E10+)")]
        [AgeRating(10)]
        EveryOneTenPlus = -23,
        [Description("Teen (T)")]
        [AgeRating(13)]
        Teen = -24,
        [Description("Mature (M)")]
        [AgeRating(17)]
        Matrue = -25,
        [Description("Adults Only (AO)")]
        [AgeRating(18)]
        AdaultsOnly = -26,
        [Description("Rating Pending (RP)")]
        [AgeRating(0)]
        RatingPending = -27,
        [Description("Kids to Adults (K-A)")]
        [AgeRating(6)]
        KidsToAdaults = -28,
    }
    #endregion

    #region DURATIONRANGE
    public enum DurationRange
    {
        [Localized("PERIOD_TODAY")]
        Today = 0,
        [Localized("PERIOD_WEEK")]
        Weeek = 1,
        [Localized("PERIOD_MONTH")]
        Month = 2,
        [Localized("PERIOD_YEAR")]
        Year = 3,
        [Localized("PERIOD_UNLIMITED")]
        Unlimited = 5,
    }
    #endregion

    #region FILTERRESULTDIRECTION
    public enum FilterResultDirection
    {
        [Localized("FILTER_TOP")]
        Top,
        [Localized("FILTER_BOTTOM")]
        Bottom,
    }
    #endregion

    #region STARTUPMODULEACTIVITY
    /// <summary>
    /// Shared Module activity enumeration.
    /// </summary>
    public enum StartupModuleActivity
    {
        [Localized("EN_SMA_AUTHORIZNG_LICENSE")]
        AuthorizingLicense,
        [Localized("EN_SMA_INITIALIZING_DATA")]
        InitializingData,
        [Localized("EN_SMA_STARTING_TRAY_SERVICES")]
        StartingTrayServices,
        [Localized("EN_SMA_STARTING_NETWORK_SERVICES")]
        StartingNetworkServices,
        [Localized("EN_SMA_STARTING_UI")]
        StartingUi,
        [Localized("EN_SMA_STARTING_INTEGRATION")]
        StartingIntegration,
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
        RefreshingFileShares,
        [Localized("EN_SMA_STARTING_API_SERVER")]
        StartingAPIServer,
    }
    #endregion

    #region LICENSERESERVATIONTYPE
    /// <summary>
    /// License reservation types.
    /// </summary>
    [Flags]
    public enum LicenseReservationType
    {
        FirstAvailable = 0,
        OneFromEach = 1,
    }
    #endregion

    #region LICENSESTATUS
    /// <summary>
    /// License status enumeration.
    /// </summary>
    public enum LicenseStatus
    {
        /// <summary>
        /// License key is free for use.
        /// </summary>
        Unused,
        /// <summary>
        /// License key is reserved.
        /// </summary>
        Reserved,
    }
    #endregion

    #region IPVERSION
    public enum IPVersion
    {
        IPV4 = 0,
        IPV6 = 1,
    }
    #endregion

    #region DRIVERTYPE
    /// <summary>
    /// System driver type enumeration.
    /// </summary>
    [Flags()]
    public enum DriverType
    {
        /// <summary>
        /// Default value.
        /// </summary>
        None = 0,
        /// <summary>
        /// CallBack filter.
        /// </summary>
        CallBackFilter = 1,
        /// <summary>
        /// CallBack File System.
        /// </summary>
        CallBackFileSystem = 2,
        /// <summary>
        /// Raw Disk.
        /// </summary>
        RawDisk = 4,
        /// <summary>
        /// Keyboard Driver.
        /// </summary>
        KeyboardFilter = 8,
        /// <summary>
        /// Process filter driver.
        /// </summary>
        ProcessFilter = 16,
        /// <summary>
        /// All driver type value.
        /// </summary>
        All = DriverType.CallBackFileSystem | DriverType.CallBackFilter | DriverType.KeyboardFilter | DriverType.ProcessFilter | DriverType.RawDisk,
    }
    #endregion

    #region HOSTEVENTTYPE
    public enum HostEventType
    {
        /// <summary>
        /// Host was connected.
        /// </summary>
        Connected = 0,
        /// <summary>
        /// Host was initialized.
        /// </summary>
        Initialized = 1,
        /// <summary>
        /// Host was disconnected.
        /// </summary>
        Disconnected = 2,
        /// <summary>
        /// Host was added.
        /// </summary>
        Added = 3,
        /// <summary>
        /// Host was removed.
        /// </summary>
        Removed = 4,
        /// <summary>
        /// Host was updated.
        /// </summary>
        Updated = 5,
    }
    #endregion

    #region FREESPACEALLOCATIONS
    public enum FreeSpaceAllocations
    {
        Zero = 0,
        Five = 5,
        Ten = 10,
        FifTeen = 15,
        Twenty = 20,
        TwentyFive = 25,
        Thirty = 30,
    }
    #endregion

    #region CONFIGURATIONSECTION
    public enum ConfigurationSection
    {
        Unspecified = 0,
        [Localized("CFG_SECTION_GENERAL")]
        General,
        [Localized("CFG_SECTION_SERVER")]
        Server,
        [Localized("CFG_SECTION_CLIENT")]
        Client,
        [Localized("CFG_SECTION_PROFILES")]
        Profiles,
        [Localized("CFG_SECTION_OPERATORS")]
        Operators,
        [Localized("CFG_SECTION_SUBSCRIPTION")]
        Subscription,
        [Localized("CFG_SECTION_VARIABLES")]
        Variables,
        [Localized("CFG_SECTION_PLUGINS")]
        Plugins,
        [Localized("CFG_SECTION_WEB")]
        Web,
        [Localized("CFG_SECTION_NETWORK")]
        Network,
        [Localized("CFG_SECTION_DATABSE")]
        Database,
        [Localized("CFG_SECTION_FILE_SYSTEM")]
        FileSystem,
        [Localized("CFG_SECTION_SHELL")]
        Shell,
        [Localized("CFG_SECTION_TASKS")]
        Tasks,
        [Localized("CFG_SECTION_CLIENT_MISC")]
        ClientMisc,
        [Localized("CFG_SECTION_SERVER_MISC")]
        ServerMisc,
        [Localized("CFG_SECTION_HOST_GROUPS")]
        HostGroups,
        [Localized("CFG_SECTION_USER_GROUPS")]
        UserGroups,
        [Localized("CFG_SECTION_APP_GROUPS")]
        ApplicationGroups,
        [Localized("CFG_SECTION_SECURITY_PROFILES")]
        SecurityProfiles,
        [Localized("CFG_CLIENT_SETTINGS")]
        ClientSettings,
        [Localized("CFG_HOST_LAYOUT_GROUPS")]
        HostLayoutGroups,
        [Localized("CFG_SECTION_HOSTS")]
        Hosts,
        [Localized("CFG_SECTION_FINANCIAL")]
        Financial,
        [Localized("CFG_SECTION_MONETARY_UNITS")]
        MonetaryUnits,
        [Localized("CFG_SECTION_TAX")]
        Tax,
        [Localized("CFG_SECTION_PRODUCTS")]
        Products,
        [Localized("CFG_SECTION_PRODUCT_GROUPS")]
        ProductGroups,
        [Localized("CFG_SECTION_CURRENCIES")]
        Currencies,
        [Localized("CFG_SECTION_BILLING_PROFILES")]
        BillingProfiles,
        [Localized("CFG_SECTION_ATTRIBUTES")]
        Attributes,
        [Localized("CFG_SECTION_PRESETS")]
        Presets,
        [Localized("CFG_SECTION_PRIORITY")]
        Priority,
        [Localized("CFG_SECTION_REGISTERS")]
        Registers,
        [Localized("CFG_SECTION_ASSETS")]
        Assets,
        [Localized("CFG_SECTION_BUSINESS")]
        Business,
        [Localized("CFG_SECTION_WAITING_LINES")]
        WaitingLines,
    }
    #endregion

    #region DATABASETYPE
    public enum DatabaseType
    {
        [CanUserAssign(false)]
        MYSQL = 0,
        [CanUserAssign(true)]
        MSSQLEXPRESS = 2,
        [CanUserAssign(true)]
        MSSQL = 1,
        [CanUserAssign(false)]
        LOCALDB = 3,
        [CanUserAssign(false)]
        SQLITE = 4,
    }
    #endregion

    #region SQLSERVERAUTHENTICATION
    public enum SQLServerAuthentication
    {
        Unspecified = 0,
        [CanUserAssign(true)]
        Server = 1,
        [CanUserAssign(true)]
        Integrated = 2,
    }
    #endregion

    #region USERROLES
    [Flags()]
    public enum UserRoles
    {
        /// <summary>
        /// No role.
        /// </summary>
        [RoleAssignable(false)]
        None = 0,
        /// <summary>
        /// Simple user.
        /// </summary>
        [RoleAssignable(true)]
        User = 1,
        /// <summary>
        /// Guest user role.
        /// </summary>
        [RoleAssignable(false)]
        Guest = 2,
        /// <summary>
        /// Operator.
        /// </summary>
        [RoleAssignable(false)]
        Operator = 4
    }
    #endregion

    #region USERCHANGETYPE
    public enum UserChangeType
    {
        /// <summary>
        /// New user added.
        /// </summary>
        Added,
        /// <summary>
        /// Existing user removed.
        /// </summary>
        Removed,
        /// <summary>
        /// Existing user deleted.
        /// </summary>
        Deleted,
        /// <summary>
        /// User undeleted.
        /// </summary>
        Undelted,
        /// <summary>
        /// Existing user updated.
        /// </summary>
        Updated,
        /// <summary>
        /// Existing user password changed.
        /// </summary>
        Password,
        /// <summary>
        /// Exisitng user email changed.
        /// </summary>
        Email,
        /// <summary>
        /// Existing user username changed.
        /// </summary>
        UserName,
        /// <summary>
        /// Exisitng user group changed.
        /// </summary>
        UserGroup,
        /// <summary>
        /// Exisitng user role changed.
        /// </summary>
        Role,
        /// <summary>
        /// Existing user enabled changed.
        /// </summary>
        Enabled,
        /// <summary>
        /// Existing user picture changed.
        /// </summary>
        Picture,
        /// <summary>
        /// Allow negative balance changed.
        /// </summary>
        NegativBalanceEnabled,
        /// <summary>
        /// SmartCard UID Changed.
        /// </summary>
        SmartCardUID,
        /// <summary>
        /// Billing option.
        /// </summary>
        BillingOptions,
    }
    #endregion

    #region USERSESSIONACTIONSOURCE
    /// <summary>
    /// User session action source types.
    /// </summary>
    public enum UserSessionActionSource
    {
        /// <summary>
        /// Function called by user.
        /// </summary>
        User = 0,
        /// <summary>
        /// Function called by operator.
        /// </summary>
        Operator = 1,
        /// <summary>
        /// Function called on host connect.
        /// </summary>
        Connect = 2,
        /// <summary>
        /// Function called on host disconnect.
        /// </summary>
        Disconnect = 3,
        /// <summary>
        /// Function called by session mechanism.
        /// </summary>
        Session = 4,
    }
    #endregion

    #region HOSTPROPERTYTYPE
    /// <summary>
    /// Host property types.
    /// </summary>
    public enum HostPropertyType
    {
        IpAddress = 0,
        HostName = 1,
        DispatcherId = 2,
        IsConnected = 3,
        Module = 4,
        IsSecured = 5,
        Port = 6,
        OperatingSystem = 7,
        DataSent = 8,
        DataReceived = 9,
        IsLocked = 10,
        Id = 11,
        IsOutOfOrder = 12,
        IsMaintenanceMode = 13,
        HostGroupId = 14,
        Number = 15,
        MacAddress = 16,
        MaximumUsers = 17,
        Name = 18,
        IconId = 19,
        State = 20,
    }
    #endregion

    #region USERRESERVERESULT
    public enum UserReserveResult
    {
        Sucess = 0,
        Failed = 1,
        InvalidUserGroupId = 2,
        InUse = 3,
        MaxReservationsReached = 4,
        InvalidHost = 5,
        InvalidSlot = 6,
    }
    #endregion

    #region USERLOGOUTFLAGS
    [Flags()]
    public enum UserLogoutFlags
    {
        None = 0,
        SupressLogoutAction = 1,
    } 
    #endregion

    #region STORABLE ENUMERATIONS

    #region MODULEENUM
    [Flags()]
    public enum ModuleEnum
    {
        Unknown = 0,
        Manager = 1,
        Client = 2,
        Service = 4,
        Any = Manager | Client | Service,
    }
    #endregion

    #region MODULESCOPES
    /// <summary>
    /// Application module type scope enumeration.
    /// </summary>
    [Flags()]
    public enum ModuleScopes
    {
        None = 0,
        Client = 1,
        Server = 2,
        Manager = 4,
        Global = Client | Server | Manager,
    }
    #endregion    

    #region LOGCATEGORIES
    [Flags()]
    [Serializable()]
    public enum LogCategories
    {
        None = 0,
        Generic = 1,
        Network = 2,
        Database = 4,
        FileSystem = 8,
        Task = 16,
        Dispatcher = 32,
        Command = 64,
        Operation = 128,
        UserInterface = 256,
        Configuration = 512,
        Subscription = 1024,
        Trace = 2048,
        User = 4096,
        All = Generic | Network | Database | FileSystem | Task | Dispatcher | Command | Operation | UserInterface | Configuration | Subscription | Trace | User
    }
    #endregion

    #region EVENTTYPES
    /// <summary>
    /// Event Log types representation.
    /// </summary>
    [Flags()]
    [Serializable()]
    public enum EventTypes
    {
        None = 0,
        Information = 1,
        Warning = 2,
        Error = 4,
        Event = 8,
        All = Information | Warning | Error | Event
    }
    #endregion

    #region USERINFOTYPES
    /// <summary>
    /// User personal information types.
    /// </summary>
    [Flags()]
    public enum UserInfoTypes
    {
        /// <summary>
        /// No information.
        /// </summary>
        None = 0,
        /// <summary>
        /// First Name.
        /// </summary>
        FirstName = 1,
        /// <summary>
        /// Last Name.
        /// </summary>
        LastName = 2,
        /// <summary>
        /// Birth date.
        /// </summary>
        BirthDate = 4,
        /// <summary>
        /// Address.
        /// </summary>
        Address = 8,
        /// <summary>
        /// City.
        /// </summary>            
        City = 16,
        /// <summary>
        /// Postal Code. Zip for United States.
        /// </summary>
        PostCode = 32,
        /// <summary>
        /// State.
        /// </summary>
        State = 64,
        /// <summary>
        /// Country.
        /// </summary>
        Country = 128,
        /// <summary>
        /// Email Address.
        /// </summary>
        Email = 256,
        /// <summary>
        /// Landline Phone Number.
        /// </summary>
        Phone = 512,
        /// <summary>
        /// Mobile Phone Number.
        /// </summary>
        Mobile = 1024,
        /// <summary>
        /// Users sex.
        /// </summary>
        Sex = 2048,
        /// <summary>
        /// Users password.
        /// </summary>
        Password = 4096,
        /// <summary>
        /// User Name.
        /// </summary>
        UserName = 8192,
        /// <summary>
        /// User group.
        /// </summary>
        UserGroup = 16384,
        /// <summary>
        /// All user information.
        /// </summary>
        UserInformation = UserInfoTypes.Address |
            UserInfoTypes.City |
            UserInfoTypes.Email |
            UserInfoTypes.Email |
            UserInfoTypes.FirstName |
            UserInfoTypes.LastName |
            UserInfoTypes.Mobile |
            UserInfoTypes.Phone |
            UserInfoTypes.PostCode |
            UserInfoTypes.Sex,
    }
    #endregion

    #region SEX
    /// <summary>
    /// Sex enumeration.
    /// </summary>
    [Flags()]
    public enum Sex
    {
        Unspecified = 0,
        Male = 1,
        Female = 2,
    }
    #endregion

    #region USERSESSIONSTATE
    [Flags()]
    public enum SessionState
    {
        /// <summary>
        /// Session initialized.
        /// </summary>
        None = 0,
        /// <summary>
        /// Session is active.
        /// </summary>
        Active = 1,
        /// <summary>
        /// Session ended.
        /// </summary>
        Ended = 2,
        /// <summary>
        /// Session pending termination.
        /// </summary>
        Pending = 4 | Active,
        /// <summary>
        /// Session paused and pending activation.
        /// </summary>
        Paused = 8 | Active,
        /// <summary>
        /// Session is moving.
        /// </summary>
        Move = 16 | Active
    }
    #endregion

    #region GROUPOVERRIDES
    /// <summary>
    /// Computer group configuration overrides.
    /// </summary>
    [Flags()]
    public enum GroupOverrides
    {
        None = 0,
        Applications = 1,
        Security = 2,
        AgeRating = 4,
    }
    #endregion

    #region WEEKDAYS
    [Flags()]
    public enum WeekDays
    {
        None = 0,
        Sunday = 1,
        Monday = 2,
        Tuesday = 4,
        Wednesday = 8,
        Thursday = 16,
        Friday = 32,
        Saturday = 64,
    }
    #endregion

    #region BILLRATESTEPACTION
    public enum BillRateStepAction
    {
        [Localized("STEP_ACTION_CHARGE")]
        Charge = 0,
        [Localized("STEP_ACTION_LOOP_TO")]
        LoopTo = 1,
    }
    #endregion

    #region DEPLOYOPTIONTYPE
    [Flags()]
    public enum DeployOptionType : int
    {
        /// <summary>
        /// Default option.
        /// </summary>
        None = 0,
        /// <summary>
        /// Marks deployment as ignored from cleanup procedures.
        /// </summary>
        IgnoreCleanup = 1,
        /// <summary>
        /// Indicates that deployment should be done only on repair procedures.
        /// </summary>
        RepairOnly = 2,
        /// <summary>
        /// Indicates direct access to the deployment source.
        /// </summary>
        DirectAccess = 4,
        /// <summary>
        /// Indicates mirroring of destination directory.
        /// </summary>
        Mirror = 8,
        /// <summary>
        /// Indicates inclusion of sub directories.
        /// </summary>
        IncludeSubDirectories = 16,
    }
    #endregion

    #region PERSONALUSERFILETYPE
    /// <summary>
    /// Personal user file types.
    /// </summary>
    public enum PersonalUserFileType
    {
        /// <summary>
        /// File or directory.
        /// </summary>
        File = 0,
        /// <summary>
        /// Registry.
        /// </summary>
        Registry = 1,
    }

    #endregion

    #region PERSONALUSERFILEOPTIONTYPE
    [Flags()]
    public enum PersonalUserFileOptionType
    {
        None = 0,
        CleanUp = 1,
        Store = 2,
        IncludeSubDirectories = 4,
    }
    #endregion

    #region EXECUTABLEOPTIONTYPE
    [Flags()]
    public enum ExecutableOptionType
    {
        None = 0,
        AutoLaunch = 1,
        MonitorChildren = 2,
        MultiRun = 4,
        KillChildren = 8,
        CountAllInstances = 16,
        QuickLaunch =32,
        ShellExecute=64,
    }
    #endregion

    #region RUNMODES
    /// <summary>
    /// Run mode enumeration.
    /// </summary>
    public enum RunMode
    {
        [Localized("RUN_MODE_FULL_SCREEN")]
        FullScreen = 0,
        [Localized("RUN_MODE_MINIMIZED")]
        Minimized = 1,
        [Localized("RUN_MODE_MAXIMIZED")]
        Maximized = 2,
        [Localized("RUN_MODE_HIDDEN")]
        Hidden = 3,
        [Localized("RUN_MODE_NORMAL")]
        Normal = 4
    }
    #endregion

    #region APPLICATIONMODES
    /// <summary>
    /// Game application modes.
    /// </summary>
    [Flags()]
    public enum ApplicationModes
    {
        /// <summary>
        /// None.
        /// </summary>
        DefaultMode = 0,
        /// <summary>
        /// Single player.
        /// </summary>
        SinglePlayer = 1,
        /// <summary>
        /// Online multiplayer.
        /// </summary>
        [IsGameModeAttibute()]
        Online = 2,
        /// <summary>
        /// Lan Multiplayer.
        /// </summary>
        [IsGameModeAttibute()]
        Multiplayer = 4,
        /// <summary>
        /// Settings.
        /// </summary>
        Settings = 8,
        /// <summary>
        /// Utility.
        /// </summary>
        Utility = 16,
        /// <summary>
        /// Game.
        /// </summary>
        Game = 32,
        /// <summary>
        /// Application.
        /// </summary>
        Application = 64,
        /// <summary>
        /// Free to play.
        /// </summary>
        FreeToPlay = 128,
        /// <summary>
        /// Requires subscription.
        /// </summary>
        RequiresSubscription = 256,
        /// <summary>
        /// Free trial.
        /// </summary>
        FreeTrial = 512,
        /// <summary>
        /// Split screen.
        /// </summary>
        [IsGameModeAttibute()]
        SplitScreenMultiPlayer = 1024,
        /// <summary>
        /// Lan co-op.
        /// </summary>
        [IsGameModeAttibute()]
        CoOpLan = 2048,
        /// <summary>
        /// Online co-op.
        /// </summary>
        [IsGameModeAttibute()]
        CoOpOnline = 4096,
        /// <summary>
        /// One time purchase.
        /// </summary>
        OneTimePurchase = 8192,
    }
    #endregion

    #region APPOPTIONTYPE
    [Flags()]
    public enum AppOptionType
    {
        None = 0,
        HaltOnError = 1,
    }
    #endregion

    #region USERGROUPOPTIONTYPE
    [Flags()]
    public enum UserGroupOptionType
    {
        None = 0,
        EnablePersonalStorage = 1,
        HideLogoutButton = 2,
        DisallowManualLogin = 4,
        GuestUse = 8,
        GuestUseOnly = 16,
        /// <summary>
        /// Enables or disables personal files.
        /// </summary>
        EnablePersonalFiles = 32,
    }
    #endregion

    #region CREDITLIMITOPTIONTYPE
    [Flags()]
    public enum CreditLimitOptionType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,

        /// <summary>
        /// Enable per user credit limit.
        /// </summary>
        EnablePerUserCreditLimit = 2,
    }
    #endregion

    #region TIMEPOINTAWARDOPTIONTYPE
    public enum TimePointAwardOptionType
    {
        None = 0,
        Time = 1,
        Money = 2
    }
    #endregion

    #region HOSTSTATE
    [Flags()]
    public enum HostState
    {
        /// <summary>
        /// Default state.
        /// </summary>
        InOrder = 0,
        /// <summary>
        /// Host is out of order.
        /// </summary>
        OutOfOrder = 1,
        /// <summary>
        /// Host is locked.
        /// </summary>
        IsLocked = 2,
    }
    #endregion

    #region HOSTGROUPOPTIONTYPE
    [Flags()]
    public enum HostGroupOptionType
    {
        None = 0,
    }
    #endregion

    #region PERIODOPTIONTYPE
    [Flags()]
    public enum PeriodOptionType
    {
        None = 0,
        HasDayTimeRange = 1,
        HasDateRange = 2,
    }
    #endregion

    #region STOCKOPTIONTYPE
    [Flags()]
    public enum StockOptionType
    {
        None = 0,
        EnableStock = 1,
        DisallowSaleIfOutOfStock = 2,
        Alert = 4,
        TargetDifferentProduct = 8,
    }
    #endregion

    #region BUNDLESTOCKOPTIONTYPE
    [Flags()]
    public enum BundleStockOptionType
    {
        /// <summary>
        /// By default bundled products stock will be counted
        /// </summary>
        None = 0,
        /// <summary>
        /// Bundle has its own stock control.
        /// </summary>
        SelfStockCount = 1
    }
    #endregion

    #region PRODUCTBUNDLEOPTIONTYPE
    /// <summary>
    /// Defines how product behaves in a bundle.
    /// </summary>
    public enum ProductBundleOptionType
    {
        None,
    }
    #endregion

    #region ORDEROPTIONTYPE
    [Flags()]
    public enum OrderOptionType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Client order allowed.
        /// </summary>
        AllowOrder = 1,
        /// <summary>
        /// Disallow ability of order for non users.
        /// </summary>
        RestrictNonCustomers = 2,
        /// <summary>
        /// Restricts product sale.
        /// </summary>
        RestrictSale = 4
    }
    #endregion

    #region PURCHASEOPTIONTYPE
    /// <summary>
    /// Points money option type.
    /// </summary>
    public enum PurchaseOptionType
    {
        [Localized("AND")]
        And = 0,
        [Localized("OR")]
        Or = 1
    }
    #endregion

    #region PRODUCTSORTOPTIONTYPE
    public enum ProductSortOptionType
    {
        [Localized("MANUAL")]
        Default = 0,
        [Localized("NAME")]
        Name = 1,
        [Localized("CREATION_TIME")]
        Created = 2
    }
    #endregion

    #region BILLRATEOPTIONTYPE
    public enum BillRateOptionType
    {
        None = 0,
        IsStepBased = 1,
    }
    #endregion

    #region PRODUCTTIMEEXPIRATIONOPTIONTYPE
    [Flags()]
    public enum ProductTimeExpirationOptionType
    {
        None = 0,
        ExpiresAtLogout = 1,
        [Obsolete()]
        ExpiresAtDate = 2,
        ExpireAfterTime = 4,
        ExpireAtDayTime =8,
    }
    #endregion

    #region PRODUCTTIMEUSAGEOPTIONTYPE
    [Flags()]
    public enum ProductTimeUsageOptionType
    {
        None = 0,
        HasMaximumUsage = 1,
        HasMaximumDailyUsage = 2,
    }
    #endregion

    #region EXPIREFROMOPTIONTYPE
    public enum ExpireFromOptionType
    {
        [Localized("EXPIRE_FROM_PURCHASE")]
        Purchase = 0,
        [Localized("EXPIRE_FROM_USE")]
        Use = 1
    }
    #endregion

    #region EXPIREAFTERTYPE
    public enum ExpireAfterType
    {
        [Localized("DAY_PLURAL")]
        Day=0,
        [Localized("HOUR_PLURAL")]
        Hour=1,
        [Localized("MINUTE_PLURAL")]
        Minute=2,
    } 
    #endregion

    #region UNITOFMEASUREOPTIONTYPE
    [Flags()]
    public enum UnitOfMeasureOptionType
    {
        None = 0,
    }
    #endregion

    #region DISCOUNTAMOUNTTYPE
    public enum DiscountAmountType
    {
        /// <summary>
        /// Discount fixed amount.
        /// </summary>
        Fixed = 0,
        /// <summary>
        /// Discount percentage.
        /// </summary>
        Percentage = 1,
        /// <summary>
        /// Discount bonus.
        /// </summary>
        Bonus = 2
    }
    #endregion

    #region DISCOUNTINPUTTRIGGER
    /// <summary>
    /// Type of discount input trigger.
    /// </summary>
    public enum DiscountInputTrigger
    {
        /// <summary>
        /// None.
        /// </summary>
        Unspecified = 0,
        /// <summary>
        /// Money.
        /// </summary>
        Money = 1,
        /// <summary>
        /// Prodcut count.
        /// </summary>
        Count = 2,
    }
    #endregion

    #region DISCOUNTAMOUNTTRIGGER
    /// <summary>
    /// Type of amount triggers.
    /// </summary>
    public enum DiscountAmountTrigger
    {
        /// <summary>
        /// Discount triggered by amount of specific item.
        /// </summary>
        Item = 0,
        /// <summary>
        /// Discount triggered by total amount of order.
        /// </summary>
        Order = 1,
    }
    #endregion

    #region DISCOUNTTARGETTYPE
    /// <summary>
    /// Discount target type.
    /// </summary>
    public enum DiscountTargetType
    {
        Unspecified = 0,
        ProductGroups = 1,
        Product = 2,
    }
    #endregion

    #region DISCOUNTCALCTRIGGER
    /// <summary>
    /// Defines how the discount creteria is calculated.
    /// </summary>
    public enum DiscountCalcTrigger
    {
        /// <summary>
        /// All dsicounted products must be of same.
        /// </summary>
        Product = 0,
        /// <summary>
        /// All discounted products must be from same group.
        /// </summary>
        ProductGroup = 1,
        /// <summary>
        /// Irrelavant of group or product type.
        /// </summary>
        Sum = 2,
        /// <summary>
        /// Total products bught independent of prodcuts targeted by discount.
        /// </summary>
        OrderSum = 3,
    }
    #endregion

    #region PAYMENTMETHODOPTIONTYPE
    [Flags()]
    public enum PaymentMethodOptionType
    {
        None = 0
    }
    #endregion

    #region PAYMENTMETHODTYPE
    public enum PaymentMethodType
    {
        Undefined = 0,
        /// <summary>
        /// Cash payment.
        /// </summary>
        [Localized("PAYMENT_METHOD_CASH")]
        Cash = -1,

        /// <summary>
        /// Credit card payment.
        /// </summary>
        [Localized("PAYMENT_METHOD_CREDIT_CARD")]
        CreditCard = -2,

        /// <summary>
        /// Deposit balance payment.
        /// </summary>
        [Localized("PAYMENT_METHOD_DEPOSIT")]
        Deposit = -3,

        /// <summary>
        /// Deposit points payment.
        /// </summary>
        [Localized("PAYMENT_METHOD_POINTS")]
        Points = -4,
    }
    #endregion

    #region ROUNDOPTIONTYPE
    public enum RoundOptionType
    {
        None = 0,
    }
    #endregion

    #region DEPOSITTRANSACTIONTYPE
    public enum DepositTransactionType
    {
        /// <summary>
        /// Deposit to an account.
        /// </summary>
        [Localized("DEPOSIT_TRANSACTION_DEPOSIT")]
        Deposit = 0,
        /// <summary>
        /// Withdraw from account.
        /// </summary>
        [Localized("DEPOSIT_TRANSACTION_WITHDRAW")]
        Withdraw = 1,
        /// <summary>
        /// Account charge.
        /// </summary>
        [Localized("DEPOSIT_TRANSACTION_CHARGE")]
        Charge = 2,
        /// <summary>
        /// Credit an amount to account.
        /// </summary>
        [Localized("DEPOSIT_TRANSACTION_CREDIT")]
        Credit = 3
    }
    #endregion

    #region LOYALITYPOINTSTRANSACTIONTYPE
    public enum LoyalityPointsTransactionType
    {
        /// <summary>
        /// Points award.
        /// </summary>
        Award = 0,
        /// <summary>
        /// Points redeem.
        /// </summary>
        Redeem = 1,
        /// <summary>
        /// Points set.
        /// </summary>
        Set = 2,
        /// <summary>
        /// Points credited.
        /// </summary>
        Credit=3,
    }
    #endregion

    #region STOCKTRANSACTIONTYPE
    public enum StockTransactionType
    {
        [Localized("STOCK_TRANSACTION_ADD")]
        Add = 0,
        [Localized("STOCK_TRANSACTION_REMOVE")]
        Remove = 1,
        [Localized("STOCK_TRANSACTION_SALE")]
        Sale = 2,
        [Localized("STOCK_TRANSACTION_SET")]
        Set = 3,
        [Localized("STOCK_TRANSACTION_RETURN")]
        Return = 4,
    }
    #endregion

    #region ORDERSTATUS
    public enum OrderStatus
    {
        [Localized("ORDER_STATUS_ON_HOLD")]
        OnHold = 0,
        [Localized("ORDER_STATUS_INVOICED")]
        Invoiced = 1,
        [Localized("ORDER_STATUS_CANCELED")]
        Canceled = 2
    }
    #endregion

    #region INVOICESTATUS
    public enum InvoiceStatus
    {
        [Localized("INVOICE_STATUS_UNPAID")]
        Unpaid = 0,
        [Localized("INVOICE_STATUS_PARTIALLY_PAID")]
        PartialyPaid = 1,
        [Localized("INVOICE_STATUS_PAID")]
        Paid = 2,
    }
    #endregion

    #region SCRIPTTYPES
    /// <summary>
    /// Task Script enumeration type.
    /// </summary>
    public enum ScriptTypes
    {
        [CanUserAssignAttribute(true)]
        [Description("Batch")]
        Batch,
        [CanUserAssignAttribute(true)]
        [Description("Visual Basic")]
        VbScript,
        [CanUserAssignAttribute(true)]
        [Description("Autoit")]
        AutoItScript,
        [CanUserAssignAttribute(true)]
        [Description("Registry")]
        RegistryScript,
    }
    #endregion

    #region TASKPROCESSOPTIONTYPE
    [Flags()]
    public enum TaskProcessOptionType
    {
        None = 0,
        Wait = 1,
        NoWindow = 2,
    }
    #endregion

    #region TASKJUNCTIONOPTIONTYPE
    [Flags()]
    public enum TaskJunctionOptionType
    {
        None = 0,
        DeleteDestination = 1,
    }
    #endregion

    #region TASKNOTIFICATIONOPTIONTYPE
    [Flags()]
    public enum TaskNotificationOptionType
    {
        None = 0,
        Wait = 1,
    }
    #endregion

    #region PERSONALFILEACTIVATIONTYPE
    public enum PersonalFileActivationType
    {
        [Localized("PERSONAL_FILE_ACTIVATION_TYPE_LAUNCH")]
        Launch = 0,
        [Localized("PERSONAL_FILE_ACTIVATION_TYPE_LOGIN")]
        Login = 1,
    }
    #endregion

    #region PERSONALFILEDEACTIVATIONTYPE
    public enum PersonalFileDeactivationType
    {
        [Localized("LOGOUT")]
        Logout = 0
    }
    #endregion

    #region CLIENTTASKACTIVATIONTYPE
    [Flags()]
    public enum ClientTaskActivationType
    {
        [Obsolete()]
        [Description("Disabled")]
        Disabled = 0,
        [Description("Startup")]
        Startup = 1,
        [Description("Shutdown")]
        Shutdown = 2,
        [Description("Login")]
        Login = 4,
        [Description("Logout")]
        Logout = 8,
    }
    #endregion

    #region EXECUTABLETASKACTIVATIONTYPE
    [Flags()]
    public enum ExecutableTaskActivationType
    {
        [Description("Pre Launch")]
        PreLaunch = 16,
        [Description("Pre Deploy")]
        PreDeploy = 32,
        [Description("Post Termination")]
        PostTermination = 64,
        [Description("Pre License Management")]
        PreLicenseManagement = 128,
    }
    #endregion

    #region LOGICALOPERATOR
    public enum LogicalOperator
    {
        [Localized("AND")]
        And,
        [Localized("OR")]
        Or,
    }
    #endregion

    #region NOTESEVIRITY
    public enum NoteSevirity
    {
        [Localized("NOTE_SEVIRITY_GREEN")]
        Green = 0,
        [Localized("NOTE_SEVIRITY_YELLOW")]
        Yellow = 1,
        [Localized("NOTE_SEVIRITY_RED")]
        Red = 2,
    }
    #endregion

    #region NOTEOPTIONS
    /// <summary>
    /// Note options.
    /// </summary>
    [Flags()]
    public enum NoteOptions
    {
        None = 0,
    }
    #endregion

    #region USERNOTEOPTIONS
    /// <summary>
    /// User note options.
    /// </summary>
    [Flags()]
    public enum UserNoteOptions
    {
        None = 0,
    }
    #endregion

    #region SHIFTOPTION
    public enum ShiftOption
    {
        [Localized("SHIFT_OPTION_DISABLED")]
        Disabled = 0,
        [Localized("SHIFT_OPTION_OPTIONAL")]
        Optional = 1,
        [Localized("SHIFT_OPTION_MANDATORY")]
        Mandatory = 2,
    }
    #endregion

    #region REGISTERTRANSACTIONTYPE
    /// <summary>
    /// Register transaction type.
    /// </summary>
    public enum RegisterTransactionType
    {
        /// <summary>
        /// Pay in.
        /// </summary>
        PayIn,
        /// <summary>
        /// Pay out.
        /// </summary>
        PayOut,
        /// <summary>
        /// Drop.
        /// </summary>
        Drop,
        /// <summary>
        /// Inventory purchase.
        /// </summary>
        InventoryPurchase,
    }
    #endregion

    #region REGISTEROPTIONS
    /// <summary>
    /// Register options.
    /// </summary>
    public enum RegisterOptions
    {
        /// <summary>
        /// None option.
        /// </summary>
        None,
    }
    #endregion

    #region ORDERLINEPAYTYPE
    /// <summary>
    /// Order line payment type.
    /// </summary>
    public enum OrderLinePayType
    {
        Mixed = 2,
        Points = 1,
        Cash = 0,
    }
    #endregion

    #region REFUNDSTATUS
    public enum RefundStatus
    {
        [Localized("REFUND_STATUS_NONE")]
        None,
        [Localized("REFUND_STATUS_PARTIAL")]
        Partial,
        [Localized("REFUND_STATUS_FULL")]
        Full,
    }
    #endregion

    #region BILLINGOPTION
    public enum BillingOption
    {
        None = 0,
        DisableTimeOffer = 1,
        DisableFixedTime = 2,
        DisableDeposit = 4,
    }
    #endregion

    #region WAITINGLINETIMEOUTOPTION
    /// <summary>
    /// Waiting line timeout options.
    /// </summary>
    [Flags()]
    public enum WaitingLineTimeoutOption
    {
        [Localized("WAITING_LINE_TIMEOUT_OPTION_NONE")]
        None = 0,
        [Localized("WAITING_LINE_TIMEOUT_OPTION_REMOVE")]
        Remove = 1,
        [Localized("WAITING_LINE_TIMEOUT_OPTION_NEXT_IN_LINE")]
        NextInLine = 2,
    }
    #endregion

    #region WAITINGLINESTATE
    /// <summary>
    /// Waiting line states.
    /// </summary>
    public enum WaitingLineState
    {
        [Localized("WAITING_LINE_SATE_ACTIVE")]
        Active = 0,
        [Localized("WAITING_LINE_SATE_PROCESSED")]
        Processed = 2,
        [Localized("WAITING_LINE_SATE_CANCEL")]
        Cancel = 1,
    } 
    #endregion

    #endregion
}
