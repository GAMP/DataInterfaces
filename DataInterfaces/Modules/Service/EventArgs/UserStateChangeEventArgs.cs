using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    #region USERSTATECHANGEEVENTARGS
    [Serializable()]
    [DataContract()]
    public class UserStateChangeEventArgs : UserIdEventArgsBase
    {
        #region CONSTRUCTOR
        public UserStateChangeEventArgs(int userId, int hostId, LoginState newState, LoginState oldState)
            : base(userId)
        {
            NewState = newState;
            OldState = oldState;
            HostId = hostId;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets new user state.
        /// </summary>
        public LoginState NewState
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets old user state.
        /// </summary>
        public LoginState OldState
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets host id.
        /// </summary>
        public int HostId
        {
            get;
            private set;
        }

        #endregion

        #region OVERRIDES
        public override string ToString()
        {
            return String.Format("User Id:{0} New State {1} Old State: {2}", this.UserId, this.NewState, this.OldState);
        }
        #endregion
    }
    #endregion
}
