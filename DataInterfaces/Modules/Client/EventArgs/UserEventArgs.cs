using SharedLib.User;
using IntegrationLib;
using SharedLib;
using System;

namespace Client
{
    /// <summary>
    ///User event arguments.
    /// </summary>
    [Serializable()]
    public class UserEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="profile">User profile.</param>
        /// <param name="state">State.</param>
        /// <param name="oldState">Old state.</param>
        /// <param name="failReason">Fail reason.</param>
        /// <param name="requiredInfo">Required info.</param>
        public UserEventArgs(IUserProfile profile,
            LoginState state,
            LoginState oldState = LoginState.LoggedOut,
            LoginResult failReason = LoginResult.Sucess,
            UserInfoTypes requiredInfo = UserInfoTypes.None)
        {
            UserProfile = profile;
            State = state;
            OldState = oldState;
            FailReason = failReason;
            RequiredUserInformation = requiredInfo;
        }
        #endregion    

        #region PROPERTIES

        /// <summary>
        /// Gets the user profile that caused the event.
        /// </summary>
        public IUserProfile UserProfile
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the new user state.
        /// </summary>
        public LoginState State
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the old user state.
        /// </summary>
        public LoginState OldState
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the failure reason.
        /// <remarks>
        /// This value is only set if error occurred otherwise equals to Sucess.
        /// </remarks>
        /// </summary>
        public LoginResult FailReason
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the information types required for this profile.
        /// <remarks>
        /// This property is only set when State property equals to LoggedIn.
        /// </remarks>
        /// </summary>
        public UserInfoTypes RequiredUserInformation
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets if user info input rquired for user.
        /// <remarks>
        /// This property will return false if only password input required.
        /// </remarks>
        /// </summary>
        public bool IsUserInfoRequired
        {
            get
            {
                return !(RequiredUserInformation == UserInfoTypes.None) & !(RequiredUserInformation == UserInfoTypes.Password);
            }
        }

        /// <summary>
        /// Gets if user password input requried for user.
        /// </summary>
        public bool IsUserPasswordRequired
        {
            get
            {
                return (RequiredUserInformation & UserInfoTypes.Password) == UserInfoTypes.Password;
            }
        }

        #endregion
    }
}
