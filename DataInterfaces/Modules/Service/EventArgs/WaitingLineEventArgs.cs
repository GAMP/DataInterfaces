using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Waiting line event args.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class WaitingLineEventArgs : EventArgs
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="hostGroupId">Host group id.</param>
        /// <param name="activeEntries">Active entries.</param>
        public WaitingLineEventArgs(int? hostGroupId, IEnumerable<WaitingEntryInfo> activeEntries)
        {
            ActiveEntries = activeEntries ?? throw new ArgumentNullException(nameof(activeEntries));
            HostGroupId = hostGroupId;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets host group id.
        /// </summary>
        [DataMember()]
        public int? HostGroupId
        {
            get; set;
        }

        /// <summary>
        /// Gets affected lines.
        /// </summary>
        [DataMember()]
        public IEnumerable<WaitingEntryInfo> ActiveEntries
        {
            get; set;
        }

        #endregion
    }
}
