using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// User state changed event args.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class UserStateChangeEventArgs : UserIdEventArgsBase
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="hostId">Host id.</param>
        /// <param name="newState">New state.</param>
        /// <param name="oldState">Old state.</param>
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
        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("User Id:{0} New State {1} Old State: {2}", this.UserId, this.NewState, this.OldState);
        }
        #endregion
    }
}
