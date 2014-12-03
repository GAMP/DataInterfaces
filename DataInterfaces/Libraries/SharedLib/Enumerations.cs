using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Linq;
using Localization;

namespace SharedLib
{
    #region View Models Enumerations

    #region ActionState
    /// <summary>
    /// Basic enumeration for actions or operations.
    /// </summary>
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

    #region StartPageViewTypes
    public enum StartPageViewTypes : int
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
    public enum ContextExecutionViewState : int
    {
        Initial = 0,
        Working = 1,
        Ready = 2,
    }
    #endregion

    #region DialogType
    /// <summary>
    /// Dialogue types.
    /// <remarks>
    /// This is generaly used in view models to mark the current dialogue type.
    /// </remarks>
    /// </summary>
    [Serializable()]
    public enum DialogType : int
    {
        None = 0,
        Add = 1,
        Edit = 2,
    }
    #endregion

    #endregion

    #region Know Folders Types
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
        [GUIDAttribute("B4BFCC3A-DB2C-424C-B029-7FE99A87C641")]
        [SpecialFolderAttribute(Environment.SpecialFolder.DesktopDirectory)]
        Desktop = 1,
        /// <summary>
        /// Downloads flag.
        /// </summary>
        [GUIDAttribute("374DE290-123F-4565-9164-39C4925E467B")]
        Downloads = 2,
        /// <summary>
        /// Favorites flag.
        /// </summary>
        [GUIDAttribute("1777F761-68AD-4D8A-87BD-30B759FA33DD")]
        [SpecialFolderAttribute(Environment.SpecialFolder.Favorites)]
        Favorites = 4,
        /// <summary>
        /// My Music flag.
        /// </summary>
        [GUIDAttribute("4BD8D571-6D19-48D3-BE97-422220080E43")]
        [SpecialFolderAttribute(Environment.SpecialFolder.MyMusic)]
        Music = 8,
        /// <summary>
        /// My pictures flag.
        /// </summary>
        [GUIDAttribute("33E28130-4E1E-4676-835A-98395C3BC3BB")]
        [SpecialFolderAttribute(Environment.SpecialFolder.MyPictures)]
        Pictures = 16,
        /// <summary>
        /// My videos flag.
        /// </summary>
        [GUIDAttribute("18989B1D-99B5-455B-841C-AB7C74E4DDFC")]
        [SpecialFolderAttribute(Environment.SpecialFolder.MyVideos)]
        Videos = 32,
        /// <summary>
        /// Saved games flag.
        /// </summary>
        [GUIDAttribute("4C5C32FF-BB9D-43b0-B5B4-2D72E54EAAA4")]
        SavedGames = 64,
        /// <summary>
        /// Personal flag (Equals MyDocuments).
        /// </summary>
        [GUIDAttribute("FDD39AD0-238F-46AF-ADB4-6C85480369C7")]
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

    #region DesktopItemType
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

    #region Application Modes
    /// <summary>
    /// Game application modes.
    /// </summary>
    /// <remarks></remarks>
    [Flags()]
    public enum ApplicationModes : int
    {
        DefaultMode = 0,
        SinglePlayer = 1,

        /// <summary>
        /// Online multiplayer.
        /// </summary>
        Online = 2,

        /// <summary>
        /// Lan Multiplayer.
        /// </summary>
        Multiplayer = 4,
        
        Settings = 8,
        Utility = 16,
        Game = 32,
        Application = 64,
        FreeToPlay = 128,
        RequiresSubscription = 256,
        FreeTrial = 512,

        SplitScreenMultiPlayer = 1024,

        CoOpLan = 2048,
        CoOpOnline = 4096,
    }
    #endregion

    #region Runmodes
    /// <summary>
    /// Run mode enumeration.
    /// </summary>
    public enum RunMode : int
    {
        FullScreen = 0,
        Minimized = 1,
        Maximized = 2,
        Hidden = 3,
        Normal = 4
    }
    #endregion

    #region ModuleEnum
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

    #region Module Scopes
    /// <summary>
    /// Application module type scope enumeration.
    /// </summary>
    [Flags()]
    public enum ModuleScopes : int
    {
        None = 0,
        Client = 1,
        Server = 2,
        Manager = 4,
        Global = ModuleScopes.Client | ModuleScopes.Server | ModuleScopes.Manager,
    }
    #endregion

    #region Activation Types
    /// <summary>
    /// Common activation deactivation types.
    /// </summary>
    [Flags()]
    public enum ActivationType : int
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

    #region LicenseReservationType
    [Flags]
    public enum LicenseReservationType
    {
        FirstAvailable = 0,
        OneFromEach = 1,
    }
    #endregion

