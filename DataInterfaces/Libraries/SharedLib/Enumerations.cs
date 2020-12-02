using System;
using System.ComponentModel;
using Localization;

namespace SharedLib
{
    #region OBSOLETE

    #region CONTAINERITEMEVENTTYPE
    /// <summary>
    /// Container event types.
    /// </summary>
    [Serializable()]
    [Obsolete()]
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

    #endregion

    #region ACTIVATIONTYPE
    /// <summary>
    /// Common activation deactivation types.
    /// </summary>
    [Flags()]
    public enum ActivationType
    {
        /// <summary>
        /// Disabled.
        /// </summary>
        [Description("Disabled")]
        Disabled = 0,
        /// <summary>
        /// Startup.
        /// </summary>
        [Description("Startup")]
        Startup = 1,
        /// <summary>
        /// Shut down.
        /// </summary>
        [Description("Shutdown")]
        Shutdown = 2,
        /// <summary>
        /// Login.
        /// </summary>
        [Description("Login")]
        Login = 4,
        /// <summary>
        /// Logout.
        /// </summary>
        [Description("Logout")]
        Logout = 8,
        /// <summary>
        /// Pre launch.
        /// </summary>
        [Description("Pre Launch")]
        PreLaunch = 16,
        /// <summary>
        /// Pre deploy.
        /// </summary>
        [Description("Pre Deploy")]
        PreDeploy = 32,
        /// <summary>
        /// Post termination.
        /// </summary>
        [Description("Post Termination")]
        PostTermination = 64,
        /// <summary>
        /// Pre license management.
        /// </summary>
        [Description("Pre License Management")]
        PreLicenseManagement = 128,
    }
    #endregion

    #region TASKTYPE
    /// <summary>
    /// Task types.
    /// </summary>
    [Serializable()]
    public enum TaskType
    {
        /// <summary>
        /// Process.
        /// </summary>
        [CanUserAssign(true)]
        [Localized("TASK_PROCESS")]
        [Description("Process")]
        Process,
        /// <summary>
        /// Script.
        /// </summary>
        [CanUserAssign(true)]
        [Localized("TASK_SCRIPT")]
        [Description("Script")]
        Script,
        /// <summary>
        /// File system.
        /// </summary>
        [Obsolete()]
        [CanUserAssign(false)]
        [Description("File System")]
        FileSystem,
        /// <summary>
        /// Chain.
        /// </summary>
        [Obsolete()]
        [CanUserAssign(false)]
        [Description("Task Chain")]
        Chain,
        /// <summary>
        /// Notification.
        /// </summary>
        [CanUserAssign(true)]
        [Localized("TASK_NOTIFICATION")]
        [Description("Notification")]
        Notification,
        /// <summary>
        /// Junction.
        /// </summary>
        [CanUserAssign(true)]
        [Localized("TASK_JUNCTION")]
        [Description("Junction")]
        Junction,
        /// <summary>
        /// All types.
        /// </summary>
        [CanUserAssign(false)]
        [Localized("ALL")]
        [Description("All Types")]
        AllTypes = 65535,
    }
    #endregion

    #region QUEUESTATUS
    /// <summary>
    /// Generic queue status codes.
    /// </summary>
    public enum QueueStatus
    {
        /// <summary>
        /// Queued.
        /// </summary>
        Queued = 0,
        /// <summary>
        /// Active.
        /// </summary>
        Active = 1,
        /// <summary>
        /// Paused.
        /// </summary>
        Paused = 2,
        /// <summary>
        /// Canceled.
        /// </summary>
        Canceled = 3,
        /// <summary>
        /// Failed.
        /// </summary>
        Failed = 4,
        /// <summary>
        /// Completed.
        /// </summary>
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
        /// <summary>
        /// Lock state.
        /// </summary>
        LockState,
        /// <summary>
        /// Id change.
        /// </summary>
        IdChange,
        /// <summary>
        /// Security state.
        /// </summary>
        SecurityState,
        /// <summary>
        /// Out of order state.
        /// </summary>
        OutOfOrderState,
        /// <summary>
        /// Maintenance.
        /// </summary>
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

    #region LOGOUTACTION
    /// <summary>
    /// Client logout action types.
    /// </summary>
    public enum LogoutAction
    {
        /// <summary>
        /// No action.
        /// </summary>
        [Localized("LOGOUT_ACTION_NONE")]
        NoAction = -1,
        /// <summary>
        /// Reboot.
        /// </summary>
        [Localized("LOGOUT_ACTION_REBOOT")]
        Reboot = 0,
        /// <summary>
        /// Close programs.
        /// </summary>
        [Localized("LOGOUT_ACTION_CLOSE_PROGRAMS")]
        ClosePrograms = 1,
        /// <summary>
        /// Turn off.
        /// </summary>
        [Localized("LOGOUT_ACTION_TURN_OFF")]
        TurnOff = 2,
        /// <summary>
        /// Log off.
        /// </summary>
        [Localized("LOGOUT_ACTION_LOG_OFF")]
        LogOff = 3,
        /// <summary>
        /// Stand by.
        /// </summary>
        [Localized("LOGOUT_ACTION_STAND_BY")]
        StandBy = 4,
        /// <summary>
        /// Maintenance.
        /// </summary>
        AdminMode = 5,
    }
    #endregion

    #region NOTIFICATIONBUTTONS
    /// <summary>
    /// Notfication buttons.
    /// </summary>
    public enum NotificationButtons
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Ok.
        /// </summary>
        Ok = 1,
        /// <summary>
        /// Yes.
        /// </summary>
        Yes = 2,
        /// <summary>
        /// No.
        /// </summary>
        No = 3,
        /// <summary>
        /// Cancel.
        /// </summary>
        Cancel = 4,
    }
    #endregion

    #region TIMELEFTWARNINGTYPE
    /// <summary>
    /// Time left warning types.
    /// </summary>
    [Flags()]
    public enum TimeLeftWarningType
    {
        /// <summary>
        /// None.
        /// </summary>
        [Localized("TIME_LEFT_WARNING_TYPE_NONE")]
        None = 0,
        /// <summary>
        /// Visual.
        /// </summary>
        [Localized("TIME_LEFT_WARNING_TYPE_VISUAL")]
        Visual = 1,
        /// <summary>
        /// Audible.
        /// </summary>
        [Localized("TIME_LEFT_WARNING_TYPE_AUDIBLE")]
        Audible = 2,
        /// <summary>
        /// Minimize active windows.
        /// </summary>
        [Localized("TIME_LEFT_WARNING_TYPE_MINIMIZE_WINDOWS")]
        MinimizeWindows = 4,
        /// <summary>
        /// All.
        /// </summary>
        All = Visual | Audible | TimeLeftWarningType.MinimizeWindows
    }
    #endregion

    #region AGERATINGTYPE
    /// <summary>
    /// Age rating types.
    /// </summary>
    public enum AgeRatingType
    {
        /// <summary>
        /// None.
        /// </summary>
        [Description("None")]
        None = 0,
        /// <summary>
        /// Manual.
        /// </summary>
        [Description("Manual")]
        Manual = 1,
        /// <summary>
        /// ESRB.
        /// </summary>
        [Description("ESRB")]
        ESRB = 2,
        /// <summary>
        /// PEGI.
        /// </summary>
        [Description("PEGI")]
        PEGI = 3,
    }
    #endregion    

    #region PEGI
    /// <summary>
    /// PEGI types.
    /// </summary>
    public enum PEGI
    {
        /// <summary>
        /// Three (3)
        /// </summary>
        [Description("Three (3)")]
        [AgeRating(3)]
        Three = -1,
        /// <summary>
        /// Four (4)
        /// </summary>
        [AgeRating(4)]
        [Description("Four (4)")]
        Four = -2,
        /// <summary>
        /// "Six (6)
        /// </summary>
        [AgeRating(6)]
        [Description("Six (6)")]
        Six = -3,
        /// <summary>
        /// Seven (7)
        /// </summary>
        [AgeRating(7)]
        [Description("Seven (7)")]
        Seven = -4,
        /// <summary>
        /// Twelve (12)
        /// </summary>
        [AgeRating(12)]
        [Description("Twelve (12)")]
        Twelve = -5,
        /// <summary>
        /// Sixteen (16)
        /// </summary>
        [Description("Sixteen (16)")]
        [AgeRating(16)]
        Sixteen = -6,
        /// <summary>
        /// Eighteen (18)
        /// </summary>
        [Description("Eighteen (18)")]
        [AgeRating(18)]
        Eighteen = -7,
    }
    #endregion

