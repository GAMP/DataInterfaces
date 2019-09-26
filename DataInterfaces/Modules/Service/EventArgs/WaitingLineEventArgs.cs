using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService
{
    #region WAITINGLINEEVENTARGS
    [Serializable()]
    [DataContract()]
    public class WaitingLineEventArgs : EventArgs
    {
        #region CONSTRUCTOR

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
    #endregion
}
