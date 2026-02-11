using SharedLib;

namespace ServerService
{
    /// <summary>
    /// Host event args with host id.
    /// </summary>
    public sealed class HostIdEventArgs : HostIdArgsBase
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="hostId">Host id.</param>
        /// <param name="type">Event type.</param>
        /// <param name="parameters">Parameters.</param>
        public HostIdEventArgs(int hostId, HostEventType type, object[] parameters)
            : base(hostId)
        {
            Type = type;
            Parameters = parameters;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hostId">Host id.</param>
        /// <param name="type">Event type.</param>
        public HostIdEventArgs(int hostId, HostEventType type)
            : this(hostId, type, null)
        { }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets type.
        /// </summary>
        public HostEventType Type
        {
            get;
        }

        /// <summary>
        /// Gets parameters.
        /// </summary>
        public object[] Parameters
        {
            get;
            set;
        }

        #endregion
    }
}