    #region ESRB
    /// <summary>
    /// ESRB types.
    /// </summary>
    public enum ESRB
    {
        /// <summary>
        /// Early Childhood (EC)
        /// </summary>
        [Description("Early Childhood (EC)")]
        [AgeRating(3)]
        EarlyChildHood = -21,
        /// <summary>
        /// Everyone (E)
        /// </summary>
        [Description("Everyone (E)")]
        [AgeRating(6)]
        EveryOne = -22,
        /// <summary>
        /// Everyone 10+ (E10+)
        /// </summary>
        [Description("Everyone 10+ (E10+)")]
        [AgeRating(10)]
        EveryOneTenPlus = -23,
        /// <summary>
        /// Teen (T)
        /// </summary>
        [Description("Teen (T)")]
        [AgeRating(13)]
        Teen = -24,
        /// <summary>
        /// Mature (M)
        /// </summary>
        [Description("Mature (M)")]
        [AgeRating(17)]
        Matrue = -25,
        /// <summary>
        /// Adults Only (AO)
        /// </summary>
        [Description("Adults Only (AO)")]
        [AgeRating(18)]
        AdaultsOnly = -26,
        /// <summary>
        /// Rating Pending (RP)
        /// </summary>
        [Description("Rating Pending (RP)")]
        [AgeRating(0)]
        RatingPending = -27,
        /// <summary>
        /// Kids to Adults (K-A)
        /// </summary>
        [Description("Kids to Adults (K-A)")]
        [AgeRating(6)]
        KidsToAdaults = -28,
    }
    #endregion

    #region DURATIONRANGE
    /// <summary>
    /// Duration ranges.
    /// </summary>
    public enum DurationRange
    {
        /// <summary>
        /// Today.
        /// </summary>
        [Localized("PERIOD_TODAY")]
        Today = 0,
        /// <summary>
        /// Week.
        /// </summary>
        [Localized("PERIOD_WEEK")]
        Weeek = 1,
        /// <summary>
        /// Month.
        /// </summary>
        [Localized("PERIOD_MONTH")]
        Month = 2,
        /// <summary>
        /// Year.
        /// </summary>
        [Localized("PERIOD_YEAR")]
        Year = 3,
        /// <summary>
        /// Unlimited.
        /// </summary>
        [Localized("PERIOD_UNLIMITED")]
        Unlimited = 5,
    }
    #endregion

    #region FILTERRESULTDIRECTION
    /// <summary>
    /// Filter result direction.
    /// </summary>
    public enum FilterResultDirection
    {
        /// <summary>
        /// Top.
        /// </summary>
        [Localized("FILTER_TOP")]
        Top,
        /// <summary>
        /// Bottom.
        /// </summary>
        [Localized("FILTER_BOTTOM")]
        Bottom,
    }
    #endregion    

    #region LICENSERESERVATIONTYPE
    /// <summary>
    /// License reservation types.
    /// </summary>
    [Flags]
    public enum LicenseReservationType
    {
        /// <summary>
        /// First available.
        /// </summary>
        FirstAvailable = 0,
        /// <summary>
        /// One from each.
        /// </summary>
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
    /// <summary>
    /// IP Versions.
    /// </summary>
    public enum IPVersion
    {
        /// <summary>
        /// V4.
        /// </summary>
        IPV4 = 0,
        /// <summary>
        /// V6.
        /// </summary>
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
    /// <summary>
    /// Host event types.
    /// </summary>
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

        /// <summary>
        /// Deleted.
        /// </summary>
        Deleted = 6,

        /// <summary>
        /// Undeleted.
        /// </summary>
        Undeleted = 7,
    }
    #endregion

    #region FREESPACEALLOCATIONS
    /// <summary>
    /// Free space allocations.
    /// </summary>
    public enum FreeSpaceAllocations
    {
        /// <summary>
        /// Zero.
        /// </summary>
        Zero = 0,
        /// <summary>
        /// Five percent.
        /// </summary>
        Five = 5,
        /// <summary>
        /// Ten percent.
        /// </summary>
        Ten = 10,
        /// <summary>
        /// Fifteen percent.
        /// </summary>
        FifTeen = 15,
        /// <summary>
        /// Twenty percent.
        /// </summary>
        Twenty = 20,
        /// <summary>
        /// Twenty five percent.
        /// </summary>
        TwentyFive = 25,
        /// <summary>
        /// Thirty percent.
        /// </summary>
        Thirty = 30,
    }
    #endregion

    #region CONFIGURATIONSECTION
    /// <summary>
    /// Configuration sections.
    /// </summary>
    public enum ConfigurationSection
    {
        /// <summary>
        /// Unspecified.
        /// </summary>
        Unspecified = 0,
        /// <summary>
        /// General.
        /// </summary>
        [Localized("CFG_SECTION_GENERAL")]
        General,
        /// <summary>
        /// Server.
        /// </summary>
        [Localized("CFG_SECTION_SERVER")]
        Server,
        /// <summary>
        /// Client.
        /// </summary>
        [Localized("CFG_SECTION_CLIENT")]
        Client,
        /// <summary>
        /// Profiles.
        /// </summary>
        [Localized("CFG_SECTION_PROFILES")]
        Profiles,
        /// <summary>
        /// Operators.
        /// </summary>
        [Localized("CFG_SECTION_OPERATORS")]
        Operators,
        /// <summary>
        /// Subscription.
        /// </summary>
        [Localized("CFG_SECTION_SUBSCRIPTION")]
        Subscription,
        /// <summary>
        /// Variables.
        /// </summary>
        [Localized("CFG_SECTION_VARIABLES")]
        Variables,
        /// <summary>
        /// Plugins.
        /// </summary>
        [Localized("CFG_SECTION_PLUGINS")]
        Plugins,
        /// <summary>
        /// Web.
        /// </summary>
        [Localized("CFG_SECTION_WEB")]
        Web,
        /// <summary>
        /// Network.
        /// </summary>
        [Localized("CFG_SECTION_NETWORK")]
        Network,
        /// <summary>
        /// Database.
        /// </summary>
        [Localized("CFG_SECTION_DATABSE")]
        Database,
        /// <summary>
        /// File system.
        /// </summary>
        [Localized("CFG_SECTION_FILE_SYSTEM")]
        FileSystem,
        /// <summary>
        /// Shell.
        /// </summary>
        [Localized("CFG_SECTION_SHELL")]
        Shell,
        /// <summary>
        /// Tasks.
        /// </summary>
        [Localized("CFG_SECTION_TASKS")]
        Tasks,
        /// <summary>
        /// Client misc.
        /// </summary>
        [Localized("CFG_SECTION_CLIENT_MISC")]
        ClientMisc,
        /// <summary>
        /// Server misc.
        /// </summary>
        [Localized("CFG_SECTION_SERVER_MISC")]
        ServerMisc,
        /// <summary>
        /// Host groups.
        /// </summary>
        [Localized("CFG_SECTION_HOST_GROUPS")]
        HostGroups,
        /// <summary>
        /// User groups.
        /// </summary>
        [Localized("CFG_SECTION_USER_GROUPS")]
        UserGroups,
        /// <summary>
        /// Application groups.
        /// </summary>
        [Localized("CFG_SECTION_APP_GROUPS")]
        ApplicationGroups,
        /// <summary>
        /// Security profiles.
        /// </summary>
        [Localized("CFG_SECTION_SECURITY_PROFILES")]
        SecurityProfiles,
        /// <summary>
        /// Client settings.
        /// </summary>
        [Localized("CFG_CLIENT_SETTINGS")]
        ClientSettings,
        /// <summary>
        /// Host layout groups.
        /// </summary>
        [Localized("CFG_HOST_LAYOUT_GROUPS")]
        HostLayoutGroups,
        /// <summary>
        /// Hosts.
        /// </summary>
        [Localized("CFG_SECTION_HOSTS")]
        Hosts,
        /// <summary>
        /// Financial.
        /// </summary>
        [Localized("CFG_SECTION_FINANCIAL")]
        Financial,
        /// <summary>
        /// Monetary units.
        /// </summary>
        [Localized("CFG_SECTION_MONETARY_UNITS")]
        MonetaryUnits,
        /// <summary>
        /// Tax.
        /// </summary>
        [Localized("CFG_SECTION_TAX")]
        Tax,
        /// <summary>
        /// Products.
        /// </summary>
        [Localized("CFG_SECTION_PRODUCTS")]
        Products,
        /// <summary>
        /// Product groups.
        /// </summary>
        [Localized("CFG_SECTION_PRODUCT_GROUPS")]
        ProductGroups,
        /// <summary>
        /// Currencies.
        /// </summary>
        [Localized("CFG_SECTION_CURRENCIES")]
        Currencies,
        /// <summary>
        /// Billing profiles.
        /// </summary>
        [Localized("CFG_SECTION_BILLING_PROFILES")]
        BillingProfiles,
        /// <summary>
        /// Attributes.
        /// </summary>
        [Localized("CFG_SECTION_ATTRIBUTES")]
        Attributes,
        /// <summary>
        /// Presets.
        /// </summary>
        [Localized("CFG_SECTION_PRESETS")]
        Presets,
        /// <summary>
        /// Priority.
        /// </summary>
        [Localized("CFG_SECTION_PRIORITY")]
        Priority,
        /// <summary>
        /// Registers.
        /// </summary>
        [Localized("CFG_SECTION_REGISTERS")]
        Registers,
        /// <summary>
        /// Assets.
        /// </summary>
        [Localized("CFG_SECTION_ASSETS")]
        Assets,
        /// <summary>
        /// Business.
        /// </summary>
        [Localized("CFG_SECTION_BUSINESS")]
        Business,
        /// <summary>
        /// Waiting lines.
        /// </summary>
        [Localized("CFG_SECTION_WAITING_LINES")]
        WaitingLines,
        /// <summary>
        /// Payment methods.
        /// </summary>
        [Localized("CFG_SECTION_PAYMENT_METHODS")]
        PaymentMethods,
        /// <summary>
        /// Reservations.
        /// </summary>
        [Localized("CFG_SECTION_RESERVATIONS")]
        Reservations,
        /// <summary>
        /// Reservations.
        /// </summary>
        [Localized("CFG_SECTION_BACKUP")]
        Backup,
    }
    #endregion

