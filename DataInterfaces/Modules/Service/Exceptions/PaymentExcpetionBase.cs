using Gizmo.Shared.Exceptions;
using System;
using System.Runtime.Serialization;

namespace ServerService.Exceptions
{
    #region PAYMENTEXCPETIONBASE
    [Serializable()]
    [DataContract()]
    public abstract class PaymentExcpetionBase<TErrorCode> : ErrorCodeExceptionBase<TErrorCode>
    {
        #region CONSTRUCTOR

        public PaymentExcpetionBase(TErrorCode errorCode, int paymentMethodId) : base(errorCode)
        {
            PaymentMethodId = paymentMethodId;
        }

        public PaymentExcpetionBase(TErrorCode errorCode) : base(errorCode)
        {
        }

        protected PaymentExcpetionBase(SerializationInfo info,
          StreamingContext context)
            : base(info, context)
        {
            if (info != null)
            {
                PaymentMethodId = (int?)info.GetValue(nameof(PaymentMethodId), typeof(int?));
            }
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

        #endregion

        #region OVERRIDES

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            if (info != null)
            {
                info.AddValue(nameof(PaymentMethodId), PaymentMethodId);
            }
        }

        #endregion
    }

    #endregion
}
