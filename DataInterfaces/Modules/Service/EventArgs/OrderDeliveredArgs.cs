using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Order delivered event args.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class OrderDeliveredArgs : OrderEventArgsBase
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="orderId">Order id.</param>
        public OrderDeliveredArgs(int userId, int orderId) : base(userId, orderId)
        {
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets if order is delivered.
        /// </summary>
        [DataMember()]
        public bool IsDelivered
        {
            get; set;
        }

        /// <summary>
        /// Gets delivery time.
        /// </summary>
        [DataMember()]
        public DateTime? DeliverTime
        {
            get; set;
        }

        /// <summary>
        /// Gets current order line states.
        /// </summary>
        [DataMember()]
        public IEnumerable<OrderLineState> States
        {
            get; set;
        }

        #endregion
    }
}