    #region DATABASETYPE
    /// <summary>
    /// Database types.
    /// </summary>
    public enum DatabaseType
    {
        /// <summary>
        /// MYSQL.
        /// </summary>
        [CanUserAssign(false)]
        MYSQL = 0,
        /// <summary>
        /// MSSQL EXPRESS.
        /// </summary>
        [CanUserAssign(true)]
        MSSQLEXPRESS = 2,
        /// <summary>
        /// MS SQL.
        /// </summary>
        [CanUserAssign(true)]
        MSSQL = 1,
        /// <summary>
        /// LOCAL DB.
        /// </summary>
        [CanUserAssign(false)]
        LOCALDB = 3,
        /// <summary>
        /// SQL LITE.
        /// </summary>
        [CanUserAssign(false)]
        SQLITE = 4,
    }
    #endregion

    #region SQLSERVERAUTHENTICATION
    /// <summary>
    /// SQL server authentication types.
    /// </summary>
    public enum SQLServerAuthentication
    {
        /// <summary>
        /// Unspecified.
        /// </summary>
        Unspecified = 0,
        /// <summary>
        /// Server.
        /// </summary>
        [CanUserAssign(true)]
        Server = 1,
        /// <summary>
        /// Integrated.
        /// </summary>
        [CanUserAssign(true)]
        Integrated = 2,
    }
    #endregion

    #region USERROLES
    /// <summary>
    /// User roles.
    /// </summary>
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
    /// <summary>
    /// User change type.
    /// </summary>
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
        /// <summary>
        /// IP Address.
        /// </summary>
        IpAddress = 0,
        /// <summary>
        /// Host name.
        /// </summary>
        HostName = 1,
        /// <summary>
        /// Dispatcher id.
        /// </summary>
        DispatcherId = 2,
        /// <summary>
        /// Is connected.
        /// </summary>
        IsConnected = 3,
        /// <summary>
        /// Module.
        /// </summary>
        Module = 4,
        /// <summary>
        /// Is secured.
        /// </summary>
        IsSecured = 5,
        /// <summary>
        /// Port.
        /// </summary>
        Port = 6,
        /// <summary>
        /// Operating system.
        /// </summary>
        OperatingSystem = 7,
        /// <summary>
        /// Data sent.
        /// </summary>
        DataSent = 8,
        /// <summary>
        /// Data received.
        /// </summary>
        DataReceived = 9,
        /// <summary>
        /// Is locked.
        /// </summary>
        IsLocked = 10,
        /// <summary>
        /// Id.
        /// </summary>
        Id = 11,
        /// <summary>
        /// Is out of order.
        /// </summary>
        IsOutOfOrder = 12,
        /// <summary>
        /// Is in maintenance mode.
        /// </summary>
        IsMaintenanceMode = 13,
        /// <summary>
        /// Host group id.
        /// </summary>
        HostGroupId = 14,
        /// <summary>
        /// Number.
        /// </summary>
        Number = 15,
        /// <summary>
        /// Mac address.
        /// </summary>
        MacAddress = 16,
        /// <summary>
        /// Maximum users.
        /// </summary>
        MaximumUsers = 17,
        /// <summary>
        /// Name.
        /// </summary>
        Name = 18,
        /// <summary>
        /// Icon id.
        /// </summary>
        IconId = 19,
        /// <summary>
        /// State.
        /// </summary>
        State = 20,
    }
    #endregion

    #region USERRESERVERESULT
    /// <summary>
    /// User reserve result.
    /// </summary>
    public enum UserReserveResult
    {
        /// <summary>
        /// Success.
        /// </summary>
        Success = 0,
        /// <summary>
        /// Failed.
        /// </summary>
        Failed = 1,
        /// <summary>
        /// Invalid user group.
        /// </summary>
        InvalidUserGroupId = 2,
        /// <summary>
        /// In use.
        /// </summary>
        InUse = 3,
        /// <summary>
        /// Max reservation reached.
        /// </summary>
        MaxReservationsReached = 4,
        /// <summary>
        /// Invalid host.
        /// </summary>
        InvalidHost = 5,
        /// <summary>
        /// Invalid slot.
        /// </summary>
        InvalidSlot = 6,
    }
    #endregion

