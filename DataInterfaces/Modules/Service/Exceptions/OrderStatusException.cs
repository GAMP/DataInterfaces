using Gizmo.Shared.Exceptions;
using System;
using System.Runtime.Serialization;

namespace ServerService.Exceptions
{
    #region ORDERSTATUSEXCEPTION
    [DataContract()]
    [Serializable()]
    public class OrderStatusException : ErrorCodeExceptionBase<OrderStatusErrorCode>
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
}
