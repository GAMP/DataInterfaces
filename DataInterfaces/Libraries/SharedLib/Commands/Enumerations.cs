using System;

namespace SharedLib.Commands
{
    #region CommandStates
    /// <summary>
    /// Represents a states of the commands.
    /// </summary>
    [Flags()]
    public enum CommandStates : uint
    {
        /// <summary>
        /// None state.
        /// <remarks >
        /// This should be set in responses if command not requires any call back.
        /// </remarks>
        /// </summary>
        None = 0,
        /// <summary>
        /// This can be set when command is sent (if required).
        /// </summary>
        Sent = 1,
        /// <summary>
        /// This can be set when command is received (if required).
        /// </summary>
        Received = 2,
        /// <summary>
        /// Can be set when IOperation class processing data.
        /// <remarks >
        /// Can be set multiple times between state changes.
        /// </remarks>
        /// </summary>
        Processing = 4,
        /// <summary>
        /// Aborted state. Should be set in IOperation class when operation is sucessfully aborted.
        /// </summary>
        Processed = 8,
        /// <summary>
        /// Queued command state.
        /// </summary>
        Queued = 16,
        /// <summary>
        /// Command is not supported.
        /// </summary>
        NotSupported = 32,
        /// <summary>
        /// Invalid command parameters specified.
        /// <remarks>
        /// </remarks>
        /// </summary>
        InvalidParameters = 64,
        /// <summary>
        /// State should be set when request or response sending failed.
        /// </summary>
        SendFailed = 128,
        /// <summary>
        /// Occours when command carries an operation or a state update and requested command is not present.
        /// </summary>
        RequestNotFound = 256,
        /// <summary>
        /// This state is set when operation exception is unhandled.
        /// </summary>
        UnhandledOperationException = 512,
        /// <summary>
        /// Occours when command data is not recognized.
        /// </summary>
        Unrecongnized = 1024,
        /// <summary>
        /// Command cannot execute due authorozation.
        /// </summary>
        UnAuthorized = 2048,
        /// <summary>
        /// All states flag.
        /// </summary>
        AllStates = 65535,
    }
    #endregion

    #region OperationState
    [Flags()]
    public enum OperationState : uint
    {
        /// <summary>
        /// Default operation state.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// This flag is set as soon as operation enters executing state.
        /// </summary>
        Started = 1,
        /// <summary>
        /// This flags the operation completion.
        /// <remarks>This should be only set when operation has fully completed.
        /// </summary>
        Completed = 2,
        /// <summary>
        /// Operation aborted.
        /// </summary>
        Aborted = 16,
        /// <summary>
        /// Operation released.
        /// </summary>
        Released = 32,
        /// <summary>
        /// Operation update.
        /// </summary>
        Update = 128,
        /// <summary>
        /// When calling an execute or update with invalid parameters this flag is used.
        /// </summary>
        InvalidParameters = 512,
        /// <summary>
        /// This is set when operation is failed in case of critical exception for example.
        /// <remarks>
        /// This state should only be set when operation is fully aborted and cannot recover.
        /// This will also lead to operation completeion when SyncOperation class is used.
        /// In case of recoverable error you can simply send an update to the requesting party or log it.
        /// </remarks>
        /// </summary>
        Failed = 1024,
        /// <summary>
        /// This flag is set when the operation was automatically aborted due disconnection.
        /// </summary>
        ConnectionLostAbort = 2048,
        /// <summary>
        /// Connection changed.
        /// </summary>
        ConnectionChange = 4096,
    }
    #endregion

    #region RequestsType
    public enum RequestsType : byte
    {
        /// <summary>
        /// A new request command.
        /// </summary>
        Request = 0,
        /// <summary>
        /// Response command.
        /// </summary>
        Response = 1,
        /// <summary>
        /// Command state update.
        /// </summary>
        CommandStateUpdate = 2,
        /// <summary>
        /// Encryption negotiation.
        /// </summary>
        NEGEncryption = 3,
        /// <summary>
        /// Operation state update.
        /// </summary>
        OperationStateUpdate = 4,
        /// <summary>
        /// Compression negotiation.
        /// </summary>
        NEGCompression = 5,
        /// <summary>
        /// Protocol negotiation.
        /// </summary>
        NEGProtocol = 6,
        /// <summary>
        /// Authentication negotiation.
        /// </summary>
        NEGAuthenticate = 7,
        /// <summary>
        /// Operation update.
        /// </summary>
        OperationUpdate = 8,
        /// <summary>
        /// Operation abort.
        /// </summary>
        OperationAbort = 16,
        /// <summary>
        /// This state should be set when the operation does not have any completion so the other side would remove it from the operation list.
        /// </summary>
        OperationRelease = 32,
        /// <summary>
        /// Indicates dispatcher pool event.
        /// </summary>
        PoolEvent = 9
    }
    #endregion

