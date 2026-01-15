using System;

namespace IntegrationLib
{
    /// <summary>
    /// Logout result.
    /// </summary>
    [Flags()]
    public enum LogoutResult
    {
        /// <summary>
        /// Logout was successful.
        /// </summary>
        Success = 0,
        /// <summary>
        /// User is not logged in.
        /// </summary>
        NotLoggedIn = 1,
        /// <summary>
        /// Logout occurred locally.
        /// </summary>
        LoggedOutLocally = 2,
        /// <summary>
        /// Invalid user id.
        /// </summary>
        InvalidUserId = 2048,
        /// <summary>
        /// Logout failed.
        /// </summary>
        Failed = 4,
    }
}
