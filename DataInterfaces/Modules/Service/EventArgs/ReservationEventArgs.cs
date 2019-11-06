using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Reservation change server event args.
    /// </summary>
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class ReservationEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="reservationId">Reservation id.</param>
        public ReservationEventArgs(int reservationId):this(reservationId,Enumerable.Empty<int>(),Enumerable.Empty<int>())
        {
        } 

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="reservationId">Reservation id.</param>
        /// <param name="users">Reservation users.</param>
        /// <param name="hosts">Reservation hosts.</param>
        public ReservationEventArgs(int reservationId,IEnumerable<int> users,IEnumerable<int> hosts)
        {
            users = users ?? Enumerable.Empty<int>();
            hosts = hosts ?? Enumerable.Empty<int>();
            Hosts = new HashSet<int>(hosts);
            Users = new HashSet<int>(users);
            ReservationId = reservationId;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets reservation id.
        /// </summary>
        [ProtoMember(1)]
        [DataMember()]
        public int ReservationId
        {
            get; protected set;
        }

        /// <summary>
        /// Gets reserved users.
        /// </summary>
        [ProtoMember(2)]
        [DataMember()]
        public HashSet<int> Users
        {
            get;set;
        }

        /// <summary>
        /// Gets reserved hosts.
        /// </summary>
        [ProtoMember(3)]
        [DataMember()]
        public HashSet<int> Hosts
        {
            get;set;
        }

        #endregion
    }
}
