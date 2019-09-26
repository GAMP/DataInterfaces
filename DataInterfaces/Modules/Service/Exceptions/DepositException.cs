using Gizmo.Shared.Exceptions;
using System;
using System.Runtime.Serialization;

namespace ServerService.Exceptions
{
    #region DEPOSITEXCEPTION
    [DataContract()]
    [Serializable()]
    public class DepositException : ErrorCodeExceptionBase<DepositErrorCode>
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
}
