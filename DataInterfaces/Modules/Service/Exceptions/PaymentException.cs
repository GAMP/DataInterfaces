using System;
using System.Runtime.Serialization;

namespace ServerService.Exceptions
{
    #region PAYMENTEXCEPTION
    [DataContract()]
    [Serializable()]
    public class PaymentException : PaymentExcpetionBase<PaymentErrorCode>
    {
        #region CONSTRUCTOR

        public PaymentException(PaymentErrorCode errorCode, int paymentMethodId) : base(errorCode, paymentMethodId)
        { }

        protected PaymentException(SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        { }

        #endregion
    }
    #endregion
}
