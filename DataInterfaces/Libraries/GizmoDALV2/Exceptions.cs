using System;
using System.Runtime.Serialization;

namespace GizmoDALV2
{
    #region ENTITYNOTFOUNDEXCPETION
    [DataContract()]
    [Serializable()]
    public class EntityNotFoundExcpetion : Exception
    {
        #region CONSTRUCTOR

        public EntityNotFoundExcpetion() : base() { }

        public EntityNotFoundExcpetion(int entityKey, Type entityType) : this()
        {
            if (entityType == null)
                throw new ArgumentNullException(nameof(entityType));

            EntityKey = entityKey;
            EntityType = entityType;
        }

        public EntityNotFoundExcpetion(object[] keys, Type entityType) : this()
        {
            if (keys == null)
                throw new ArgumentNullException(nameof(keys));

            if (entityType == null)
                throw new ArgumentNullException(nameof(entityType));

            Keys = keys;
            EntityType = entityType;
        }

        public EntityNotFoundExcpetion(string message)
            : base(message)
        { }

        public EntityNotFoundExcpetion(string message, Exception inner)
            : base(message, inner)
        { }

        protected EntityNotFoundExcpetion(SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
            if (info != null)
            {
                EntityType = (Type)info.GetValue(nameof(EntityType), typeof(Type));
                EntityKey = (int?)info.GetValue(nameof(EntityKey), typeof(int?));
                Keys = (object[])info.GetValue(nameof(Keys), typeof(object[]));
            }
        }

        #endregion

        #region OVERRIDES

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            if (info != null)
            {
                info.AddValue(nameof(EntityType), EntityType);
                info.AddValue(nameof(EntityKey), EntityKey);
                info.AddValue(nameof(Keys), Keys);
            }
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets entity id.
        /// </summary>
        [DataMember()]
        public int? EntityKey
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets entity type.
        /// </summary>
        [DataMember()]
        public Type EntityType
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets entity keys.
        /// </summary>
        public object[] Keys
        {
            get; set;
        }

        #endregion
    }
    #endregion

    #region ERRORCODEEXCEPTION

    /// <summary>
    /// Generic error code exception.
    /// </summary>
    /// <typeparam name="TErrorCode">Error code type.</typeparam>
    [DataContract()]
    [Serializable()]
    public abstract class ErrorCodeException<TErrorCode> : Exception
    {
        #region CONSTRUCTOR

        public ErrorCodeException(TErrorCode errorCode)
            : base()
        {
            ErrorCode = errorCode;
        }

        public ErrorCodeException(string message,TErrorCode errorCode):this(message)
        {
            ErrorCode = errorCode;
        }

        public ErrorCodeException() : base() { }

        public ErrorCodeException(string message)
          : base(message)
        { }

        public ErrorCodeException(string message, Exception inner)
            : base(message, inner)
        { }

        protected ErrorCodeException(SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
            if (info != null)
            {
                ErrorCode = (TErrorCode)info.GetValue(nameof(ErrorCode), typeof(TErrorCode));
            }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            if (info != null)
            {
                info.AddValue(nameof(ErrorCode), ErrorCode);
            }
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets exception error code.
        /// </summary>
        [DataMember()]
        public TErrorCode ErrorCode
        {
            get; protected set;
        }

        #endregion

        #region OVERRIDES

        public override string ToString()
        {
            return string.Format("{0} failed with error {1}", GetType().FullName, ErrorCode);
        }

        #endregion
    }

    #endregion

    #region ORDERSTATUSEXCEPTION
    [DataContract()]
    [Serializable()]
    public class OrderStatusException : ErrorCodeException<OrderStatusErrorCode>
    {
        #region CONSTRUCTOR

        public OrderStatusException(OrderStatusErrorCode errorCode) : base(errorCode)
        { }

        protected OrderStatusException(SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        { }

        #endregion
    }
    #endregion

    #region PAYMENTEXCPETIONBASE
    [Serializable()]
    [DataContract()]
    public abstract class PaymentExcpetionBase<TErrorCode> : ErrorCodeException<TErrorCode>
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

    #region INVOICEEXCEPTION
    [DataContract()]
    [Serializable()]
    public class InvoiceException : ErrorCodeException<InvoiceErrorCode>
    {
        #region CONSTRUCTOR

        public InvoiceException(InvoiceErrorCode errorCode) : base(errorCode)
        {
        }

        protected InvoiceException(SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        { }

        #endregion
    }
    #endregion

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

    #region DEPOSITEXCEPTION
    [DataContract()]
    [Serializable()]
    public class DepositException : ErrorCodeException<DepositErrorCode>
    {
        #region CONSTRUCTOR

        public DepositException(DepositErrorCode errorCode) : base(errorCode)
        {
        }

        protected DepositException(SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        { }

        #endregion
    }
    #endregion

    #region STOCKEXCEPTION
    [DataContract()]
    [Serializable()]
    public class StockException : ErrorCodeException<StockErrorCodes>
    {
        #region CONSTRUCTOR

        public StockException(StockErrorCodes errorCode) : base(errorCode)
        {
        }

        protected StockException(SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        { }

        #endregion
    }
    #endregion

    #region SHIFTEXCEPTION

    [Serializable()]
    public class ShiftException : ErrorCodeException<ShiftErrorCode>
    {
        #region CONSTRUCTOR

        public ShiftException(ShiftErrorCode errorCode) : base(errorCode)
        { }

        protected ShiftException(SerializationInfo info,
           StreamingContext context)
            : base(info, context)
        { }

        #endregion
    }

    #endregion

    #region ASSETEXCEPTION
    [Serializable()]
    [DataContract()]
    public class AssetException : ErrorCodeException<AssetErrorCode>
    {
        #region CONSTRUCTOR

        public AssetException(AssetErrorCode errorCode) : base(errorCode)
        { }

        protected AssetException(SerializationInfo info,
           StreamingContext context)
            : base(info, context)
        { }

        #endregion
    }
    #endregion

    #region WAITINGLINEEXCEPTION

    [Serializable()]
    [DataContract()]
    public class WaitingLineException : ErrorCodeException<WaitingLineErrorCode>
    {
        #region CONSTRUCTOR

        public WaitingLineException(WaitingLineErrorCode code) : base(code)
        { }

        public WaitingLineException() : base() { }

        public WaitingLineException(string message)
          : base(message)
        { }

        public WaitingLineException(string message, Exception inner)
            : base(message, inner)
        { }

        protected WaitingLineException(SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        { }

        #endregion
    }

    #endregion
}