    #region USERLOGOUTFLAGS
    /// <summary>
    /// User logout flags.
    /// </summary>
    [Flags()]
    public enum UserLogoutFlags
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Supress logout action.
        /// </summary>
        SupressLogoutAction = 1,
    }
    #endregion

    #region POWERSAVEMODE
    /// <summary>
    /// Power save modes.
    /// </summary>
    public enum PowerSaveMode
    {
        /// <summary>
        /// None.
        /// </summary>
        [Localized("NONE")]
        None = 0,
        /// <summary>
        /// Shut down.
        /// </summary>
        [Localized("POWER_SAVE_MODE_SHUT_DOWN")]
        Shutdown = 1,
        /// <summary>
        /// Sleep.
        /// </summary>
        [Localized("POWER_SAVE_MODE_SLEEP")]
        Sleep = 2
    }
    #endregion

    #region ORDERRESULT
    /// <summary>
    /// Order result.
    /// </summary>
    public enum OrderResult
    {
        /// <summary>
        /// On hold.
        /// </summary>
        OnHold = 0,
        /// <summary>
        /// Accepted.
        /// </summary>
        Accepted = 1,
        /// <summary>
        /// Completed.
        /// </summary>
        Completed = 2,
        /// <summary>
        /// Failed.
        /// </summary>
        Failed = 3,
    }
    #endregion

    #region ORDERFAILREASON
    /// <summary>
    /// Order fail reason.
    /// </summary>
    public enum OrderFailReason
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Insufficient balance.
        /// </summary>
        InsufficientBalance = 1,
        /// <summary>
        /// Invalid payment method.
        /// </summary>
        InvalidPaymentMethod = 2,
        /// <summary>
        /// Invalid order.
        /// </summary>
        InvalidOrder = 3,
        /// <summary>
        /// Ordering is disabled.
        /// </summary>
        OrderingDisabled = 4,
        /// <summary>
        /// Invalid user id.
        /// </summary>
        InvalidUserId = 5,
    }
    #endregion

    #region PRODUCTTYPE
    /// <summary>
    /// Product types.
    /// </summary>
    public enum ProductType
    {
        /// <summary>
        /// Product.
        /// </summary>
        [Localized("PRODUCT_TYPE_PRODUCT")]
        Product,
        /// <summary>
        /// Time product.
        /// </summary>
        [Localized("PRODUCT_TYPE_TIME")]
        ProductTime,
        /// <summary>
        /// Bundle.
        /// </summary>
        [Localized("PRODUCT_TYPE_BUNDLE")]
        ProductBundle,
    }
    #endregion

    #region CONST ERROR CODES

    /// <summary>
    /// Base codes.
    /// </summary>
    public class BASE_CODES
    {
        /// <summary>
        /// Success.
        /// </summary>
        public const int SUCCESS = 0;

        /// <summary>
        /// Failure.
        /// </summary>
        public const int FAILURE = 1;
    }

    /// <summary>
    /// Token error codes.
    /// </summary>
    public class TOKEN_ERROR_CODES
    {
        /// <summary>
        /// Invalid token.
        /// </summary>
        public const int INVALID_TOKEN = 101;
        /// <summary>
        /// Expired token.
        /// </summary>
        public const int EXPIRED_TOKEN = 102;
        /// <summary>
        /// Revoked token.
        /// </summary>
        public const int REVOKED_TOKEN = 103;
        /// <summary>
        /// Used token.
        /// </summary>
        public const int USED_TOKEN = 104;
        /// <summary>
        /// Invalid token input.
        /// </summary>
        public const int INVALID_TOKEN_INPUT = 105;
    }

    /// <summary>
    /// Verification error codes.
    /// </summary>
    public class VERIFICATION_ERROR_CODES
    {
        /// <summary>
        /// Invalid verification.
        /// </summary>
        public const int INVALID_VERIFICATION = 201;
        /// <summary>
        /// Used verification.
        /// </summary>
        public const int USED_VERIFICATION = 202;
    }

    /// <summary>
    /// Confirmation error codes.
    /// </summary>
    public class CONFIRMATION_ERROR_CODES
    {
        /// <summary>
        /// Invalid confirmation.
        /// </summary>
        public const int INVALID_CONFIRMATION_CODE = 301;
    }

    /// <summary>
    /// Extended error codes.
    /// </summary>
    public class EXTENDED_ERROR_CODES
    {
        /// <summary>
        /// Partial success.
        /// </summary>
        public const int PARTIAL_SUCCESS = 401;
        /// <summary>
        /// Invalid input.
        /// </summary>
        public const int INVALID_INPUT = 402;
        /// <summary>
        /// Invalid user id.
        /// </summary>
        public const int INVALID_USER_ID = 403;
        /// <summary>
        /// Invalid user group.
        /// </summary>
        public const int INVALID_USER_GROUP = 404;
        /// <summary>
        /// Non unique input.
        /// </summary>
        public const int NON_UNIQUE_INPUT = 405;
    }

    /// <summary>
    /// Delivery error codes.
    /// </summary>
    public class DELIVERY_ERROR_CODES
    {
        /// <summary>
        /// Failed.
        /// </summary>
        public const int DELIVERY_FAILED = 501;
        /// <summary>
        /// No route.
        /// </summary>
        public const int NO_ROUTE = 502;
    }

    #endregion

    #region VERIFICATIONSTARTRESULTCODE
    /// <summary>
    /// Verification start result code.
    /// </summary>
    public enum VerificationStartResultCode
    {
        /// <summary>
        /// Success.
        /// </summary>
        Success = BASE_CODES.SUCCESS,
        /// <summary>
        /// Failed.
        /// </summary>
        Failed = BASE_CODES.FAILURE,
        /// <summary>
        /// No route.
        /// </summary>
        NoRouteForDelivery = DELIVERY_ERROR_CODES.NO_ROUTE,
        /// <summary>
        /// Delivery failed.
        /// </summary>
        DeliveryFailed = DELIVERY_ERROR_CODES.DELIVERY_FAILED,
        /// <summary>
        /// Invalid user id.
        /// </summary>
        InvalidUserId = EXTENDED_ERROR_CODES.INVALID_USER_ID,
        /// <summary>
        /// Invalid input.
        /// </summary>
        InvalidInput = EXTENDED_ERROR_CODES.INVALID_INPUT,
        /// <summary>
        /// Non unique input.
        /// </summary>
        NonUniqueInput = EXTENDED_ERROR_CODES.NON_UNIQUE_INPUT,
    }
    #endregion

    #region VERIFICATIONCOMPLETERESULTCODE
    /// <summary>
    /// Verification complete result.
    /// </summary>
    public enum VerificationCompleteResultCode
    {
        /// <summary>
        /// Success.
        /// </summary>
        Success = BASE_CODES.SUCCESS,
        /// <summary>
        /// Failure.
        /// </summary>
        Failure = BASE_CODES.FAILURE,
        /// <summary>
        /// Invalid token.
        /// </summary>
        InvalidToken = TOKEN_ERROR_CODES.INVALID_TOKEN,
        /// <summary>
        /// Invalid token input.
        /// </summary>
        InvalidTokenInput = TOKEN_ERROR_CODES.INVALID_TOKEN_INPUT,
        /// <summary>
        /// Expired token.
        /// </summary>
        ExpiredToken = TOKEN_ERROR_CODES.EXPIRED_TOKEN,
        /// <summary>
        /// Used token.
        /// </summary>
        UsedToken = TOKEN_ERROR_CODES.USED_TOKEN,
        /// <summary>
        /// Revoked token.
        /// </summary>
        RevokedToken = TOKEN_ERROR_CODES.REVOKED_TOKEN,
        /// <summary>
        /// Invalid verification.
        /// </summary>
        InvalidVerification = VERIFICATION_ERROR_CODES.INVALID_VERIFICATION,
        /// <summary>
        /// Used verification.
        /// </summary>
        AlreadyVerified = VERIFICATION_ERROR_CODES.USED_VERIFICATION,
        /// <summary>
        /// Partial success.
        /// </summary>
        PartialSuccess = EXTENDED_ERROR_CODES.PARTIAL_SUCCESS,
        /// <summary>
        /// Invalid confirmation code.
        /// </summary>
        InvalidConfirmationCode = CONFIRMATION_ERROR_CODES.INVALID_CONFIRMATION_CODE,
    }
    #endregion

    #region ACCOUNTCREATIONBYTOKENCOMPLETERESULTCODE
    /// <summary>
    /// Account create by token completion result.
    /// </summary>
    public enum AccountCreationByTokenCompleteResultCode
    {
        /// <summary>
        /// Success.
        /// </summary>
        Success = BASE_CODES.SUCCESS,
        /// <summary>
        /// Failure.
        /// </summary>
        Failure = BASE_CODES.FAILURE,
        /// <summary>
        /// Invalid token.
        /// </summary>
        InvalidToken = TOKEN_ERROR_CODES.INVALID_TOKEN,
        /// <summary>
        /// Invalid token input.
        /// </summary>
        InvalidTokenInput = TOKEN_ERROR_CODES.INVALID_TOKEN_INPUT,
        /// <summary>
        /// Expired token.
        /// </summary>
        ExpiredToken = TOKEN_ERROR_CODES.EXPIRED_TOKEN,
        /// <summary>
        /// Used token.
        /// </summary>
        UsedToken = TOKEN_ERROR_CODES.USED_TOKEN,
        /// <summary>
        /// Revoked token.
        /// </summary>
        RevokedToken = TOKEN_ERROR_CODES.REVOKED_TOKEN,
        /// <summary>
        /// Invalid verification.
        /// </summary>
        InvalidVerification = VERIFICATION_ERROR_CODES.INVALID_VERIFICATION,
        /// <summary>
        /// Already verified.
        /// </summary>
        AlreadyVerified = VERIFICATION_ERROR_CODES.USED_VERIFICATION,
        /// <summary>
        /// Invalid input.
        /// </summary>
        InvalidInput = EXTENDED_ERROR_CODES.INVALID_INPUT,
        /// <summary>
        /// Invalid user group.
        /// </summary>
        NoUserGroup = EXTENDED_ERROR_CODES.INVALID_USER_GROUP,
    }
    #endregion

    #region ACCOUNTCREATIONCOMPLETERESULTCODE
    /// <summary>
    /// Account create completion result.
    /// </summary>
    public enum AccountCreationCompleteResultCode
    {
        /// <summary>
        /// Success.
        /// </summary>
        Success = BASE_CODES.SUCCESS,

        /// <summary>
        /// Failure.
        /// </summary>
        Failure = BASE_CODES.FAILURE,

        /// <summary>
        /// Invalid input.
        /// </summary>
        InvalidInput = EXTENDED_ERROR_CODES.INVALID_INPUT,

        /// <summary>
        /// No user group.
        /// </summary>
        NoUserGroup = EXTENDED_ERROR_CODES.INVALID_USER_GROUP,

        /// <summary>
        /// None unique input.
        /// </summary>
        NonUniqueInput = EXTENDED_ERROR_CODES.NON_UNIQUE_INPUT,
    }
    #endregion

    #region SMSSENDRESULTCODE
    /// <summary>
    /// SMS send result.
    /// </summary>
    public enum SMSSendResultCode
    {
        /// <summary>
        /// Sent.
        /// </summary>
        Sent = 0,
        /// <summary>
        /// Failed.
        /// </summary>
        Failed = 1,
    }
    #endregion

    #region SMSGATEWAYPROVIDER
    /// <summary>
    /// Known sms gateway providers.
    /// </summary>
    public enum SMSGatewayProvider
    {
        /// <summary>
        /// Custom.
        /// </summary>
        Custom = 0,
        /// <summary>
        /// Vonage.
        /// </summary>
        Vonage = 1,
        /// <summary>
        /// Twilio.
        /// </summary>
        Twilio = 2,
        /// <summary>
        /// SMC.
        /// </summary>
        SMSC = 3,
    }
    #endregion

    #region SMSGATEWAYPARAMETEROPTION
    /// <summary>
    /// SMS gatweay parameter options.
    /// </summary>
    [Flags()]
    public enum SMSGatewayParameterOption
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
    }
    #endregion

    #region PRODUCTORDERPASSRESULT
    /// <summary>
    /// Product order pass result.
    /// </summary>
    public enum ProductOrderPassResult
    {
        /// <summary>
        /// Success.
        /// </summary>
        [Localized("PRODUCT_ORDER_PASS_RESULT_SUCCESS")]
        Success = 0,
        /// <summary>
        /// Invalid user id passed.
        /// </summary>
        [Localized("PRODUCT_ORDER_PASS_RESULT_INVALID_USER_ID")]
        InvalidUserId = 1,
        /// <summary>
        /// Invalid product id passed.
        /// </summary>
        [Localized("PRODUCT_ORDER_PASS_RESULT_INVALID_PRODUCT_ID")]
        InvalidProdcutId = 2,
        /// <summary>
        /// User group disallowed.
        /// </summary>
        [Localized("PRODUCT_ORDER_PASS_RESULT_DISALLOWED_USER_GROUP")]
        UserGroupDisallowed = 3,
        /// <summary>
        /// Sale disallowed.
        /// </summary>
        [Localized("PRODUCT_ORDER_PASS_RESULT_SALE_DISALLOWED")]
        SaleDisallowed = 4,
        /// <summary>
        /// Client ordering disallowed.
        /// </summary>
        [Localized("PRODUCT_ORDER_PASS_RESULT_CLIENT_ORDER_DISALLOWED")]
        ClientOrderDisallowed = 5,
        /// <summary>
        /// Geuest order disallowed.
        /// </summary>
        [Localized("PRODUCT_ORDER_PASS_RESULT_GUEST_SALE_DISALLOWED")]
        GuestSaleDisallowed = 6,
        /// <summary>
        /// Product id out of stock.
        /// </summary>
        [Localized("PRODUCT_ORDER_PASS_RESULT_OUT_OF_STOCK")]
        OutOfStock = 7,
        /// <summary>
        /// Purchase period disallowed.
        /// </summary>
        [Localized("PRODUCT_ORDER_PASS_RESULT_PURCHASE_PERIOD_DISALLOWED")]
        PeriodDisallowed = 8,
    }
    #endregion

    #region REGISTRATIONVERIFICATIONMETHOD
    /// <summary>
    /// Registration verification methods.
    /// </summary>
    [Flags()]
    public enum RegistrationVerificationMethod
    {
        /// <summary>
        /// No verification.
        /// </summary>
        [Localized("REGISTER_VERIFICATION_METHOD_NONE")]
        None = 0,
        /// <summary>
        /// Email verification.
        /// </summary>
        [Localized("REGISTER_VERIFICATION_METHOD_EMAIL_ADDRESS")]
        Email = 1,
        /// <summary>
        /// Mobile phone verification.
        /// </summary>
        [Localized("REGISTER_VERIFICATION_METHOD_MOBILE_PHONE")]
        MobilePhone = 2,
    }
    #endregion

    #region STORABLE ENUMERATIONS

    #region MODULEENUM
    /// <summary>
    /// Module type enumeration.
    /// </summary>
    [Flags()]
    public enum ModuleEnum
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Manager.
        /// </summary>
        Manager = 1,
        /// <summary>
        /// Client.
        /// </summary>
        Client = 2,
        /// <summary>
        /// Service.
        /// </summary>
        Service = 4,
        /// <summary>
        /// Any.
        /// </summary>
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
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Client.
        /// </summary>
        Client = 1,
        /// <summary>
        /// Server.
        /// </summary>
        Server = 2,
        /// <summary>
        /// Manager.
        /// </summary>
        Manager = 4,
        /// <summary>
        /// Global.
        /// </summary>
        Global = Client | Server | Manager,
    }
    #endregion    

    #region LOGCATEGORIES
    /// <summary>
    /// Log categories.
    /// </summary>
    [Flags()]
    [Serializable()]
    public enum LogCategories
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Generic.
        /// </summary>
        Generic = 1,
        /// <summary>
        /// Network.
        /// </summary>
        Network = 2,
        /// <summary>
        /// Database.
        /// </summary>
        Database = 4,
        /// <summary>
        /// File system.
        /// </summary>
        FileSystem = 8,
        /// <summary>
        /// Task.
        /// </summary>
        Task = 16,
        /// <summary>
        /// Dispatcher.
        /// </summary>
        Dispatcher = 32,
        /// <summary>
        /// Command.
        /// </summary>
        Command = 64,
        /// <summary>
        /// Operation.
        /// </summary>
        Operation = 128,
        /// <summary>
        /// User interface.
        /// </summary>
        UserInterface = 256,
        /// <summary>
        /// Configuration.
        /// </summary>
        Configuration = 512,
        /// <summary>
        /// Subscription.
        /// </summary>
        Subscription = 1024,
        /// <summary>
        /// Trace.
        /// </summary>
        Trace = 2048,
        /// <summary>
        /// User.
        /// </summary>
        User = 4096,
        /// <summary>
        /// All.
        /// </summary>
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
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Information.
        /// </summary>
        Information = 1,
        /// <summary>
        /// Warning.
        /// </summary>
        Warning = 2,
        /// <summary>
        /// Error.
        /// </summary>
        Error = 4,
        /// <summary>
        /// Event.
        /// </summary>
        Event = 8,
        /// <summary>
        /// All.
        /// </summary>
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
        /// <summary>
        /// Unspecified.
        /// </summary>
        Unspecified = 0,
        /// <summary>
        /// Male.
        /// </summary>
        Male = 1,
        /// <summary>
        /// Female.
        /// </summary>
        Female = 2,
    }
    #endregion

    #region USERSESSIONSTATE
    /// <summary>
    /// User session states.
    /// </summary>
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
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Applications.
        /// </summary>
        Applications = 1,
        /// <summary>
        /// Security.
        /// </summary>
        Security = 2,
        /// <summary>
        /// Age rating.
        /// </summary>
        AgeRating = 4,
    }
    #endregion

    #region WEEKDAYS
    /// <summary>
    /// Week days.
    /// </summary>
    [Flags()]
    public enum WeekDays
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Sunday.
        /// </summary>
        Sunday = 1,
        /// <summary>
        /// Monday.
        /// </summary>
        Monday = 2,
        /// <summary>
        /// Tuesday.
        /// </summary>
        Tuesday = 4,
        /// <summary>
        /// Wednesday.
        /// </summary>
        Wednesday = 8,
        /// <summary>
        /// Thursday.
        /// </summary>
        Thursday = 16,
        /// <summary>
        /// Friday.
        /// </summary>
        Friday = 32,
        /// <summary>
        /// Saturday.
        /// </summary>
        Saturday = 64,
    }
    #endregion

    #region BILLRATESTEPACTION
    /// <summary>
    /// Bill rate step actions.
    /// </summary>
    public enum BillRateStepAction
    {
        /// <summary>
        /// Charge.
        /// </summary>
        [Localized("STEP_ACTION_CHARGE")]
        Charge = 0,
        /// <summary>
        /// Loop to.
        /// </summary>
        [Localized("STEP_ACTION_LOOP_TO")]
        LoopTo = 1,
    }
    #endregion

    #region DEPLOYOPTIONTYPE
    /// <summary>
    /// Deployment options.
    /// </summary>
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
    /// <summary>
    /// Personal file options.
    /// </summary>
    [Flags()]
    public enum PersonalUserFileOptionType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Cleanup.
        /// </summary>
        CleanUp = 1,
        /// <summary>
        /// Store.
        /// </summary>
        Store = 2,
        /// <summary>
        /// Include sub directories.
        /// </summary>
        IncludeSubDirectories = 4,
    }
    #endregion

    #region EXECUTABLEOPTIONTYPE
    /// <summary>
    /// Executable options.
    /// </summary>
    [Flags()]
    public enum ExecutableOptionType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Auto launch.
        /// </summary>
        AutoLaunch = 1,
        /// <summary>
        /// Monitor children.
        /// </summary>
        MonitorChildren = 2,
        /// <summary>
        /// Multi run.
        /// </summary>
        MultiRun = 4,
        /// <summary>
        /// Kill children.
        /// </summary>
        KillChildren = 8,
        /// <summary>
        /// Count all instances.
        /// </summary>
        [Obsolete("We dont use this anywhere")]
        CountAllInstances = 16,
        /// <summary>
        /// Quick launch.
        /// </summary>
        QuickLaunch = 32,
        /// <summary>
        /// Shell execute.
        /// </summary>
        ShellExecute = 64,
        /// <summary>
        /// Ignore concurrent execution limit.
        /// </summary>
        IgnoreConcurrentExecutionLimit = 128,
    }
    #endregion

    #region RUNMODES
    /// <summary>
    /// Run mode enumeration.
    /// </summary>
    public enum RunMode
    {
        /// <summary>
        /// Full screen.
        /// </summary>
        [Localized("RUN_MODE_FULL_SCREEN")]
        FullScreen = 0,
        /// <summary>
        /// Minimized.
        /// </summary>
        [Localized("RUN_MODE_MINIMIZED")]
        Minimized = 1,
        /// <summary>
        /// Maximized.
        /// </summary>
        [Localized("RUN_MODE_MAXIMIZED")]
        Maximized = 2,
        /// <summary>
        /// Hidden.
        /// </summary>
        [Localized("RUN_MODE_HIDDEN")]
        Hidden = 3,
        /// <summary>
        /// Normal.
        /// </summary>
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
    /// <summary>
    /// Application options.
    /// </summary>
    [Flags()]
    public enum AppOptionType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Halt execution on any error.
        /// </summary>
        HaltOnError = 1,
    }
    #endregion

    #region USERGROUPOPTIONTYPE
    /// <summary>
    /// User group options.
    /// </summary>
    [Flags()]
    public enum UserGroupOptionType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Enable personal storage.
        /// </summary>
        EnablePersonalStorage = 1,
        /// <summary>
        /// Hide logout button.
        /// </summary>
        HideLogoutButton = 2,
        /// <summary>
        /// Disallow manual login.
        /// </summary>
        DisallowManualLogin = 4,
        /// <summary>
        /// Allow guest use.
        /// </summary>
        GuestUse = 8,
        /// <summary>
        /// Allow only guest use.
        /// </summary>
        GuestUseOnly = 16,
        /// <summary>
        /// Enables or disables personal files.
        /// </summary>
        EnablePersonalFiles = 32,
        /// <summary>
        /// Disallow login from manager.
        /// </summary>
        DisallowLoginFromManager = 64,
    }
    #endregion

    #region CREDITLIMITOPTIONTYPE
    /// <summary>
    /// Credit limit options.
    /// </summary>
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
    /// <summary>
    /// Time product award options.
    /// </summary>
    public enum TimePointAwardOptionType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Time.
        /// </summary>
        Time = 1,
        /// <summary>
        /// Money.
        /// </summary>
        Money = 2
    }
    #endregion

    #region HOSTSTATE
    /// <summary>
    /// Host state.
    /// </summary>
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
    /// <summary>
    /// Host group options.
    /// </summary>
    [Flags()]
    public enum HostGroupOptionType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
    }
    #endregion

    #region PERIODOPTIONTYPE
    /// <summary>
    /// Period options.
    /// </summary>
    [Flags()]
    public enum PeriodOptionType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Has day time range.
        /// </summary>
        HasDayTimeRange = 1,
        /// <summary>
        /// Has date range.
        /// </summary>
        HasDateRange = 2,
    }
    #endregion

    #region STOCKOPTIONTYPE
    /// <summary>
    /// Stock options.
    /// </summary>
    [Flags()]
    public enum StockOptionType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Enable stock.
        /// </summary>
        EnableStock = 1,
        /// <summary>
        /// Disallow out of stock sale.
        /// </summary>
        DisallowSaleIfOutOfStock = 2,
        /// <summary>
        /// Alert out of stock.
        /// </summary>
        Alert = 4,
        /// <summary>
        /// Target different product.
        /// </summary>
        TargetDifferentProduct = 8,
    }
    #endregion

    #region BUNDLESTOCKOPTIONTYPE
    /// <summary>
    /// Bundle stock options.
    /// </summary>
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
        /// <summary>
        /// None.
        /// </summary>
        None,
    }
    #endregion

    #region ORDEROPTIONTYPE
    /// <summary>
    /// Order options.
    /// </summary>
    [Flags()]
    public enum OrderOptionType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Client order disallowed.
        /// </summary>
        DisallowAllowOrder = 1,
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
        /// <summary>
        /// And.
        /// </summary>
        [Localized("AND")]
        And = 0,
        /// <summary>
        /// Or.
        /// </summary>
        [Localized("OR")]
        Or = 1
    }
    #endregion

    #region PRODUCTSORTOPTIONTYPE
    /// <summary>
    /// Product sort options.
    /// </summary>
    public enum ProductSortOptionType
    {
        /// <summary>
        /// Default.
        /// </summary>
        [Localized("MANUAL")]
        Default = 0,
        /// <summary>
        /// Name.
        /// </summary>
        [Localized("NAME")]
        Name = 1,
        /// <summary>
        /// Created.
        /// </summary>
        [Localized("CREATION_TIME")]
        Created = 2
    }
    #endregion

    #region BILLRATEOPTIONTYPE
    /// <summary>
    /// Billing rate options.
    /// </summary>
    public enum BillRateOptionType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Is step based.
        /// </summary>
        IsStepBased = 1,
    }
    #endregion

    #region PRODUCTTIMEEXPIRATIONOPTIONTYPE
    /// <summary>
    /// Product time expiration options.
    /// </summary>
    [Flags()]
    public enum ProductTimeExpirationOptionType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// At logout.
        /// </summary>
        ExpiresAtLogout = 1,
        /// <summary>
        /// At date.
        /// </summary>
        [Obsolete()]
        ExpiresAtDate = 2,
        /// <summary>
        /// After time.
        /// </summary>
        ExpireAfterTime = 4,
        /// <summary>
        /// At day time.
        /// </summary>
        ExpireAtDayTime = 8,
    }
    #endregion

    #region PRODUCTTIMEUSAGEOPTIONTYPE
    /// <summary>
    /// Product time usage options.
    /// </summary>
    [Flags()]
    public enum ProductTimeUsageOptionType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Maximum usage.
        /// </summary>
        HasMaximumUsage = 1,
        /// <summary>
        /// Maximum daily usage.
        /// </summary>
        HasMaximumDailyUsage = 2,
    }
    #endregion

    #region EXPIREFROMOPTIONTYPE
    /// <summary>
    /// Expire from options.
    /// </summary>
    public enum ExpireFromOptionType
    {
        /// <summary>
        /// Purchase.
        /// </summary>
        [Localized("EXPIRE_FROM_PURCHASE")]
        Purchase = 0,
        /// <summary>
        /// Use.
        /// </summary>
        [Localized("EXPIRE_FROM_USE")]
        Use = 1
    }
    #endregion

    #region EXPIREAFTERTYPE
    /// <summary>
    /// Expire after types.
    /// </summary>
    public enum ExpireAfterType
    {
        /// <summary>
        /// Day.
        /// </summary>
        [Localized("DAY_PLURAL")]
        Day = 0,
        /// <summary>
        /// Hour.
        /// </summary>
        [Localized("HOUR_PLURAL")]
        Hour = 1,
        /// <summary>
        /// Minute.
        /// </summary>
        [Localized("MINUTE_PLURAL")]
        Minute = 2,
    }
    #endregion    

    #region DISCOUNTAMOUNTTYPE
    /// <summary>
    /// Discount amount types.
    /// </summary>
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
        /// <summary>
        /// Unspecified.
        /// </summary>
        Unspecified = 0,
        /// <summary>
        /// Product groups.
        /// </summary>
        ProductGroups = 1,
        /// <summary>
        /// Product.
        /// </summary>
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
    /// <summary>
    /// Payment method options.
    /// </summary>
    [Flags()]
    public enum PaymentMethodOptionType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
    }
    #endregion

    #region PAYMENTMETHODTYPE
    /// <summary>
    /// Known payment method types.
    /// </summary>
    public enum PaymentMethodType
    {
        /// <summary>
        /// Undefined.
        /// </summary>
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

    #region DEPOSITTRANSACTIONTYPE
    /// <summary>
    /// Deposit transaction types.
    /// </summary>
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
    /// <summary>
    /// Loyality points transaction type.
    /// </summary>
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
        Credit = 3,
        /// <summary>
        /// Points return transaction.
        /// </summary>
        Remove = 4,
    }
    #endregion

    #region STOCKTRANSACTIONTYPE
    /// <summary>
    /// Stock transaction type.
    /// </summary>
    public enum StockTransactionType
    {
        /// <summary>
        /// Add.
        /// </summary>
        [Localized("STOCK_TRANSACTION_ADD")]
        Add = 0,
        /// <summary>
        /// Remove.
        /// </summary>
        [Localized("STOCK_TRANSACTION_REMOVE")]
        Remove = 1,
        /// <summary>
        /// Sale.
        /// </summary>
        [Localized("STOCK_TRANSACTION_SALE")]
        Sale = 2,
        /// <summary>
        /// Set.
        /// </summary>
        [Localized("STOCK_TRANSACTION_SET")]
        Set = 3,
        /// <summary>
        /// Return.
        /// </summary>
        [Localized("STOCK_TRANSACTION_RETURN")]
        Return = 4,
    }
    #endregion

    #region ORDERSTATUS
    /// <summary>
    /// Order status.
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// On hold.
        /// </summary>
        [Localized("ORDER_STATUS_ON_HOLD")]
        OnHold = 0,
        /// <summary>
        /// Completed.
        /// </summary>
        [Localized("ORDER_STATUS_COMPLETED")]
        Completed = 1,
        /// <summary>
        /// Canceled.
        /// </summary>
        [Localized("ORDER_STATUS_CANCELED")]
        Canceled = 2,
        /// <summary>
        /// Accepted.
        /// </summary>
        [Localized("ORDER_STATUS_ACCEPTED")]
        Accepted = 3,
    }
    #endregion

    #region INVOICESTATUS
    /// <summary>
    /// Invoice status.
    /// </summary>
    public enum InvoiceStatus
    {
        /// <summary>
        /// Unpaid.
        /// </summary>
        [Localized("INVOICE_STATUS_UNPAID")]
        Unpaid = 0,
        /// <summary>
        /// Partially paid.
        /// </summary>
        [Localized("INVOICE_STATUS_PARTIALLY_PAID")]
        PartialyPaid = 1,
        /// <summary>
        /// Paid.
        /// </summary>
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
        /// <summary>
        /// Batch.
        /// </summary>
        [CanUserAssign(true)]
        [Description("Batch")]
        Batch,
        /// <summary>
        /// VB Script.
        /// </summary>
        [CanUserAssign(true)]
        [Description("Visual Basic")]
        VbScript,
        /// <summary>
        /// Auto it script.
        /// </summary>
        [CanUserAssign(true)]
        [Description("Autoit")]
        AutoItScript,
        /// <summary>
        /// Registry script.
        /// </summary>
        [CanUserAssign(true)]
        [Description("Registry")]
        RegistryScript,
    }
    #endregion

    #region TASKPROCESSOPTIONTYPE
    /// <summary>
    /// Task process options.
    /// </summary>
    [Flags()]
    public enum TaskProcessOptionType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Wait.
        /// </summary>
        Wait = 1,
        /// <summary>
        /// No window.
        /// </summary>
        NoWindow = 2,
    }
    #endregion

    #region TASKJUNCTIONOPTIONTYPE
    /// <summary>
    /// Task junction options.
    /// </summary>
    [Flags()]
    public enum TaskJunctionOptionType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Delete destination.
        /// </summary>
        DeleteDestination = 1,
    }
    #endregion

    #region TASKNOTIFICATIONOPTIONTYPE
    /// <summary>
    /// Task notification options.
    /// </summary>
    [Flags()]
    public enum TaskNotificationOptionType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Wait.
        /// </summary>
        Wait = 1,
    }
    #endregion

    #region PERSONALFILEACTIVATIONTYPE
    /// <summary>
    /// Personal file activation type.
    /// </summary>
    public enum PersonalFileActivationType
    {
        /// <summary>
        /// Launch.
        /// </summary>
        [Localized("PERSONAL_FILE_ACTIVATION_TYPE_LAUNCH")]
        Launch = 0,
        /// <summary>
        /// Login.
        /// </summary>
        [Localized("PERSONAL_FILE_ACTIVATION_TYPE_LOGIN")]
        Login = 1,
    }
    #endregion

    #region PERSONALFILEDEACTIVATIONTYPE
    /// <summary>
    /// Personal file de-activation type.
    /// </summary>
    public enum PersonalFileDeactivationType
    {
        /// <summary>
        /// Logout.
        /// </summary>
        [Localized("LOGOUT")]
        Logout = 0
    }
    #endregion

    #region CLIENTTASKACTIVATIONTYPE
    /// <summary>
    /// Client task activation types.
    /// </summary>
    [Flags()]
    public enum ClientTaskActivationType
    {
        /// <summary>
        /// Disabled.
        /// </summary>
        [Obsolete()]
        [Description("Disabled")]
        Disabled = 0,
        /// <summary>
        /// Startup.
        /// </summary>
        [Description("Startup")]
        Startup = 1,
        /// <summary>
        /// Shut down.
        /// </summary>
        [Description("Shutdown")]
        Shutdown = 2,
        /// <summary>
        /// Login.
        /// </summary>
        [Description("Login")]
        Login = 4,
        /// <summary>
        /// Logout.
        /// </summary>
        [Description("Logout")]
        Logout = 8,
    }
    #endregion

    #region EXECUTABLETASKACTIVATIONTYPE
    /// <summary>
    /// Executable task activation types.
    /// </summary>
    [Flags()]
    public enum ExecutableTaskActivationType
    {
        /// <summary>
        /// Pre launch/
        /// </summary>
        [Description("Pre Launch")]
        PreLaunch = 16,
        /// <summary>
        /// Post deploy.
        /// </summary>
        [Description("Pre Deploy")]
        PreDeploy = 32,
        /// <summary>
        /// Post termination.
        /// </summary>
        [Description("Post Termination")]
        PostTermination = 64,
        /// <summary>
        /// Pre licenses management.
        /// </summary>
        [Description("Pre License Management")]
        PreLicenseManagement = 128,
    }
    #endregion

    #region LOGICALOPERATOR
    /// <summary>
    /// Logical operator.
    /// </summary>
    public enum LogicalOperator
    {
        /// <summary>
        /// And.
        /// </summary>
        [Localized("AND")]
        And,
        /// <summary>
        /// Or.
        /// </summary>
        [Localized("OR")]
        Or,
    }
    #endregion

    #region NOTESEVERITY
    /// <summary>
    /// Note severity.
    /// </summary>
    public enum NoteSeverity
    {
        /// <summary>
        /// Green.
        /// </summary>
        [Localized("NOTE_SEVIRITY_GREEN")]
        Green = 0,
        /// <summary>
        /// Yellow.
        /// </summary>
        [Localized("NOTE_SEVIRITY_YELLOW")]
        Yellow = 1,
        /// <summary>
        /// Red.
        /// </summary>
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
        /// <summary>
        /// None.
        /// </summary>
        [Localized("NONE")]
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
        /// <summary>
        /// None.
        /// </summary>
        [Localized("NONE")]
        None = 0,
    }
    #endregion

    #region SHIFTOPTION
    /// <summary>
    /// Shift option.
    /// </summary>
    public enum ShiftOption
    {
        /// <summary>
        /// Disabled.
        /// </summary>
        [Localized("SHIFT_OPTION_DISABLED")]
        Disabled = 0,
        /// <summary>
        /// Optional.
        /// </summary>
        [Localized("SHIFT_OPTION_OPTIONAL")]
        Optional = 1,
        /// <summary>
        /// Mandatory.
        /// </summary>
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
        [Localized("PAY_IN")]
        PayIn = 1,
        /// <summary>
        /// Pay out.
        /// </summary>
        [Localized("PAY_OUT")]
        PayOut = 2
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
        /// <summary>
        /// Mixed.
        /// </summary>
        Mixed = 2,
        /// <summary>
        /// Points.
        /// </summary>
        Points = 1,
        /// <summary>
        /// Cash.
        /// </summary>
        Cash = 0,
    }
    #endregion

    #region REFUNDSTATUS
    /// <summary>
    /// Refund status.
    /// </summary>
    public enum RefundStatus
    {
        /// <summary>
        /// None.
        /// </summary>
        [Localized("REFUND_STATUS_NONE")]
        None,
        /// <summary>
        /// Partial.
        /// </summary>
        [Localized("REFUND_STATUS_PARTIAL")]
        Partial,
        /// <summary>
        /// Full.
        /// </summary>
        [Localized("REFUND_STATUS_FULL")]
        Full,
    }
    #endregion

    #region BILLINGOPTION
    /// <summary>
    /// Billing options.
    /// </summary>
    public enum BillingOption
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Disable time offers.
        /// </summary>
        DisableTimeOffer = 1,
        /// <summary>
        /// Disable fixed time.
        /// </summary>
        DisableFixedTime = 2,
        /// <summary>
        /// Disable deposits.
        /// </summary>
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
        /// <summary>
        /// None.
        /// </summary>
        [Localized("WAITING_LINE_TIMEOUT_OPTION_NONE")]
        None = 0,
        /// <summary>
        /// Remove.
        /// </summary>
        [Localized("WAITING_LINE_TIMEOUT_OPTION_REMOVE")]
        Remove = 1,
        /// <summary>
        /// Next in line.
        /// </summary>
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
        /// <summary>
        /// Active.
        /// </summary>
        [Localized("WAITING_LINE_SATE_ACTIVE")]
        Active = 0,
        /// <summary>
        /// Processed.
        /// </summary>
        [Localized("WAITING_LINE_SATE_PROCESSED")]
        Processed = 2,
        /// <summary>
        /// Cancel.
        /// </summary>
        [Localized("WAITING_LINE_SATE_CANCEL")]
        Cancel = 1,
    }
    #endregion    

    #region TOKENTYPE
    /// <summary>
    /// Security token types.
    /// </summary>
    public enum TokenType
    {
        /// <summary>
        /// JWT Refresh token.
        /// </summary>
        JWTRefresh = 0,
        /// <summary>
        /// Email verification token.
        /// </summary>
        VerifyEmail = 1,
        /// <summary>
        /// Mobile phone verification token.
        /// </summary>
        VerifyMobilePhone = 2,
        /// <summary>
        /// Create account token.
        /// </summary>
        CreateAccount = 3,
        /// <summary>
        /// Reset password token.
        /// </summary>
        ResetPassword = 4,
    }
    #endregion

    #region TOKENSTATUS
    /// <summary>
    /// Token status enumeration.
    /// </summary>
    public enum TokenStatus
    {
        /// <summary>
        /// Token unused.
        /// </summary>
        [Localized("TOKEN_STATUS_UNUSED")]
        Unused = 0,
        /// <summary>
        /// Token used.
        /// </summary>
        [Localized("TOKEN_STATUS_USED")]
        Used = 1,
        /// <summary>
        /// Token revoked.
        /// </summary>
        [Localized("TOKEN_STATUS_REVOKED")]
        Revoked = 2,
    }
    #endregion

    #region RESERVATIONSTATUS
    /// <summary>
    /// Reservation status.
    /// </summary>
    public enum ReservationStatus
    {
        /// <summary>
        /// Reservation is waiting.
        /// </summary>
        Waiting = 0,
        /// <summary>
        /// Reservation is canceled by operator.
        /// </summary>
        Canceled = 1,
    }
    #endregion

    #region VERIFICATIONSTATUS
    /// <summary>
    /// Verification status.
    /// </summary>
    public enum VerificationStatus
    {
        /// <summary>
        /// Unverified.
        /// </summary>
        Unverified = 0,
        /// <summary>
        /// Verified.
        /// </summary>
        Verified = 1,
    }
    #endregion

    #region ORDERSOURCE
    /// <summary>
    /// Client order source.
    /// </summary>
    public enum OrderSource
    {
        /// <summary>
        /// Default. (POS)
        /// </summary>
        Default = 0,
        /// <summary>
        /// Client machine.
        /// </summary>
        Client = 1,
        /// <summary>
        /// Web portal.
        /// </summary>
        Web = 2,
    }
    #endregion

    #endregion
    
    #region SoundNotificationBalanceOptions
    public enum SoundNotificationBalanceOptions : int
    {
        All = 0,
        NegativeBalanceOnly = 1
    }
    #endregion

    #region RFIDScanUserCardActions
    public enum RFIDScanUserCardActions : int
    {
        OpenUserInfoWindow = 0,
        OpenUserSalesWindow = 1,
        OpenUserDepositWindow = 2
    }
    #endregion

}
