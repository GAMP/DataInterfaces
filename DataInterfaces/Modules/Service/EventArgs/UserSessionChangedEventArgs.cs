namespace ServerService
{
    /// <summary>
    /// User session changed event args.
    /// </summary>
    public sealed class UserSessionChangedEventArgs : UserIdEventArgsBase
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
        public UserSessionChangedEventArgs(int userId, int hostId, int slot, Gizmo.Web.Api.Models.UserSessionState state, double span) : base(userId)
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
        public Gizmo.Web.Api.Models.UserSessionState State
        {
            get;
        }

        /// <summary>
        /// Gets span.
        /// </summary>
        public double Span
        {
            get;
        }

        /// <summary>
        /// Gets slot.
        /// </summary>
        public int Slot
        {
            get;
        }

        /// <summary>
        /// Gets host id.
        /// </summary>
        public int HostId
        {
            get;
        }

        #endregion
    }
}
