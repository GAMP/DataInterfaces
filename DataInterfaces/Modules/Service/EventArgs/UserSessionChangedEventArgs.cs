using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    #region USERSESSIONCHANGEDEVENTARGS
    [Serializable()]
    [DataContract()]
    public class UserSessionChangedEventArgs : UserIdEventArgsBase
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance user session state change.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="state">New state.</param>
        /// <param name="span">Span.</param>
        public UserSessionChangedEventArgs(int userId, int hostId, int slot, SessionState state, double span) : base(userId)
        {
            State = state;
            Span = span;
            Slot = slot;
            HostId = hostId;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets new state.
        /// </summary>
        [DataMember()]
        public SessionState State
        {
            get; protected set;
        }

        /// <summary>
        /// Gets span.
        /// </summary>
        [DataMember()]
        public double Span
        {
            get; protected set;
        }

        /// <summary>
        /// Gets slot.
        /// </summary>
        [DataMember()]
        public int Slot
        {
            get; protected set;
        }

        /// <summary>
        /// Gets host id.
        /// </summary>
        public int HostId
        {
            get; protected set;
        }

        #endregion
    }
    #endregion
}
