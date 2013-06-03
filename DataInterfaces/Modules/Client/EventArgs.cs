using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedLib.User;
using SharedLib.Applications;
using IntegrationLib;
using SharedLib;

namespace Client
{
    #region UserEventArgs
    /// <summary>
    ///User event arguments.
    /// </summary>
    [Serializable()]
    public class UserEventArgs : EventArgs
    {
        #region Fileds
        private IUserProfile profile;
        private LoginState state, oldState;
        private LoginResult failReason;
        private UserInfoTypes requiredInfo = UserInfoTypes.None;
        #endregion

        #region Constructor
        public UserEventArgs(IUserProfile profile,
            LoginState state,
            LoginState oldState = LoginState.LoggedOut,
            LoginResult failReason = LoginResult.Sucess,
            UserInfoTypes requiredInfo = UserInfoTypes.None)
        {           
                this.UserProfile = profile;
                this.State = state;
                this.OldState = oldState;
                this.FailReason = failReason;
                this.RequiredUserInformation = requiredInfo;          
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets the user profile that caused the event.
        /// </summary>
        public IUserProfile UserProfile
        {
            get { return this.profile; }
            protected set { this.profile = value; }
        }

        /// <summary>
        /// Gets the new user state.
        /// </summary>
        public LoginState State
        {
            get { return this.state; }
            protected set
            {
                this.state = value;
            }
        }

        /// <summary>
        /// Gets the old user state.
        /// </summary>
        public LoginState OldState
        {
            get { return this.oldState; }
            protected set
            {
                this.oldState = value;
            }
        }

        /// <summary>
        /// Gets the failure reason.
        /// <remarks>This value is only set if error occurred otherwise equals to Sucess.</remarks>
        /// </summary>
        public LoginResult FailReason
        {
            get { return this.failReason; }
            protected set { this.failReason = value; }
        }

        /// <summary>
        /// Gets the information required for this profile.
        /// </summary>
        public UserInfoTypes RequiredUserInformation
        {
            get { return this.requiredInfo; }
            protected set { this.requiredInfo = value; }
        }

        /// <summary>
        /// Indicates if user info rquired from user.
        /// </summary>
        public bool IsUserInfoRequired
        {
            get
            {
                return !(this.RequiredUserInformation == UserInfoTypes.None) & !(this.RequiredUserInformation == UserInfoTypes.Password);
            }
        }

        /// <summary>
        /// Indicates if user password requried from user.
        /// </summary>
        public bool IsUserPasswordRequired
        {
            get
            {
                return (this.RequiredUserInformation & UserInfoTypes.Password) == UserInfoTypes.Password;
            }
        }

        #endregion

        #region Ovverides
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("----------------START-------------------");
            if(this.UserProfile!=null)
                builder.AppendLine(String.Format("User Id:{0}", this.UserProfile.Id));
            builder.AppendLine(String.Format("Old State:{0}", this.OldState));
            builder.AppendLine(String.Format("New State:{0}", this.State));
            builder.AppendLine(String.Format("Fail Reason:{0}", this.FailReason));
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
        #region Constructor
        public LockStateEventArgs(bool isLocked, bool oldState)
        {
            this.IsLocked = isLocked;
            this.OldState = oldState;
        }
        #endregion

        #region Fileds
        private bool isLocked = false, oldState;
        #endregion

        #region Properties
        /// <summary>
        /// Gets if the lock is active.
        /// </summary>
        public bool IsLocked
        {
            get { return this.isLocked; }
            protected set { this.isLocked = value; }
        }
        /// <summary>
        /// Gets if lock was previously active.
        /// </summary>
        public bool OldState
        {
            get { return this.oldState; }
            set { this.oldState = value; }
        }
        #endregion
    }
    #endregion

    #region IdChangeEventArgs
    [Serializable()]
    public class IdChangeEventArgs : EventArgs
    {
        #region Constructor
        public IdChangeEventArgs(int newId, int oldId)
        {
            this.NewId = newId;
            this.OldId = oldId;
        }
        #endregion

        #region Properties
        public int OldId
        {
            get;
            protected set;
        }
        public int NewId
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
        #region Constructor

        public SecurityStateArgs(bool isEnabled,bool wasEnabled)
        {
            this.IsEnabled = isEnabled;
            this.WasEnabled = wasEnabled;
        }

        public SecurityStateArgs(bool isEnabled,bool wasEnabled,bool activePolicy = false):this(isEnabled,wasEnabled)
        {     
            this.ActiveProfileChanged = activePolicy;
        }

        #endregion

        #region Properties

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
        #region Constructor

        public ExecutionContextStateArgs(ContextExecutionState newState,
            ContextExecutionState oldState,
            object stateObject)
        {
            this.NewState = newState;
            this.OldState = oldState;
            this.StateObject = stateObject;
        }

        public ExecutionContextStateArgs(ContextExecutionState newState,
          ContextExecutionState oldState)
            : this(newState, oldState, null)
        {
        }

        #endregion

        #region Fileds
        private ContextExecutionState oldState, newState;
        private object stateObject;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the instance of the state object.
        /// </summary>
        public object StateObject
        {
            get { return this.stateObject; }
            protected set { this.stateObject = value; }
        }
        /// <summary>
        /// Gets the new state of the executable.
        /// </summary>
        public ContextExecutionState NewState
        {
            get { return this.newState; }
            protected set { this.newState = value; }
        }
        /// <summary>
        /// Gets the old state of executable.
        /// </summary>
        public ContextExecutionState OldState
        {
            get { return this.oldState; }
            protected set { this.oldState = value; }
        }
        #endregion
    }
    #endregion

    #region OutOfOrderStateEventArgs
    [Serializable()]
    public class OutOfOrderStateEventArgs : EventArgs
    {
        #region Constructor
        public OutOfOrderStateEventArgs(bool newState, bool oldState)
        {
            this.NewState = newState;
            this.OldState = oldState;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets if out of order was prevously set.
        /// </summary>
        public bool OldState
        {
            get;
            private set;
        }
        /// <summary>
        /// Gets if out of order is currently set.
        /// </summary>
        public bool NewState
        {
            get;
            private set;
        }
        #endregion
    }
    #endregion

    #region ApplicationRateEventArgs
    public class ApplicationRateEventArgs : EventArgs
    {
        public ApplicationRateEventArgs(int appId,IRating rating)
        {
            this.ApplicationId = appId;
            this.NewRating = rating;
        }

        /// <summary>
        /// Gets the application id.
        /// </summary>
        public int ApplicationId
        {
            get;
            protected set;
        }
        public IRating NewRating
        {
            get;
            protected set;
        }
    } 
    #endregion

    #region ProfilesChangeEventArgs
    public class ProfilesChangeEventArgs : EventArgs
    {
        #region Constructor
        public ProfilesChangeEventArgs(bool isInitial)
        {
            this.IsInitial = isInitial;
        } 
        #endregion

        #region Properties
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
}