    #region Script Types
    /// <summary>
    /// Script enumeration type.
    /// </summary>
    public enum ScriptTypes
    {
        [CanUserAssignAttribute(true)]
        [Description("Batch")]
        Batch,
        [CanUserAssignAttribute(true)]
        [Description("Visual Basic Script")]
        VbScript,
        [CanUserAssignAttribute(true)]
        [Description("Autoit Script")]
        AutoItScript,
        [CanUserAssignAttribute(true)]
        [Description("Registry Script")]
        RegistryScript,
    }
    #endregion

    #region Login States
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
        /// <summary>

        ///<summary>
        /// Login completed.
        /// </summary>
        LoginCompleted = 16 | LoggedIn,
    }
    #endregion

    #region Client Event Types
    /// <summary>
    /// Enumerator for the types of client events.
    /// </summary>
    public enum ClientEventTypes : int
    {
        LockState,
        IdChange,
        SecurityState,
        OutOfOrderState,
        Maintenance,
    }
    #endregion

    #region Context Excecution State
    /// <summary>
    /// Execution context state enumeration.
    /// </summary>
    public enum ContextExecutionState : int
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

    #region ContainerItemEventType
    [Serializable()]
    public enum ContainerItemEventType : int
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

    #region PersonalUserFileType
    /// <summary>
    /// Personal user file types.
    /// </summary>
    public enum PersonalUserFileType : uint
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

    #region LogoutAction
    public enum LogoutAction : int
    {
        NoAction = -1,
        Reboot = 0,
        ClosePrograms = 1,
        TurnOff = 2,
        LogOff = 3,
        StandBy = 4,
        AdminMode = 5,
    }
    #endregion

    #region UserInfoTypes
    /// <summary>
    /// User personal information types.
    /// </summary>
    [Flags()]
    public enum UserInfoTypes : int
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
        /// Email Address.
        /// </summary>
        Email = 256,
        /// <summary>
        /// Address.
        /// </summary>
        Address = 8,
        /// <summary>
        /// Landline Phone Number.
        /// </summary>
        Phone = 512,
        /// <summary>
        /// Mobile Phone Number.
        /// </summary>
        Mobile = 1024,
        /// <summary>
        /// Postal Code. Zip for United States.
        /// </summary>
        PostCode = 32,
        /// <summary>
        /// City.
        /// </summary>            
        City = 16,
        /// <summary>
        /// State.
        /// </summary>
        State = 64,
        /// <summary>
        /// Country.
        /// </summary>
        Country = 128,
        /// <summary>
        /// Users password.
        /// </summary>
        Password = 4096,
        /// <summary>
        /// Users sex.
        /// </summary>
        Sex = 2048,
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

    #region LoginUserActivity
    /// <summary>
    /// Represents client activity during user login or logout.
    /// </summary>
    public enum LoginUserActivity
    {
        None = 0,
        SettingPersonalUserFile = 1,
        DeletingUserStorage = 2,
        TerminatingUserProcesses = 3,
    }
    #endregion

    #region NotificationButtons
    public enum NotificationButtons
    {
        None = 0,
        Ok = 1,
        Yes = 2,
        No = 3,
        Cancel = 4,
    }
    #endregion

    #region AgeRatingType
    public enum AgeRatingType : byte
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
    public enum PEGI : int
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
    public enum ESRB : int
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

    #region DurationRange
    public enum DurationRange
    {
        Today = 0,
        Weeek = 1,
        Month = 2,
        Year = 3,
        Decade = 4,
        Unlimited = 5,
    }
    #endregion

    #region FilterResultDirection
    public enum FilterResultDirection
    {
        Top,
        Bottom,
    }
    #endregion    

    #region StartupModuleActivity
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

    #region LicenseStatus
    /// <summary>
    /// License status enumeration.
    /// </summary>
    public enum LicenseStatus : int
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

    #region EventTypes
    /// <summary>
    /// Event Log types representation.
    /// </summary>
    [Flags()]
    [Serializable()]
    public enum EventTypes : int
    {
        None = 0,
        Information = 1,
        Warning = 2,
        Error = 4,
        Event = 8,
        All = Information | Warning | Error | Event
    }
    #endregion

    #region LogCategories
    [Flags()]
    [Serializable()]
    public enum LogCategories : int
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

    #region TaskType
    [Serializable()]
    public enum TaskType
    {
        [CanUserAssign(true)]
        [Description("Process")]
        Process,
        [CanUserAssign(true)]
        [Description("Script")]
        Script,
        [CanUserAssign(false)]
        [Description("File System")]
        FileSystem,
        [CanUserAssign(false)]
        [Description("Task Chain")]
        Chain,
        [CanUserAssign(true)]
        [Description("Notification")]
        Notification,
        [CanUserAssign(true)]
        [Description("Junction")]
        Junction,
        [CanUserAssign(false)]
        [Description("All Types")]
        AllTypes = 65535,
    }
    #endregion

    #region IPVersion
    public enum IPVersion : short
    {
        IPV4 = 0,
        IPV6 = 1,
    }
    #endregion

    #region DriverType
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

    #region HostEventType
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

    #region FreeSpaceAllocations
    public enum FreeSpaceAllocations : byte
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

    #region SEX
    /// <summary>
    /// Sex enumeration.
    /// </summary>
    [Flags()]
    public enum Sex : int
    {
        Unspecified = 0,
        Male = 1,
        Female = 2,
    }
    #endregion

    #region IMAGETYPE
    public enum ImageType : int
    {
        Application = 0,
        Executable = 1,
        VisualOptions = 2,
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
    }
    #endregion

    #region USERSESSIONSTATE
    [Flags(), Serializable()]
    public enum SessionState : int
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
        /// Sesstion paused and pending activation.
        /// </summary>
        Paused = 8 | Active,
    }
    #endregion

    #region ACTIONSOURCE
    public enum ActionSource
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
    public enum HostPropertyType
    {
        IpAddress = 0,
        HostName = 1,
        DispatcherId = 3,
        IsConnected = 4,
        Module = 5,
        IsSecured = 6,
        Port = 7,
        OperatingSystem = 8,
        DataSent = 9,
        DataReceived = 10,
        IsLocked = 11,
        Id = 12,
        IsOutOfOrder = 13,
        IsMaintenanceMode = 14,
        LoginState = 15,
        CurrentUserId = 16,
        CurrentUserName = 17,
        HostGroupId = 18,
        Number = 19,
        MacAddress = 20,
        MaximumUsers =21,
    }
    #endregion

    #region CONFIGURATIONSECTION
    public enum ConfigurationSection
    {
        Unspecified = 0,
        General,
        Server,
        Client,
        Profiles,
        Operators,
        Subscription,
        Variables,
        Plugins,
        Api,
        Network,
        Database,
        Integration,
        FileSystem,
        Shell,
        Tasks,
        ClientMisc,
        ServerMisc,
        HostGroups,
        UserGroups,
        ApplicationGroups,
        SecurityProfiles,
        ClientSettings,
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

    #region BILLPROFILERATEACTION
    public enum BillProfileRateAction
    {
        GoTo = 0,
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
        CountAllInstances = 16
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
        DisablePersonalStroage = 1,
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
        DisableShell = 1,
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
    public enum StockOptionType
    {
        None = 0,
        EnableStock = 1,
        DisallowSaleIfOutOfStock = 2 | EnableStock,
        DisallowSaleIfBundledOutOfStock = 4 | EnableStock,
        Alert = 8 | EnableStock,
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
        RestrictNonUsers = 2,
    }
    #endregion

    #region BILLINGRATEOPTIONTYPE
    [Flags()]
    public enum BillingRateOptionType
    {
        None = 0,
        IsStepBased = 1,
    }
    #endregion

    #region TIMEOFFEREXPIRATIONOPTIONTYPE
    [Flags()]
    public enum TimeOfferExpirationOptionType
    {
        None = 0,
        HasExpiration = 1,
        ExpiresAtLogout = 2 | HasExpiration,
        ExpiresAtDate = 4 | HasExpiration,
    }
    #endregion

    #region TIMEOFFERUSAGEOPTIONTYPE
    [Flags()]
    public enum TimeOfferUsageOptionType
    {
        None = 0,
        HasMaximumUsage = 1,
        HasMaximumDailyUsage = 2 | HasMaximumUsage,
        HasScheduledUsage = 4 | HasMaximumUsage,
    }
    #endregion

    #region UNITOFMEASUREOPTIONTYPE
    [Flags()]
    public enum UnitOfMeasureOptionType
    {
        None = 0,
    }
    #endregion

    #region DISCOUNTTYPEOPTIONTYPE
    public enum DiscountTypeOptionType
    {
        Fixed = 0,
        Percentage = 1,
    }
    #endregion

    #region PAYMENTMETHODOPTIONTYPE
    [Flags()]
    public enum PaymentMethodOptionType
    {
        None = 0
    }
    #endregion

    #region ROUNDOPTIONTYPE
    public enum RoundOptionType
    {
        None = 0,
    }
    #endregion

    #region BALANCETRANSACTIONTYPE
    public enum BalanceTransactionType
    {
        /// <summary>
        /// Deposit to an account.
        /// </summary>
        Deposit = 0,
        /// <summary>
        /// Withdraw from account.
        /// </summary>
        Withdraw = 1,
        /// <summary>
        /// Account charge.
        /// </summary>
        Charge = 2
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
    }
    #endregion

    #region STOCKTRANSACTIONTYPE
    public enum StockTransactionType
    {
        Add = 0,
        Remove = 1
    }
    #endregion

    #region ORDERSTATUS
    public enum OrderStatus
    {
        Open = 0,
        Canceled = 1,
        Invoiced = 2,
    }
    #endregion

    #region INVOICESTATUS
    public enum InvoiceStatus
    {
        Outstanding = 0,
        Paid = 1,
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

    #region CLIENTTASKACTIVATIONTYPE
    [Flags()]
    public enum ClientTaskActivationType
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
}
