using System;

namespace ServerService
{
    /// <summary>
    /// Base arguments for host events.
    /// </summary>
    public abstract class HostIdArgsBase : EventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="hostId">Host id.</param>
        public HostIdArgsBase(int hostId)
            : base()
        {
            HostId = hostId;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Gets host id.
        /// </summary>
        public int HostId
        {
            get;
            protected set;
        }
        #endregion
    }
}