    #region CommandType
    /// <summary>
    /// Represents the type of operation.
    /// </summary>
    public enum CommandType : byte
    {
        /// <summary>
        /// File system operation.
        /// </summary>
        [OperationType(typeof(FileOperations))]
        FileSystem = 0,

        /// <summary>
        /// System operation.
        /// </summary>
        [OperationType(typeof(SystemManagement))]
        SystemManagement = 1,

        /// <summary>
        /// Mappings operation.
        /// </summary>
        [OperationType(typeof(MappingsOperations))]
        MappingsManagement = 2,

        /// <summary>
        /// Power management operation.
        /// </summary>
        PowerManagement = 3,

        /// <summary>
        /// Monitoring operation.
        /// </summary>
        [OperationType(typeof(SystemMonitorTypes))]
        SystemMonitoring = 4,

        /// <summary>
        /// Module operation.
        /// </summary>
        [OperationType(typeof(ModuleManagement))]
        ModuleManagement = 5,

        /// <summary>
        /// Input management operation.
        /// </summary>
        InputManagement = 7,

        /// <summary>
        /// Settings operation,
        /// </summary>
        [OperationType(typeof(SettingsManagement))]
        SettingsManagement = 8,

        /// <summary>
        /// Applications operation.
        /// </summary>
        [OperationType(typeof(ApplicationManagement))]
        ApplicationsManagement = 9,

        /// <summary>
        /// Log operation.
        /// </summary>
        [OperationType(typeof(LogManagement))]
        Logging = 10,

        /// <summary>
        /// Benchmarking operation.
        /// </summary>
        [OperationType(typeof(BenchMarkingOperations))]
        BenchMarking = 11,

        /// <summary>
        /// Process operation.
        /// </summary>
        [OperationType(typeof(ProcessOperations))]
        ProcessManagement = 12,

        /// <summary>
        /// Imaging operation.
        /// </summary>
        [OperationType(typeof(ImagingOperations))]
        Imaging = 13,

        /// <summary>
        /// Task operation.
        /// </summary>
        [OperationType(typeof(TaskOperations))]
        TaskManagement = 14,

        /// <summary>
        /// Event operation.
        /// </summary>
        EventNotification = 15,

        /// <summary>
        /// Security operation.
        /// </summary>
        [OperationType(typeof(SecurityOperations))]
        SecurityManagement = 16,

        /// <summary>
        /// User operation.
        /// </summary>
        [OperationType(typeof(UserOperations))]
        UserOperation = 17,

        /// <summary>
        /// User defined operation.
        /// </summary>
        UserDefined = 18,

        /// <summary>
        /// Manager to service operation.
        /// </summary>
        [OperationType(typeof(ManagerToServiceOpType))]
        ManagerToService = 19,

        /// <summary>
        /// Service to manager ooperation.
        /// </summary>
        [OperationType(typeof(ServiceToManagerOpType))]
        ServiceToManager = 20,
    }
    #endregion

    #region ApplicationManagement
    public enum ApplicationManagement : byte
    {
        SetContainer = 1,
        AddApplication = 2,
        RemoveApplication = 3,
        UpdateApplication = 4,
        SetApplicationRating = 5,
        GetApplicationRating = 6,
        SetApplicationStat = 7,
        GetApplicationStat = 8,
        ReserveLicenseBatch = 9,
        ReleaseLicenseBatch = 10,
    }
    #endregion

    #region BenchMarkingOperations
    public enum BenchMarkingOperations
    {
        None = 0
    }
    #endregion

    #region MulticastOperations
    public enum MulticastOperations : byte
    {
        JoinGroup = 0,
        LeaveGroup = 1,
        MulticastRecievePacket = 2,
        SelectStream = 4,
        MulticastPacketReceived = 8,
    }
    #endregion

    #region FileOperations
    /// <summary>
    /// Identifies file system operation.
    /// </summary>
    public enum FileOperations : byte
    {
        MulticastTransfer = 1,
        GetFilesList = 2,
        GetDrivesInfos = 3,
        GetDriveInfo = 4,
        GetDirectoriesList = 5,
        GetFileAttributes = 6,
        GetFileEntries = 7,
        MoveFileOrDirectory = 8,
        GetDiffList = 9,
        CreateStructure = 10,
        ManageStrucutre = 11,
        GetStructure = 12,
        DleteDirectory = 13,
        DeleteFile = 14,
        CreateDirectory = 15,
        DeleteDirectory = 16,
        CloseFile = 18,
        GetBlockHash = 19,
        OpenStream = 20,
        CloseStream = 21,
        WriteStream = 22,
        ReadStream = 23,
        SetStreamLength = 24,
        GetStreamLength = 25,
        SeekStream = 26,
        BaseStreamOperation = 27,
        SetFileTime = 28,
        SetFileAttributes = 29,
        EnumerationContext = 30,
        GetDirectorySize = 31,
        FileExists = 32,
        DirectoryExists = 33,
        Unknown = 0,
    }
    #endregion

