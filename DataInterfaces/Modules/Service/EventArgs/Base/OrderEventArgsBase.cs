using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Order event args base class.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public abstract class OrderEventArgsBase : UserIdEventArgsBase
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="orderId">Order id.</param>
        public OrderEventArgsBase(int userId, int orderId) : base(userId)
        {
            OrderId = orderId;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets order id.
        /// </summary>
        [DataMember()]
        public int OrderId
        {
            get; protected set;
        }

        #endregion
    }
}
