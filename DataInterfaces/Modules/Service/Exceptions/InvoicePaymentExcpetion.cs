using System;
using System.Runtime.Serialization;

namespace ServerService.Exceptions
{
    /// <summary>
    /// Invoice payment exception.
    /// </summary>
    [DataContract()]
    [Serializable()]
    public class InvoicePaymentExcpetion : PaymentExcpetionBase<InvoicePaymentErrorCode>
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="errorCode">Error code.</param>
        /// <param name="paymentMethodId">Payment method id.</param>
        public InvoicePaymentExcpetion(InvoicePaymentErrorCode errorCode, int paymentMethodId)
            : base(errorCode, paymentMethodId)
        { }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="errorCode">Error code.</param>
        public InvoicePaymentExcpetion(InvoicePaymentErrorCode errorCode) : base(errorCode)
        { }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Serialization context.</param>
        protected InvoicePaymentExcpetion(SerializationInfo info,
           StreamingContext context)
            : base(info, context)
        { }

        #endregion
    }
}
