using System;
using System.Text;
using SharedLib.User;
using SharedLib.Applications;
using IntegrationLib;
using SharedLib;

namespace Client
{
    #region UserPasswordChangeEventArgs
    [Serializable()]
    public class UserPasswordChangeEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public UserPasswordChangeEventArgs(string newPassword)
        {
            NewPassword = newPassword;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets new password value.
        /// </summary>
        public string NewPassword
        {
            get;
            protected set;
        }
        #endregion
    } 
    #endregion

    #region UserProfileChangeArgs
    [Serializable()]
    public class UserProfileChangeArgs : EventArgs
    {
        #region CONSTRUCTOR
        public UserProfileChangeArgs(IUserProfile newProfile, IUserProfile oldProfile)
        {
            if (newProfile == null)
                throw new ArgumentNullException("newProfile");

            if (oldProfile == null)
                throw new ArgumentNullException("oldProfile");

            NewProfile = newProfile;
            OldProfile = oldProfile;
        } 
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets old profile value.
        /// </summary>
        public IUserProfile OldProfile
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets new profile value.
        /// </summary>
        public IUserProfile NewProfile
        {
            get;
            protected set;
        }

        #endregion
    } 
    #endregion

    #region UserEventArgs
    /// <summary>
    ///User event arguments.
    /// </summary>
    [Serializable()]
    public class UserEventArgs : EventArgs
    {
        #region CONSTRUCTOR
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

        #region OVERRIDES
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("----------------START-------------------");
            if(UserProfile!=null)
                builder.AppendLine(String.Format("User Id:{0}", UserProfile.Id));
            builder.AppendLine(String.Format("Old State:{0}", OldState));
            builder.AppendLine(String.Format("New State:{0}", State));
            builder.AppendLine(String.Format("Fail Reason:{0}", FailReason));
            builder.AppendLine("----------------END---------------------");
            return builder.ToString();
        }
        #endregion
    }
    #endregion

    #region LockStateEventArgs
    [Serializable()]
    public class LockStateEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public LockStateEventArgs(bool isLocked)
        {
            IsLocked = isLocked;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets if the lock is active.
        /// </summary>
        public bool IsLocked
        {
            get;
            protected set;
        }
        
        #endregion
    }
    #endregion

    #region IdChangeEventArgs
    [Serializable()]
    public class IdChangeEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public IdChangeEventArgs(int newId, int oldId)
        {
            NewId = newId;
            OldId = oldId;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets new id.
        /// </summary>
        public int NewId
        {
            get;
            protected set;
        } 

        /// <summary>
        /// Gets old id.
        /// </summary>
        public int OldId
        {
            get;
            protected set;
        }
        
        #endregion
    }
    #endregion

    #region SecurityStateArgs
    [Serializable()]
    public class SecurityStateArgs : EventArgs
    {
        #region CONSTRUCTOR

        public SecurityStateArgs(bool isEnabled,bool wasEnabled)
        {
            IsEnabled = isEnabled;
            WasEnabled = wasEnabled;
        }

        public SecurityStateArgs(bool isEnabled,bool wasEnabled,bool activePolicy = false):this(isEnabled,wasEnabled)
        {     
            ActiveProfileChanged = activePolicy;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets if security is currently enabled.
        /// </summary>
        public bool IsEnabled
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets if security was previously enabled.
        /// </summary>
        public bool WasEnabled
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets if active security profile change caused this event.
        /// </summary>
        public bool ActiveProfileChanged
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion

    #region ExecutionContextStateArgs
    /// <summary>
    /// Execution context arguments.
    /// </summary>
    [Serializable()]
    public class ExecutionContextStateArgs : EventArgs
    {
        #region CONSTRUCTOR

        public ExecutionContextStateArgs(int exeId,ContextExecutionState newState,
            ContextExecutionState oldState,
            object stateObject)
        {
            ExecutableId = exeId;
            NewState = newState;
            OldState = oldState;
            StateObject = stateObject;
        }

        public ExecutionContextStateArgs(int exeId, ContextExecutionState newState,
          ContextExecutionState oldState)
            : this(exeId, newState, oldState, null)
        {
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets executable id.
        /// </summary>
        public int ExecutableId
        {
            get;protected set;
        }

        /// <summary>
        /// Gets the instance of the state object.
        /// </summary>
        public object StateObject
        {
            get;
            protected set;
        }
        
        /// <summary>
        /// Gets the new state.
        /// </summary>
        public ContextExecutionState NewState
        {
            get;
            protected set;
        }
        
        /// <summary>
        /// Gets the old state.
        /// </summary>
        public ContextExecutionState OldState
        {
            get;
            protected set;
        }
        
        #endregion
    }
    #endregion

    #region OutOfOrderStateEventArgs
    [Serializable()]
    public class OutOfOrderStateEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public OutOfOrderStateEventArgs(bool newState)
        {
            IsOutOfOrder = newState;
        }
        #endregion

        #region PROPERTIES
        
        /// <summary>
        /// Gets if out of order is currently set.
        /// </summary>
        public bool IsOutOfOrder
        {
            get;
            private set;
        }

        #endregion
    }
    #endregion

    #region ApplicationRateEventArgs
    [Serializable()]
    public class ApplicationRateEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public ApplicationRateEventArgs(int appId, IRating overallRating,IRating userRating)
        {
            if (overallRating == null)
                throw new ArgumentNullException("overallRating");

            if (userRating == null)
                throw new ArgumentNullException("userRating");

            ApplicationId = appId;
            OverallRating = overallRating;
            UserRating = userRating;
        } 
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets rated application id.
        /// </summary>
        public int ApplicationId
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets application overall rating.
        /// </summary>
        public IRating OverallRating
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets application user rating.
        /// </summary>
        public IRating UserRating
        {
            get;
            protected set;
        }

        #endregion
    } 
    #endregion

    #region ProfilesChangeEventArgs
    public class ProfilesChangeEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public ProfilesChangeEventArgs(bool isInitial)
        {
            IsInitial = isInitial;
        } 
        #endregion

        #region PROPERTIES
        
        /// <summary>
        /// Gets if event was created by initial change of profiles.
        /// </summary>
        public bool IsInitial
        {
            get;
            protected set;
        } 

        #endregion
    } 
    #endregion

    #region ClientActivityEventArgs
    [Serializable()]
    public class ClientActivityEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public ClientActivityEventArgs(ClientStartupActivity activity)
        {
            Activity = activity;
        } 
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets current client activity.
        /// </summary>
        public ClientStartupActivity Activity
        {
            get;
            protected set;
        } 
        #endregion
    }
    #endregion

    #region OverlayEventArgs
    public class OverlayEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        public OverlayEventArgs(bool isOpen)
        {
            IsOpen = isOpen;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets if overlay is currently open.
        /// </summary>
        public bool IsOpen
        {
            get; protected set;
        }

        #endregion
    } 
    #endregion
}
