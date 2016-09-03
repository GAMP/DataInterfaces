using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GizmoDALV2
{
    #region EntityNotFoundExcpetion
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

    #region ErrorCodeException
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
        { }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets exception error code.
        /// </summary>
        [DataMember()]
        public TErrorCode ErrorCode
        {
            get;
            protected set;
        }

        #endregion
    }
    #endregion

    #region OrderStatusException
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

    #region PaymentException
    [DataContract()]
    [Serializable()]
    public class PaymentException : ErrorCodeException<PaymentErrorCode>
    {
        #region CONSTRUCTOR
        public PaymentException(PaymentErrorCode errorCode) : base(errorCode)
        { }

        protected PaymentException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        { }
        #endregion
    }
    #endregion

    #region InvoiceException
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

    #region DepositException
    [DataContract()]
    [Serializable()]
    public class DepositException : ErrorCodeException<DepositErrorCode>
    {
        #region CONSTRUCTOR

        public DepositException(DepositErrorCode errorCode) : base(errorCode)
        {
        }

        protected DepositException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        { }

        #endregion
    }
    #endregion

    #region StockException
    [DataContract()]
    [Serializable()]
    public class StockException : ErrorCodeException<StockErrorCodes>
    {
        #region CONSTRUCTOR

        public StockException(StockErrorCodes errorCode) : base(errorCode)
        {
        }

        protected StockException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        { }

        #endregion
    }
    #endregion
}
