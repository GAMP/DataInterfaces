using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedLib.User;
using Client;
using System.Threading;
using SharedLib;

namespace IntegrationLib
{   
    #region ILoginProvider
    /// <summary>
    /// Login provider interface.
    /// </summary>
    public interface ILoginProvider
    {
        /// <summary>
        /// Occours when user login state is changed.
        /// </summary>
        event LoginStateChanagedDelegate LoginStateChanaged;

        /// <summary>
        /// Initiates user login synchronosly.
        /// </summary>
        /// <param name="userName">Username.</param>
        /// <param name="password">Password.</param>
        LoginResult Login(string userName, string password);

        /// <summary>
        /// Initiates logout synchronosly.
        /// </summary>
        void Logout();

        /// <summary>
        /// Gets the instance of the logged in user.
        /// </summary>
        IUserProfile CurrentUser { get; }

        /// <summary>
        /// Gets the current login state.
        /// </summary>
        LoginState CurrentState { get; }
    } 
    #endregion   
 }
