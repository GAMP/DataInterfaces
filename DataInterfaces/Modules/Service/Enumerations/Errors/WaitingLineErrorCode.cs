using Localization;

namespace ServerService
{
    #region WaitingLineErrorCode
    public enum WaitingLineErrorCode
    {
        [Localized("WAITING_LINE_ERROR_ALREADY_IN_WAITING_LINE")]
        AlreadyInWaitingLine = 0,
        [Localized("WAITING_LINE_ERROR_NOT_IN_WAITING_LINE")]
        NotInWaitingLine = 1,
        [Localized("WAITING_LINE_ERROR_DISALLOWED_HOST_GROUP")]
        DisallowedHostGroup = 2,
        [Localized("WAITING_LINE_ERROR_NOT_ACTIVE")]
        NotActive = 3,
        [Localized("WAITING_LINE_ERROR_ALREADY_LOGGED_IN")]
        AlreadyLoggedIn = 4,
    }
    #endregion 
}
