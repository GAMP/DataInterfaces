using System;
using System.Runtime.Serialization;

namespace ServerService.Exceptions
{
    #region INVOICEPAYMENTEXCPETION
    [DataContract()]
    [Serializable()]
    public class InvoicePaymentExcpetion : PaymentExcpetionBase<InvoicePaymentErrorCode>
    {
        #region CONSTRUCTOR

        public InvoicePaymentExcpetion(InvoicePaymentErrorCode errorCode, int paymentMethodId)
            : base(errorCode, paymentMethodId)
        { }

        public InvoicePaymentExcpetion(InvoicePaymentErrorCode errorCode) : base(errorCode)
        { }

        protected InvoicePaymentExcpetion(SerializationInfo info,
           StreamingContext context)
            : base(info, context)
        { }

        #endregion
    }
    #endregion
}
