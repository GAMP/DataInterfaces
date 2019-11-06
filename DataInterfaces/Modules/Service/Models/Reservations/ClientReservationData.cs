using ProtoBuf;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Client reservation data.
    /// </summary>
    [DataContract()]
    [ProtoContract()]
    public class ClientReservationData
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets next reservation id.
        /// </summary>
        [DataMember(Order = 0)]
        [ProtoMember(1)]
        public int? NextReservationId
        {
            get; set;
        }

        /// <summary>
        /// Gets next reservation date.
        /// </summary>
        [DataMember(Order = 1)]
        [ProtoMember(2)]
        public DateTime? NextReservationTime
        {
            get; set;
        }

        /// <summary>
        /// Enables blocking login on hosts with upcoming reservations.
        /// </summary>
        [DataMember(Order = 2)]
        [ProtoMember(3)]
        public bool EnableLoginBlock
        {
            get; set;
        }

        /// <summary>
        /// Time in minutes before upcoming reservation to block login.
        /// </summary>
        [DataMember(Order = 3)]
        [ProtoMember(4)]
        public int LoginBlockTime
        {
            get; set;
        }

        /// <summary>
        /// Enables unblocking login for active reservation.
        /// </summary>
        [DataMember(Order = 4)]
        [ProtoMember(5)]
        public bool EnableLoginUnblock
        {
            get; set;
        }

        /// <summary>
        /// Time in minutes before unblocking login for active reservation.
        /// </summary>
        [DataMember(Order = 5)]
        [ProtoMember(6)]
        [DefaultValue(30)]
        public int LoginUnblockTime
        {
            get; set;
        }

        #endregion
    }
}
