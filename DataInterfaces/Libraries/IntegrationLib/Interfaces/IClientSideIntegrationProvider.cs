using Client;
using SharedLib.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntegrationLib
{
    #region IClientSideIntegrationProvider
    /// <summary>
    /// Base provider interface for the client side management software integration.
    /// </summary>
    public interface IClientSideIntegrationProvider : IIntegrationProvider, ILoginProvider
    {
        /// <summary>
        /// Gets the Client instance.
        /// </summary>
        IClient Client { get; }

        /// <summary>
        /// Set the given user info for current user.
        /// </summary>
        /// <param name="profile">User Profile.</param>
        void SetUserInfo(IUserProfile profile);

        /// <summary>
        /// Sets the given password for current user.
        /// </summary>
        /// <param name="password">Password string.</param>
        void SetUserPassword(string password);

        /// <summary>
        /// Gets a new instance of user profile to be used with this provider.
        /// </summary>
        /// <returns>IUserProfile implemented class instance.</returns>
        IUserProfile GetProfileInstance();

        /// <summary>
        /// Initiates maintenance mode.
        /// </summary>
        /// <returns>True or False.</returns>
        bool EnableMaintenanceMode();
    }
    #endregion
}
