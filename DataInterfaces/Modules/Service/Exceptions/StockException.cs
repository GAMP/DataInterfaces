using Gizmo.Shared.Exceptions;
using System;
using System.Runtime.Serialization;

namespace ServerService.Exceptions
{
    #region STOCKEXCEPTION
    [DataContract()]
    [Serializable()]
    public class StockException : ErrorCodeExceptionBase<StockErrorCodes>
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
}
