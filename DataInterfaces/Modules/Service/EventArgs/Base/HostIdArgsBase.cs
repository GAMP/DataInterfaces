using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Base arguments for host events.
    /// </summary>
    [Serializable()]
    [DataContract()]
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
        [DataMember()]
        public int HostId
        {
            get;
            protected set;
        }
        #endregion
    }
}