    #region MappingsOperations
    public enum MappingsOperations : byte
    {
        ProcessEvent = 0
    }
    #endregion

    #region UserOperations
    public enum UserOperations : byte
    {
        /// <summary>
        /// Get the path for personal user file.
        /// </summary>
        GetProfilePath = 1,
        /// <summary>
        /// Get path for user home directory.
        /// </summary>
        GetHomePath = 2,
        /// <summary>
        /// Get the default profile path.
        /// </summary>
        GetDefaultProfilePath = 3,
        /// <summary>
        /// Gets the image data.
        /// </summary>
        GetImageData = 4,
        /// <summary>
        /// Gets user state.
        /// </summary>
        GetUserState = 5,
        /// <summary>
        /// Sets user state.
        /// </summary>
        SetUserState = 6,
        /// <summary>
        /// Login command.
        /// </summary>
        Login = 7,
        /// <summary>
        /// Logout command.
        /// </summary>
        Logout = 8,
        /// <summary>
        /// Group configuration command.
        /// </summary>
        GetGroupConfiguration = 9,
        /// <summary>
        /// Get user profile information.
        /// </summary>
        GetUserProfile = 10,
        /// <summary>
        /// Set user profile information.
        /// </summary>
        SetUserProfile = 11,
        /// <summary>
        /// Get user avatar.
        /// </summary>
        GetUserAvatar = 12,
        /// <summary>
        /// Set user avatar.
        /// </summary>
        SetUserAvatar = 13,
        /// <summary>
        /// Set user password.
        /// </summary>
        SetUserPassword = 14,
        /// <summary>
        /// Integration providers login operation.
        /// </summary>
        IntegratedLogin = 15,
        /// <summary>
        /// Integration provider logout operation.
        /// </summary>
        IntegratedLogout = 16,
        /// <summary>
        /// UI Notification operation.
        /// </summary>
        UINotify = 17,
    }
    #endregion

    #region ImagingOperations
    public enum ImagingOperations : byte
    {
        GetFileSystemEntryIcon = 1,
    }
    #endregion

    #region ContextEnumerationTypes
    public enum ContextEnumerationTypes
    {
        FindFirst = 1,
        FindNext = 2,
        Close = 3,
    }
    #endregion

    #region StreamOperationTypes
    public enum StreamOperationTypes : byte
    {
        SetLength = 0,
        Seek = 2,
        GetLength = 1,
        GetPosition = 3,
        Flush = 4,
    }
    #endregion

    #region SystemMonitorTypes
    public enum SystemMonitorTypes : byte
    {
        Monitor = 1,
        HardDisk = 2,
    }
    #endregion

    #region ModuleManagement
    public enum ModuleManagement : byte
    {
        RestartModule = 0,
        ShutDownModule = 1,
        GetModuleInfo = 2,
        UpdateModule = 3,
    }
    #endregion

    #region SettingsManagement
    public enum SettingsManagement : byte
    {
        SetSettings = 0,
        UpdateSettings = 1,
        GetConnectionSettings = 2,
        SetHostId = 3,
        SetReady = 4,
        LoadPlugins = 5,
        DenyConnection = 6,
        SetNewsFeedList = 7,
        SetAppProfileList = 8,
        SetSecurityProfileList = 9,
        NotifyGroupChange = 10,
    }
    #endregion

    #region LogManagement
    public enum LogManagement : byte
    {
        AddLogMessage = 0,
    }
    #endregion

    #region SystemManagement
    public enum SystemManagement : byte
    {
        GetComputerName = 0,
        SetVariables = 1,
        GetVariables = 2,
        SetRegistryString = 3,
        GetRegistryString = 4,
        GetResourceIcon = 5,
        ManageInput = 6,
        GetInputLockState = 8,
        SetComputerName = 9,
        GetOsInfo = 10,
        GetMacAddress = 11,
        SetOutOfOrderState = 12,
        GetOutOfOrderState = 13,
    }
    #endregion

    #region ProcessOperations
    public enum ProcessOperations : byte
    {
        KillProcess = 1,
        StartProcess = 2,
        PauseProcess = 3,
        ListProcess = 4,
        ListProcessById = 5,
        GetProcessModuleInfo = 6,
    }
    #endregion

    #region TaskOperations
    public enum TaskOperations : byte
    {
        Execute,
    }
    #endregion

    #region SecurityOperations
    public enum SecurityOperations : byte
    {
        SetState = 0,
        GetState = 2,
        SetActiveProfile = 3,
        SetSecurityList = 4,
    }
    #endregion

