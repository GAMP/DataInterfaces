using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService
{
    #region ORDERDELIVEREDARGS
    [Serializable()]
    [DataContract()]
    public class OrderDeliveredArgs : OrderEventArgsBase
    {
        #region CONSTRUCTOR
        public OrderDeliveredArgs(int userId, int orderId) : base(userId, orderId)
        {
        }
        #endregion

        #region PROPERTIES

        [DataMember()]
        public bool IsDelivered
        {
            get; set;
        }

        [DataMember()]
        public DateTime? DeliverTime
        {
            get; set;
        }

        [DataMember()]
        public IEnumerable<OrderLineState> States
        {
            get; set;
        }

        #endregion
    }
    #endregion
}
