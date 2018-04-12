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

        public EntityNotFoundExcpetion(int entityKey, Type entityType):this()
        {
            if (entityType == null)
                throw new ArgumentNullException(nameof(entityType));

            this.EntityKey = entityKey;
            this.EntityType = entityType;
        }

        public EntityNotFoundExcpetion(object[] keys, Type entityType):this()
        {
            if (keys == null)
                throw new ArgumentNullException(nameof(keys));

            if (entityType == null)
                throw new ArgumentNullException(nameof(entityType));

            this.Keys = keys;
            this.EntityType = entityType;
        }

        public EntityNotFoundExcpetion(string message)
            : base(message)
        { }

        public EntityNotFoundExcpetion(string message, Exception inner)
            : base(message, inner)
        { }

        protected EntityNotFoundExcpetion(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        { }

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
            this.ErrorCode = errorCode;
        }

        public ErrorCodeException() : base() { }

        public ErrorCodeException(string message)
          : base(message)
        { }

        public ErrorCodeException(string message, Exception inner)
            : base(message, inner)
        { }

        protected ErrorCodeException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
            if (info != null)
            {
                this.ErrorCode = (TErrorCode)info.GetValue(nameof(this.ErrorCode),typeof(TErrorCode));
            }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            if (info != null)
            {
                info.AddValue(nameof(this.ErrorCode), this.ErrorCode);
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
            get;protected set;
        }

        #endregion

        #region OVERRIDES

        public override string ToString()
        {
            return string.Format("{0} failed with error {1}", this.GetType().FullName, this.ErrorCode);
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

        protected OrderStatusException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
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
            this.PaymentMethodId = paymentMethodId;
        }

        public PaymentExcpetionBase(TErrorCode errorCode):base(errorCode)
        {
        }

        protected PaymentExcpetionBase(System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
            if (info != null)
            {
                this.PaymentMethodId = (int?)info.GetValue(nameof(this.PaymentMethodId),typeof(int?));
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
                info.AddValue(nameof(this.PaymentMethodId), this.PaymentMethodId);
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

        public PaymentException(PaymentErrorCode errorCode, int paymentMethodId) : base(errorCode,paymentMethodId)
        { }

        protected PaymentException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
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

        protected InvoiceException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
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

        protected InvoicePaymentExcpetion(System.Runtime.Serialization.SerializationInfo info,
           System.Runtime.Serialization.StreamingContext context)
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
}
