using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Order status change event args.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class OrderStatusChangeEventArgs : OrderEventArgsBase
    {
        #region CONSTRUCTOR  
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="orderId">Order id.</param>
        /// <param name="newStatus">New status.</param>
        /// <param name="oldStatus">Old status.</param>
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

        #region OVERRDIES

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Order id {OrderId} , Old status = {OldStatus?.ToString() ?? ""} New status = {NewStatus}";
        }

        #endregion
    }
}
