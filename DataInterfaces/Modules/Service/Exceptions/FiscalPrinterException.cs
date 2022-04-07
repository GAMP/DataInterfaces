using Gizmo.Shared.Exceptions;
using System;
using System.Runtime.Serialization;

namespace ServerService.Exceptions
{
    /// <summary>
    /// Fiscal printer exception exception.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class FiscalPrinterException : ErrorCodeExceptionBase<FiscalPrinterErrorCodes>
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="errorCode">Error code.</param>
        public FiscalPrinterException(FiscalPrinterErrorCodes errorCode) : base(errorCode)
        { }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Serialization context.</param>
        protected FiscalPrinterException(SerializationInfo info,
           StreamingContext context)
            : base(info, context)
        { }

        #endregion
    }
}