    #region ManagerToServiceOpType
    /// <summary>
    /// Service operations on manager behalf.
    /// </summary>
    public enum ManagerToServiceOpType : int
    {
        LogGet,
        LogGetById,
        LogAdd,
        LogRemove,

        HostGet,
        HostAdd,
        HostUpdate,
        HostRemove,
        HostPropertiesGet,
        HostPropertiesSet,
        HostPowerStateSet,
        HostModuleStateSet,
        HostLockStateSet,
        HostOrderStateSet,
        HostSecurityStateSet,
        HostByDispatcherGet,

        #region USERGROUP
        UserGroupGet,
        UserGroupAdd,
        UserGroupUpdate,
        UserGroupRemove, 
        #endregion

        #region SECURITY PROFILE
        SecurityProfileGet,
        SecurityProfileAdd,
        SecurityProfileUpdate,
        SecurityProfileRemove, 
        #endregion

        #region APPCATEGORY
        AppCategoryGet,
        AppCategoryAdd,
        AppCategoryUpdate,
        AppCategoryRemove, 
        AppCategoryMove,
        #endregion

        #region APP ENTERPRISE
        AppEnterpriseGet,
        AppEnterpriseAdd,
        AppEnterpriseUpdate,
        AppEnterpriseRemove, 
        #endregion

        #region APP
        AppGet,
        AppGetGraph,
        AppAdd,
        AppUpdate,
        AppRemove,
        AppGetImage,
        AppMove,
        AppRename, 
        #endregion

        #region DEPLOYMENT
        DeploymentGet,
        DeploymentAdd,
        DeploymentUpdate,
        DeploymentRemove, 
        DeploymentGetDependentApp,
        #endregion

        #region PERSONAL FILE
        PersonalFileGet,
        PersonalFileAdd,
        PersonalFileUpdate,
        PersonalFileRemove, 
        PersonalFileGetDependentApp,
        #endregion

        #region LICENSE
        LicenseGet,
        LicenseAdd,
        LicenseUpdate,
        LicenseRemove, 
        LicenseGetDependentApp,
        #endregion

        #region APPGROUP
        AppGroupGet,
        AppGroupAdd,
        AppGroupUpdate,
        AppGroupRemove, 
        #endregion

        #region HOSTGROUP
        HostGroupGet,
        HostGroupAdd,
        HostGroupUpdate,
        HostGroupRemove, 
        #endregion

        NewsFeedGet,
        NewsFeedAdd,
        NewsFeedRemove,
        NewsFeedUpdate,

        #region USER
        UserGet,
        UserAdd,
        UserUpdate,
        UserRemove,
        UserRename,
        UserSetPassword,
        UserSetPicture,
        UserGetPicture,
        UserSetEmail,
        UserSetGroup,
        UserLogin,
        UserLogout,
        UserDisable, 
        #endregion

        UserOperatorGet,
        UserOperatorCreate,
        UserOperatorUpdate,
        UserOperatorRemove,
        UserOperatorDelete,

        #region PLUGINLIB
        PluginLibGet = 87787,
        PluginLibUpdate = 124, 
        PluginLibGetFiles,
        #endregion

        #region VARIABLE
        VariableGet = 100,
        VariableAdd = 101,
        VariableUpdate = 102,
        VariableRemove = 103, 
        #endregion

        #region MAPPING
        MappingGet,
        MappingAdd,
        MappingUpdate,
        MappingRemove, 
        #endregion

        ConfigurationGet,
        ConfigurationSet,

        LanguageGet,
        IntegrationProvidersGet,
        SkinGet,
        SystemLicenseGet,

        SessionGet,

        TaskGet,
        TaskAdd,
        TaskRemove,
        TaskUpdate,

        ClientTaskGet,
        ClientTaskAdd,
        ClientTaskRemove,
        ClientTaskUpdate,

        AppExeTaskGet,
        AppExeTaskAdd,
        AppExeTaskRemove,
        AppExeTaskUpdate,

    }
    #endregion

    #region ServiceToManagerOpType
    /// <summary>
    /// Manager operations on service behalf.
    /// </summary>
    public enum ServiceToManagerOpType : byte
    {
        HostEvent = 0,
        HostPropertiesEvent = 1,
        LicenseReservationEvent = 2,
        UserChangeEvent = 3,
        UserStateChangeEvent = 4,
        LogChangedEvent = 5
    }
    #endregion

    #region OperationTypeAttribute
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class OperationTypeAttribute : Attribute
    {
        public OperationTypeAttribute(Type operationEnum)
        {
            this.OperationEnum = operationEnum;
        }

        /// <summary>
        /// Gets operation enum.
        /// </summary>
        public Type OperationEnum
        {
            get;
            private set;
        }
    }
    #endregion
}

