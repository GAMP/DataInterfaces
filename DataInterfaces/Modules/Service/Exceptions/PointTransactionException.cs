using Gizmo.Shared.Exceptions;
using System;
using System.Runtime.Serialization;

namespace ServerService.Exceptions
{
    #region POINTTRANSACTIONEXCEPTION
    [DataContract()]
    [Serializable()]
    public class PointTransactionException : ErrorCodeExceptionBase<PointTransactionErrorCode>
    {
        #region CONSTRUCTOR

        public PointTransactionException(PointTransactionErrorCode errorCode) : base(errorCode)
        {
        }

        protected PointTransactionException(SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        { }

        #endregion
    }
    #endregion
}
