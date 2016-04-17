using IntegrationLib;
using ServerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GizmoDALV2;

namespace ServerService
{
    #region IUserService
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
        /// Occurs on user session change.
        /// </summary>
        event EventHandler<UserSessionChangedEventArgs> UserSessionChange;

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
        /// <exception cref="UserNotFoundException">
        /// Thrown if no user with specified <paramref name="username"/> found.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <typeparamref name="username"/> value is null or empty.
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
        /// <exception cref="UserNotFoundException">
        /// Thrown if no user with specified <paramref name="userId"/> found.
        /// </exception>
        /// <remarks>
        /// If user has no credentials set false is returned.
        /// If credentials password value is null and specified <paramref name="password"/> is null then true is returned.
        /// </remarks>
        bool UserCredentialsValid(int userId, string password);

        #endregion
    }
    #endregion

    #region IUserServiceAsync
    public interface IUserServiceAsync : IUserService
    {
        #region FUNCTIONS

        /// <summary>
        /// Checks if user credentials are valid.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">Password </param>
        /// <returns>Associated task.</returns>
        /// <exception cref="EntityNotFoundExcpetion">
        /// Thrown if no user with specified <paramref name="username"/> found.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <typeparamref name="username"/> value is null or empty.
        /// </exception>
        /// <remarks>
        /// If user has no credentials set false is returned.
        /// If credentials password value is null and specified <paramref name="password"/> is null then true is returned.
        /// </remarks>
        Task<bool> UserCredentialsValidAsync(string username, string password);

        /// <summary>
        /// Checks if user credentials are valid.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="password">Password.</param>
        /// <returns>Associated task.</returns>
        /// <exception cref="EntityNotFoundExcpetion">
        /// Thrown if no user with specified <paramref name="userId"/> found.
        /// </exception>
        /// <remarks>
        /// If user has no credentials set false is returned.
        /// If credentials password value is null and specified <paramref name="password"/> is null then true is returned.
        /// </remarks>
        Task<bool> UserCredentialsValidAsync(int userId, string password);

        #endregion
    } 
    #endregion
}
