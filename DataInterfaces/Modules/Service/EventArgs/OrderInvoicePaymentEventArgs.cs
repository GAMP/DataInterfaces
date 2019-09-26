using System;
using System.Runtime.Serialization;

namespace ServerService
{
    #region ORDERINVOICEPAYMENTEVENTARGS
    [Serializable()]
    [DataContract()]
    public class OrderInvoicePaymentEventArgs : OrderInvoicedEventArgs
    {
        #region CONSTRUCTOR
        public OrderInvoicePaymentEventArgs(int orderId,
            int userId,
            int invoiceId,
            int paymentMethodId,
            decimal amount,
            decimal outstanding) : base(orderId, userId, invoiceId)
        {
            Amount = amount;
            PaymentMethodId = paymentMethodId;
            Outstanding = outstanding;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets payment method id.
        /// </summary>
        [DataMember()]
        public int? PaymentMethodId
        {
            get; protected set;
        }

        /// <summary>
        /// Gets payment amount.
        /// </summary>
        [DataMember()]
        public decimal Amount
        {
            get; set;
        }

        /// <summary>
        /// Get outstanding amount on invoice.
        /// </summary>
        [DataMember()]
        public decimal Outstanding
        {
            get; protected set;
        }

        #endregion
    }
    #endregion
}
