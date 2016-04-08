using IntegrationLib;
using ServerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        
        #endregion
    }
    #endregion
}
