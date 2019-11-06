using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// User session changed event args.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class UserSessionChangedEventArgs : UserIdEventArgsBase
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="hostId">Host id.</param>
        /// <param name="slot">Slot.</param>
        /// <param name="state">State.</param>
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
}
