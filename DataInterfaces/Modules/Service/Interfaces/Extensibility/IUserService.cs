using GizmoDALV2;
using IntegrationLib;
using System;

namespace ServerService
{
    /// <summary>
    /// User related functionality interface.
    /// </summary>
    public interface IUserService
    {
        #region EVENTS

        /// <summary>
        /// Occurs on user state change.
        /// </summary>
        event EventHandler<UserStateChangeEventArgs> UserStateChange;

        /// <summary>
        /// Occurs on user state change completed.
        /// </summary>
        event EventHandler<UserStateChangeEventArgs> UserStateChangeCompleted;

        /// <summary>
        /// Occurs on user profile change.
        /// </summary>
        event EventHandler<UserProfileChangeEventArgs> UserProfileChange;

        /// <summary>
        /// Occurs on user balance change.
        /// </summary>
        event EventHandler<UserBalanceEventArgs> UserBalanceChange;

        /// <summary>
        /// Occurs on user session change.
        /// </summary>
        event EventHandler<UserSessionChangedEventArgs> UserSessionChange;

        /// <summary>
        /// Occurs on user balance close.
        /// </summary>
        event EventHandler<UserBalanceCloseEventArgs> UserBalanceClose;

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Logins specified user.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="hostId"></param>
        /// <returns>Login result.</returns>
        LoginResult UserLogin(int userId, int hostId);

        /// <summary>
        /// Logs out specified user.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <returns>Logout result.</returns>
        LogoutResult UserLogout(int userId);

        /// <summary>
        /// Checks if user credentials are valid.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">Password </param>
        /// <returns>True if valid otherwise false.</returns>
        /// <exception cref="EntityNotFoundException">
        /// Thrown if no user with specified <paramref name="username"/> found.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="username"/> value is null or empty.
        /// </exception>
        /// <remarks>
        /// If user has no credentials set false is returned.
        /// If credentials password value is null and specified <paramref name="password"/> is null then true is returned.
        /// </remarks>
        bool UserCredentialsValid(string username, string password);

        /// <summary>
        /// Checks if user credentials are valid.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="password">Password.</param>
        /// <returns>True if valid otherwise false.</returns>
        /// <exception cref="EntityNotFoundException">
        /// Thrown if no user with specified <paramref name="userId"/> found.
        /// </exception>
        /// <remarks>
        /// If user has no credentials set false is returned.
        /// If credentials password value is null and specified <paramref name="password"/> is null then true is returned.
        /// </remarks>
        bool UserCredentialsValid(int userId, string password);

        #endregion
    }
}
