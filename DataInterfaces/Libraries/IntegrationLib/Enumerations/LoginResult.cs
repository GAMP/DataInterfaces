using System;

namespace IntegrationLib
{
    /// <summary>
    /// User login result.
    /// </summary>
    [Flags()]
    public enum LoginResult
    {
        /// <summary>
        /// Login was sucessfull.
        /// </summary>
        [Localization.Localized("LOGIN_RESULT_SUCESS")]
        Sucess = 0,
        /// <summary>
        /// Invalid parameters specified.
        /// </summary>
        [Localization.Localized("LOGIN_RESULT_INVALID_PARAMETERS")]
        InvalidParameters = 1,
        /// <summary>
        /// Account is disabled.
        /// </summary>
        [Localization.Localized("LOGIN_RESULT_ACCOUNT_DISABLED")]
        AccountDisabled = 2,
        /// <summary>
        /// Username is invalid.
        /// </summary>
        [Localization.Localized("LOGIN_RESULT_INVALID_USERNAME")]
        InvalidUserName = 4,
        /// <summary>
        /// Password is invalid.
        /// </summary>
        [Localization.Localized("LOGIN_RESULT_INVALID_PASSWORD")]
        InvalidPassword = 8,
        /// <summary>
        /// Generic internal error.
        /// </summary>
        [Localization.Localized("LOGIN_RESULT_FAILED")]
        Failed = 16,
        /// <summary>
        /// Login was denied.
        /// </summary>
        [Localization.Localized("LOGIN_RESULT_DENIED")]
        Denied = 32,
        /// <summary>
        /// Function timed out.
        /// </summary>
        [Obsolete()]
        [Localization.Localized("LOGIN_RESULT_TIMED_OUT")]
        TimedOut = 64,
        /// <summary>
        /// Login function cannot be executed.
        /// </summary>
        [Obsolete()]
        [Localization.Localized("LOGIN_RESULT_CANT_EXECUTE")]
        CantExecute = 128,
        /// <summary>
        /// User already logged in.
        /// </summary>
        [Localization.Localized("LOGIN_RESULT_ALREADY_LOGGED_IN")]
        AlreadyLoggedIn = 256,
        /// <summary>
        /// Login in progress.
        /// </summary>
        [Localization.Localized("LOGIN_RESULT_IN_PROGRESS")]
        LoginInProgress = 512,
        /// <summary>
        /// Logout in progress.
        /// </summary>
        [Localization.Localized("LOGIN_RESULT_IN_PROGRESS")]
        LogoutInProgress = 1024,
        /// <summary>
        /// Invalid user id.
        /// </summary>
        [Localization.Localized("LOGIN_RESULT_INVALID_USER")]
        InvalidUserId = 2048,
        /// <summary>
        /// Invalid host id.
        /// </summary>
        [Localization.Localized("LOGIN_RESULT_INVALID_HOST")]
        InvalidHostId = 4096,
        /// <summary>
        /// Maximum sessions reached.
        /// </summary>
        [Localization.Localized("LOGIN_RESULT_MAX_SESSIONS_REACHED")]
        MaximumSessionsReached = 8192,
        /// <summary>
        /// Insufficient balance.
        /// </summary>
        [Localization.Localized("LOGIN_RESULT_INSUFFICIENT_BALANCE")]
        InsufficientBalance = 16384,
        /// <summary>
        /// Invalid user group was specified for login.
        /// </summary>
        [Localization.Localized("LOGIN_RESULT_INVALID_USER_GROUP")]
        InvalidUserGroupId = 32768,
        /// <summary>
        /// Slot in use.
        /// </summary>
        [Localization.Localized("LOGIN_RESULT_SLOT_IN_USE")]
        SlotInUse = 65536,
        /// <summary>
        /// Slot invalid.
        /// </summary>
        [Localization.Localized("LOGIN_RESULT_SLOT_INVALID")]
        SlotInvalid = 131072,
        /// <summary>
        /// Not in waiting line.
        /// </summary>
        [Localization.Localized("LOGIN_RESULT_NOT_IN_WAITING_LINE")]
        NotInWaitingLine = 262144,
        /// <summary>
        /// Credentials pair is invalid.
        /// </summary>
        [Localization.Localized("LOGIN_RESULT_INVALID_CREDENTIALS")]
        InvalidCredentials = InvalidPassword | InvalidUserName,
        /// <summary>
        /// User group use not allowed for the operator.
        /// </summary>
        [Localization.Localized("LOGIN_RESULT_OPERATOR_USER_GROUP_DENIED")]
        OperatorUserGroupDenied = 524288,
    }
}
