using Gizmo.Shared.Exceptions;
using System;
using System.Runtime.Serialization;

namespace ServerService.Exceptions
{
    /// <summary>
    /// Payment exception base class.
    /// </summary>
    /// <typeparam name="TErrorCode">Payment error code tyepe.</typeparam>
    [Serializable()]
    [DataContract()]
    public abstract class PaymentExcpetionBase<TErrorCode> : ErrorCodeExceptionBase<TErrorCode> where TErrorCode : Enum
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="errorCode">Error code.</param>
        /// <param name="paymentMethodId">Payment method id.</param>
        public PaymentExcpetionBase(TErrorCode errorCode, int paymentMethodId) : base(errorCode)
        {
            PaymentMethodId = paymentMethodId;
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="errorCode">Error code.</param>
        public PaymentExcpetionBase(TErrorCode errorCode) : base(errorCode)
        {
        }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Serialization context.</param>
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

        /// <summary>
        /// Gets object data.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Serialization context.</param>
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
}
