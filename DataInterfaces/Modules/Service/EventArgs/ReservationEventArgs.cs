using System;
using System.Collections.Generic;
using System.Linq;

namespace ServerService
{
    /// <summary>
    /// Reservation change server event args.
    /// </summary>
    public sealed class ReservationEventArgs : EventArgs
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
        public int ReservationId
        {
            get; protected set;
        }

        /// <summary>
        /// Gets reserved users.
        /// </summary>
        public HashSet<int> Users
        {
            get;set;
        }

        /// <summary>
        /// Gets reserved hosts.
        /// </summary>
        public HashSet<int> Hosts
        {
            get;set;
        }

        #endregion
    }
}
