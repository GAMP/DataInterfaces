using System;
using System.Runtime.Serialization;

namespace ServerService
{
    #region ORDERINVOICEDEVENTARGS
    [Serializable()]
    [DataContract()]
    public class OrderInvoicedEventArgs : OrderEventArgsBase
    {
        #region CONSTRUCTOR
        public OrderInvoicedEventArgs(int orderId, int userId, int invoiceId) : base(userId, orderId)
        {
            InvoiceId = invoiceId;
        }
        #endregion

        #region PROPERTIES

        [DataMember()]
        public int InvoiceId
        {
            get; set;
        }

        #endregion
    }
    #endregion
}
