using Gizmo.Shared.Exceptions;
using System;
using System.Runtime.Serialization;

namespace ServerService.Exceptions
{
    #region SHIFTEXCEPTION

    [Serializable()]
    [DataContract()]
    public class ShiftException : ErrorCodeExceptionBase<ShiftErrorCode>
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
}
