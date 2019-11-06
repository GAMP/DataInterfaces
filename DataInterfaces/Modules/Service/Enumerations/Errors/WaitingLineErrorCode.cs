using Localization;

namespace ServerService
{
    /// <summary>
    /// Waiting line error codes.
    /// </summary>
    public enum WaitingLineErrorCode
    {
        /// <summary>
        /// Already in waiting line.
        /// </summary>
        [Localized("WAITING_LINE_ERROR_ALREADY_IN_WAITING_LINE")]
        AlreadyInWaitingLine = 0,
        /// <summary>
        /// Not in waiting line.
        /// </summary>
        [Localized("WAITING_LINE_ERROR_NOT_IN_WAITING_LINE")]
        NotInWaitingLine = 1,
        /// <summary>
        /// Disallowed host group.
        /// </summary>
        [Localized("WAITING_LINE_ERROR_DISALLOWED_HOST_GROUP")]
        DisallowedHostGroup = 2,
        /// <summary>
        /// Not active.
        /// </summary>
        [Localized("WAITING_LINE_ERROR_NOT_ACTIVE")]
        NotActive = 3,
        /// <summary>
        /// Already logged in.
        /// </summary>
        [Localized("WAITING_LINE_ERROR_ALREADY_LOGGED_IN")]
        AlreadyLoggedIn = 4,
    }
}
