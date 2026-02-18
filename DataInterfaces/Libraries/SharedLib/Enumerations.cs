using System;
using System.ComponentModel;
using Gizmo;

namespace SharedLib
{
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
        /// Executable has exited. This only occurs when all children has exited thus executable is considered dead and finalized.
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

    public static class AgeRatingTypeExtensions
    {
        extension(AgeRatingType)
        {
            public static AgeRatingType FromAgeRating(int ageRating)
                => ageRating switch
                {
                    > 0 => AgeRatingType.Manual,
                    < 0 and >= -20 => AgeRatingType.PEGI,
                    < -20 and >= -40 => AgeRatingType.ESRB,
                    _ => AgeRatingType.None
                };
        }
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

    #region GLOBALTAXSYSTEMS
    /// <summary>
    /// Global tax system codes.
    /// </summary>
    public enum GlobalTaxSystems
    {
        [Localized("GLOBAL_TAX_SYSTEM_ΝΟΝΕ")]
        None = 0,
        [Localized("GLOBAL_TAX_SYSTEM_RUSSIA")]
        Russia = 1
    }
    #endregion

    #region SMTPSECURITY
    /// <summary>
    /// SMTP Security.
    /// </summary>
    public enum SMTPSecurity
    {
        [Localized("SMTP_SECURITY_NONE")]
        None = 0,
        [Localized("SMTP_SECURITY_SSL")]
        SSL = 1,
        [Localized("SMTP_SECURITY_STARTTLS")]
        STARTTLS = 2
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
}
