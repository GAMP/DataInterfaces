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
