using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    #region ORDERSTATUSCHANGEEVENTARGS
    [Serializable()]
    [DataContract()]
    public class OrderStatusChangeEventArgs : OrderEventArgsBase
    {
        #region CONSTRUCTOR    
        public OrderStatusChangeEventArgs(int userId,
            int orderId,
            OrderStatus newStatus,
            OrderStatus? oldStatus) : base(userId, orderId)
        {
            OrderId = orderId;
            NewStatus = newStatus;
            OldStatus = oldStatus;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets new status.
        /// </summary>
        [DataMember()]
        public OrderStatus NewStatus
        {
            get; set;
        }

        /// <summary>
        /// Gets old status.
        /// </summary>
        [DataMember()]
        public OrderStatus? OldStatus
        {
            get; set;
        }

        #endregion
    }
    #endregion
}
