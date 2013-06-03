using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntegrationLib
{
    #region SmartlaunchFileConnectionStates
    public enum SmartlaunchFileConnectionStates : int
    {
        Waiting = 0,
        Done = 1,
        Failed_FileNotFound = -1,
        Failed_Disconnected = -2,
        Failed_Cancelled = -3,
        Failed_Error = -4
    }
    #endregion

    #region SmartlaunchConnectionTypes
    public enum SmartlaunchConnectionTypes : int
    {
        ClientToServer = 1,
        ServerToClient = 2,
        None = 3
    }
    #endregion

    #region SmartlaunchRelativePaths
    public enum SmartlaunchRelativePaths : int
    {
        None = 0,
        Server = 1,
        Data = 2,
        Users = 3,
        PersonalUserFiles = 4,
        Licenses = 5
    }
    #endregion

    #region SmartlaunchModules
    public enum SmartlaunchModules : int
    {
        Client = 1,
        Administrator = 2,
        External = 3,
        FileTransfer = 4
    }
    #endregion       

    #region LoginResult
    [Flags()]
    public enum SmartlaunchLoginResult : int
    {
        Sucess = 0,
        RequiredInfo = 1,
        AccountLocked = 2,
        WrongPassword = 4,
        AlreadyLoggedIn = 8,
        NotInWaitingLine = 16,
        UsernameNotFound = 32,
        NoConnection = 64,
        CreditLimitReached = 128,
        UsersUsergroupNotAllowed = 256,
        FingerprintNotRecognized = 512,
        OutOfOrder = 1024,
        AccountBanned = 2048,
        InUseBySLDirect = 4096,
        LoginInProgress = 8192,
        TimedOut = 16384,
        Failure = 65536
    }
    #endregion

    #region LoginResult
    [Flags()]
    public enum LoginResult
    {
        /// <summary>
        /// Authentication was sucessfull.
        /// </summary>
        Sucess = 0,
        /// <summary>
        /// Account is disabled.
        /// </summary>
        AccountDisabled = 2,
        /// <summary>
        /// Username is invalid.
        /// </summary>
        InvalidUserName = 4,
        /// <summary>
        /// Password is invalid.
        /// </summary>
        InvalidPassword = 8,
        /// <summary>
        /// Generic error.
        /// </summary>
        Failed = 16,
        /// <summary>
        /// Login was denied.
        /// </summary>
        Denied = 32,
        /// <summary>
        /// Function timed out.
        /// </summary>
        TimedOut = 64,
        /// <summary>
        /// Login function cannot be executed.
        /// </summary>
        CantExecute = 128,
        /// <summary>
        /// User already logged in.
        /// </summary>
        AlreadyLoggedIn = 256,
        /// <summary>
        /// Login is already in progress.
        /// </summary>
        LoginInProgress = 512,
        /// <summary>
        /// Credentials pair is invalid.
        /// </summary>
        InvalidCredentials = InvalidPassword | InvalidUserName,
    }
    #endregion

    #region LogoutResult
    [Flags()]
    public enum LogoutResult
    {
        /// <summary>
        /// Logout was sucessfull.
        /// </summary>
        Sucess = 0,
        /// <summary>
        /// User is not logged in.
        /// </summary>
        NotLoggedIn = 1,
        /// <summary>
        /// Loggout occurred locally.
        /// </summary>
        LoggedOutLocally = 2,
    }
    #endregion    
}
