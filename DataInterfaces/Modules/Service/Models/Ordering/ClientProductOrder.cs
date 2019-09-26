using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Client product order.
    /// </summary>
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class ClientProductOrder
    {
        #region PROPERTIES
        
        /// <summary>
        /// Optional user note.
        /// </summary>
        [ProtoMember(1)]
        [DataMember()]
        public string UserNote
        {
            get; set;
        }

        /// <summary>
        /// Order entries.
        /// </summary>
        [ProtoMember(2)]
        [DataMember()]
        public IEnumerable<ClientProductOrderEntry> Entries
        {
            get; set;
        } 

        #endregion
    }
}
