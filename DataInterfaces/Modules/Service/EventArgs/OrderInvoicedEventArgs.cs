using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Order invoiced event args.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class OrderInvoicedEventArgs : OrderEventArgsBase
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="orderId">Order id.</param>
        /// <param name="userId">User id.</param>
        /// <param name="invoiceId">Invoice id.</param>
        public OrderInvoicedEventArgs(int orderId, int userId, int invoiceId) : base(userId, orderId)
        {
            InvoiceId = invoiceId;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets invoice id.
        /// </summary>
        [DataMember()]
        public int InvoiceId
        {
            get; protected set;
        }

        #endregion
    }
}
