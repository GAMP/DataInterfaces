using Gizmo.Shared.Exceptions;
using System;
using System.Runtime.Serialization;

namespace ServerService.Exceptions
{
    #region WAITINGLINEEXCEPTION

    [Serializable()]
    [DataContract()]
    public class WaitingLineException : ErrorCodeExceptionBase<WaitingLineErrorCode>
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
