using GizmoDALV2;
using System;
using System.Threading.Tasks;

namespace ServerService
{
    /// <summary>
    /// Async user service.
    /// </summary>
    public interface IUserServiceAsync : IUserService
    {
        #region FUNCTIONS

        /// <summary>
        /// Checks if user credentials are valid.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">Password </param>
        /// <returns>Associated task.</returns>
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
        Task<bool> UserCredentialsValidAsync(string username, string password);

        /// <summary>
        /// Checks if user credentials are valid.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="password">Password.</param>
        /// <returns>Associated task.</returns>
        /// <exception cref="EntityNotFoundException">
        /// Thrown if no user with specified <paramref name="userId"/> found.
        /// </exception>
        /// <remarks>
        /// If user has no credentials set false is returned.
        /// If credentials password value is null and specified <paramref name="password"/> is null then true is returned.
        /// </remarks>
        Task<bool> UserCredentialsValidAsync(int userId, string password);

        #endregion
    }
}
