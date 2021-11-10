using System;

namespace SharedLib.Commands
{
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

        [OperationType(typeof(ServiceToClientOpType))]
        ServiceToClinet = 21,

        [OperationType(typeof(EnvironmentOprations))]
        Environment = 22,
    }
    #endregion

    #region ApplicationManagement
    public enum ApplicationManagement : byte
    {
        SetContainer = 1,
        UpdateApplication = 4,
        SetApplicationRating = 5,
        GetApplicationRating = 6,
        SetApplicationStat = 7,
        GetApplicationStat = 8,
        ReserveLicenseBatch = 9,
        ReleaseLicenseBatch = 10,
        GetAppContainer = 11,
        GetAppInfoContainer = 12,
        GetAppInfoUserContainer = 13,
        GetNewsContainer = 3,
        AppEvent = 14,
        AppExeExecutionGraphGet = 15,
        AppExePersonalFileGet = 16,
        AppExePersonalFilePathsGet = 17,
        AppExePersonalFileByActivationGet = 21,
        AppExeDeploymentPathsGet = 18,
        AppLinkGet = 2,
        DeploymentGet = 19,
        PersonalFileGet = 20,
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
        Unknown = 0,
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
        BaseStreamOperation = 26,
        SetFileTime = 28,
        SetFileAttributes = 29,
        EnumerationContext = 30,
        GetDirectorySize = 31,
        FileExists = 32,
        DirectoryExists = 33,
        JunctionCreate = 34,
        JunctionDelete = 35,
        JunctionExist = 36,
        //free id 24,25,27,17
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
        [Obsolete()]
        IntegratedLogout = 16,
        /// <summary>
        /// UI Notification operation.
        /// </summary>
        UINotify = 17,
        /// <summary>
        /// Usage session info get operation.
        /// </summary>
        GetUsageSessionInfo = 18,
        /// <summary>
        /// Get image hash operation.
        /// </summary>
        GetImageHash = 19,
        /// <summary>
        /// Get ordering data.
        /// </summary>
        GetOrderingData = 20,
        /// <summary>
        /// Create orderd.
        /// </summary>
        ProductOrderCreate = 21,
        /// <summary>
        /// Get user balance.
        /// </summary>
        UserBalanceGet = 22,
        /// <summary>
        /// Passes product oder.
        /// </summary>
        ProductOrderPass = 23,
        TokenVerify = 24,
        AccountCreateByMobilePhoneStart = 25,
        AccountCreateByEmailStart = 26,
        AccountCreateByTokenComplete = 27,
        AccountCreateComplete = 32,
        UsernameExist = 28,
        UserEmailExist = 29,
        EmailVerificationStateInfoGet = 30,
        MobilePhoneVerificationStateInfoGet = 31,
        ReservationDataGet = 33,
        UserGroupDefaultRequiredInfoGet = 34,
        AgreementGet = 35,
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
        SetMaintenanceMode = 14,
        GetMaintenanceMode = 15,
        RDPSessionStart = 16,
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
        GetSystemTimes = 7
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
    public enum ManagerToServiceOpType
    {
        #region LOG
        LogGet = 0,
        LogGetById = 1,
        LogAdd = 2,
        LogRemove = 3,
        #endregion

        #region HOST
        HostGet = 4,
        HostAdd = 5,
        HostUpdate = 6,
        HostRemove = 7,
        HostPropertiesGet = 8,
        HostPropertiesSet = 9,
        HostPowerStateSet = 10,
        HostModuleStateSet = 11,
        HostLockStateSet = 12,
        HostOrderStateSet = 13,
        HostSecurityStateSet = 14,
        HostMaintenanceStateSet = 15,
        HostEndpointTurnOn = 253,
        HostEndpointTurnOff = 254,
        #endregion

        #region USERGROUP
        UserGroupGet = 16,
        UserGroupAdd = 17,
        UserGroupUpdate = 18,
        UserGroupRemove = 19,
        UserGroupHostDisallowedGet = 268,
        #endregion

        #region SECURITY PROFILE
        SecurityProfileGet = 20,
        SecurityProfileAdd = 21,
        SecurityProfileUpdate = 22,
        SecurityProfileRemove = 23,
        #endregion

        #region APPCATEGORY
        AppCategoryGet = 24,
        AppCategoryAdd = 25,
        AppCategoryUpdate = 26,
        AppCategoryRemove = 27,
        AppCategoryMove = 28,
        #endregion

        #region APP ENTERPRISE
        AppEnterpriseGet = 29,
        AppEnterpriseAdd = 30,
        AppEnterpriseUpdate = 31,
        AppEnterpriseRemove = 32,
        #endregion

        #region APP
        AppGet = 33,
        AppGetWithoutExe = 34,
        AppExeGetWithDeployment = 35,
        AppGetByUsage = 36,
        AppGetGraph = 37,
        AppAdd = 38,
        AppUpdate = 39,
        AppRemove = 40,
        AppGetImage = 41,
        AppMove = 42,
        AppRename = 43,
        #endregion

        #region APPSTAT
        AppStatGet = 44,
        #endregion

        #region DEPLOYMENT
        DeploymentGet = 45,
        DeploymentAdd = 46,
        DeploymentUpdate = 47,
        DeploymentRemove = 48,
        DeploymentGetDependentApp = 49,
        DeploymentGetByAppExe = 50,
        #endregion

        #region PERSONAL FILE
        PersonalFileGet = 51,
        PersonalFileAdd = 52,
        PersonalFileUpdate = 53,
        PersonalFileRemove = 54,
        PersonalFileGetDependentApp = 55,
        #endregion

        #region LICENSE
        LicenseGet = 56,
        LicenseAdd = 57,
        LicenseUpdate = 58,
        LicenseRemove = 59,
        LicenseGetDependentApp = 60,
        #endregion

        #region APPGROUP
        AppGroupGet = 61,
        AppGroupAdd = 62,
        AppGroupUpdate = 63,
        AppGroupRemove = 64,
        #endregion

        #region HOSTGROUP
        HostGroupGet = 65,
        HostGroupAdd = 66,
        HostGroupUpdate = 67,
        HostGroupRemove = 68,
        #endregion

        #region HOSTLAYOUTGROUP
        HostLayoutGroupGet = 69,
        HostLayoutGroupAdd = 70,
        HostLayoutGroupUpdate = 71,
        HostLayoutGroupRemove = 72,
        HostLayoutGroupImageSet = 73,
        HostLayoutGroupImageGet = 74,
        #endregion

        #region NEWS
        NewsFeedGet = 75,
        NewsFeedAdd = 76,
        NewsFeedRemove = 77,
        NewsFeedUpdate = 78,
        #endregion

        #region FEED
        FeedGet = 79,
        FeedAdd = 80,
        FeedUpdate = 81,
        FeeedRemove = 82,
        #endregion

        #region SESSION
        UserLoginSessionInfoGet = 269,
        UserSessionGet = 83,
        UserSessionInfoGet = 174,
        UserSessionOpenInfoGet = 219,
        UsageSessionActiveInfoGet = 259,
        #endregion

        #region USER

        UserGet = 84,
        UserAdd = 85,
        UserUpdate = 86,
        UserRemove = 87,
        UserDelete = 88,
        UserUndelete = 89,
        UserRename = 90,
        UserSetPassword = 91,
        UserSetPicture = 92,
        UserGetPicture = 93,
        UserSetEmail = 94,
        UserSetGroup = 95,
        UserCredentialsValidate = 96,
        UserNegativeBalanceEnable = 97,
        UserLogin = 98,
        UserGuestLogin = 215,
        UserMove = 218,
        UserLogout = 99,
        UserDisable = 100,
        UserSetSmartCardId = 101,
        UserPersonalInfoRequest = 247,
        UserGuestReserve = 220,
        UserBillingOptionSet = 260,

        #endregion

        #region USER NOTE

        UserNoteGet = 102,
        UserNoteAdd = 103,
        UserNoteUpdate = 104,
        UserNoteRemove = 105,

        #endregion

        #region USER OPERATOR
        UserOperatorGet = 106,
        UserOperatorCreate = 107,
        UserOperatorUpdate = 108,
        UserOperatorRemove = 109,
        UserOperatorDelete = 110,
        UserOperatorSetPassword = 111,
        #endregion

        #region PLUGINLIB
        PluginLibGet = 112,
        PluginLibUpdate = 113,
        PluginLibGetFiles = 114,
        #endregion

        #region VARIABLE
        VariableGet = 115,
        VariableAdd = 116,
        VariableUpdate = 117,
        VariableRemove = 118,
        #endregion

        #region MAPPING
        MappingGet = 119,
        MappingAdd = 120,
        MappingUpdate = 121,
        MappingRemove = 122,
        #endregion

        #region ICON
        IconGet = 123,
        IconAdd = 124,
        IconUpdate = 125,
        IconRemove = 126,
        #endregion

        #region CONFIGURATION
        ConfigurationGet = 127,
        ConfigurationSet = 128,
        LanguageGet = 129,
        SkinGet = 130,
        SystemLicenseGet = 131,
        SystemLicenseGetV2 = 286,
        #endregion        

        #region TASK
        TaskGet = 132,
        TaskGetById = 133,
        TaskAdd = 134,
        TaskRemove = 135,
        TaskUpdate = 136,
        #endregion

        #region CLIENT TASK
        ClientTaskGet = 137,
        ClientTaskAdd = 138,
        ClientTaskRemove = 139,
        ClientTaskUpdate = 140,
        #endregion

        #region APP EXE TASK
        AppExeTaskGet = 141,
        AppExeTaskAdd = 142,
        AppExeTaskRemove = 143,
        AppExeTaskUpdate = 144,
        #endregion

        #region MONETARY UNIT
        MonetaryUnitAdd = 145,
        MonetaryUnitUpdate = 146,
        MonetratyUnitRemove = 147,
        MonetraryUnitGet = 148,
        #endregion

        #region TAX
        TaxGet = 149,
        TaxAdd = 150,
        TaxUpdate = 151,
        TaxRemove = 152,
        #endregion

        #region PRODUCT GROUP
        ProductGroupGet = 153,
        ProductGroupAdd = 154,
        ProductGroupUpdate = 155,
        ProductGroupRemove = 156,
        #endregion

        #region PRODUCT
        ProductGet = 157,
        ProductGetBasic = 158,
        ProductAdd = 159,
        ProductUpdate = 160,
        ProductUpdateBasic = 161,
        ProductPrioritySet = 217,
        #endregion

        #region BILL PROFILE
        BillProfileGet = 162,
        BillProfileAdd = 163,
        BillPorfileUpdate = 164,
        BillProfileRemove = 165,
        #endregion

        #region PAYMENT METHOD
        PaymentMethodGet = 166,
        PaymentMethodAdd = 167,
        PaymentMethodUpdate = 168,
        PaymentMethodRemove = 169,
        #endregion

        #region USER BALANCE
        UserBalanceGet = 170,
        UserGetMoneyForTime = 171,
        UserGetTimeForMoney = 172,
        UserProductTimeGet = 173,
        UserCloseBalance = 175,
        #endregion

        #region USAGE SESSION
        UsageSessionInvoiceActive = 176,
        #endregion

        #region DEPOSIT
        DepositTransactionGet = 177,
        DepositBalanceGet = 178,
        DepositAdd = 179,
        DepositWithdraw = 180,
        DepositPaymentGet = 181,
        DepositTransactionInfoGet = 271,
        #endregion

        #region POINTS
        PointsGetBalance = 182,
        #endregion

        #region STOCK
        StockTransactionGet = 183,
        StockAdd = 184,
        StockRemove = 185,
        StockSet = 186,
        StockGet = 187,
        StockLogicalGet = 216,
        #endregion

        #region PRODUCT ORDER
        ProductOrderGet = 188,
        ProductOrderOpenInfoGet = 273,
        ProductOrderCancel = 189,
        ProductOrderInvoice = 190,
        ProductOrderAccept = 270,
        ProductOrderComplete = 272,
        ProductOrderLineUpdateState = 274,
        #endregion

        #region INVOICE
        InvoiceGet = 191,
        InvoicePaymentAdd = 192,
        InvoicePaymentGet = 193,
        InvoiceVoid = 258,
        InvoiceRefundGet = 287,
        #endregion

        #region SETTING
        SettingGet = 194,
        SettingSet = 195,
        #endregion

        #region ATTRIBUTE
        AttributeGet = 196,
        AttributeAdd = 197,
        AttributeUpdate = 198,
        AttributeRemove = 199,
        #endregion

        #region USER ATTRIBUTE
        UserAttributeGet = 200,
        UserAttributeGetValue = 201,
        UserAttributeSetValue = 202,
        UserAttributeRemove = 203,
        #endregion

        #region PRESET TIME SALE
        PresetTimeSaleGet = 205,
        PresetTimeSaleAdd = 206,
        PresetTimeSaleUpdate = 207,
        PresetTimeSaleRemove = 208,
        #endregion

        #region PRESET TIME MONEY
        PresetTimeSaleMoneyGet = 209,
        PresetTimeSaleMoneyAdd = 210,
        PresetTimeSaleMoneyUpdate = 211,
        PresetTimeSaleMoneyRemove = 212,
        #endregion

        #region ENTITIES
        EntityMarkDeleted = 204,
        EntityCount = 213,
        #endregion

        #region SHIFT

        ShiftStart = 221,
        ShiftEnd = 222,
        ShiftGetActiveRegister = 224,
        ShiftGetActive = 225,
        ShiftLock = 228,
        ShiftUnlock = 229,
        ShiftInfoGet = 234,

        #endregion

        #region REGISTER
        RegisterGet = 230,
        RegisterAdd = 231,
        RegisterUpdate = 232,
        RegisterGetCurrent = 226,
        #endregion

        #region REPORTS

        ShiftSummaryGet = 227,
        ShiftReportGet = 235,
        SaleSummaryReportGet = 236,
        SaleReportGet = 255,
        UserGeneralReportGet = 275,

        #endregion

        WakeOnLan = 237,
        ManagerModuleInfoGet = 214,
        ClientModuleInfoGet = 281,
        ServerModuleInfoGet = 282,

        #region ASSETS 

        AssetTypeAdd = 238,
        AssetTypeUpdate = 239,
        AssetTypeRemove = 240,
        AssetTypeGet = 246,

        AssetGet = 252,
        AssetAdd = 241,
        AssetUpdate = 242,
        AssetRemove = 243,

        AssetCheckIn = 244,
        AssetCheckInByUser = 250,
        AssetCheckOut = 245,
        AssetInfoGet = 249,
        AssetCheckoutInfoGet = 283,

        AssetTransactionGet = 248,

        #endregion

        LicenseReservationGet = 256,
        LicenseKeyReservationInfoGet = 257,

        #region WAITING LINE

        WaitingLineMoveTo = 261,
        WaitingLineAdd = 262,
        WaitingLineRemove = 263,
        WaitingLineInfoGet = 264,
        WaitngLineGet = 265,
        WaitingLineAddOrUpdate = 266,
        WaitingLinePrioritiesSet = 267,

        #endregion

        ReservationAdd = 276,
        ReservationStatusSet = 277,
        ReservationInfoGet = 278,
        ReservationGet = 279,
        ReservationUpdate = 280,

        RegisterTransactionInfoGet = 284,
        RegisterTransactionAdd = 285,
        

        DeviceCreate = 288,
        DeviceUpdate = 299,
        DeviceGet = 300,
        DeviceHostGet = 301,
        DeviceHostAdd = 302,
        DeviceHostRemove = 303,
        DeviceDelete = 304,
        DeviceUndelete = 305,
        DeviceEnable = 306,
        DeviceDisable = 307,

        //max 307
    }
    #endregion

    #region ServiceToManagerOpType
    /// <summary>
    /// Manager operations on service behalf.
    /// </summary>
    public enum ServiceToManagerOpType
    {
        HostEvent = 0,
        HostPropertiesEvent = 1,
        LicenseReservationEvent = 2,
        UserChangeEvent = 3,
        UserStateChangeEvent = 4,
        LogChangedEvent = 6,
        EntityEvent = 7,
        UserBalanceEvent = 8,
        UserSessionChangeEvent = 9,
        EventBatch = 10,
        UsageSessionEvent = 11,
    }
    #endregion

    #region ServiceToClient
    public enum ServiceToClientOpType
    {
        UserBalanceEvent = 0,
        EntityEvent = 1,
        EventBatch = 2,
        ReservationChange = 3,
    }
    #endregion

    #region EnvironmentOprations
    public enum EnvironmentOprations
    {
        Expand = 0,
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

