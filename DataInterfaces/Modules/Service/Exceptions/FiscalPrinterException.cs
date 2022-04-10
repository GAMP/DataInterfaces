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

        public FiscalPrinterException(string message, FiscalPrinterErrorCodes errorCode, int? pritnerOrDrieverErrorCode) : base(message, errorCode)
        {
            PrinterOrDriverErrorCode = pritnerOrDrieverErrorCode;
        }

        public FiscalPrinterException(string message, FiscalPrinterErrorCodes errorCode) : base(message, errorCode)
        {
        }

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
        {
            if (info != null)
            {
                PrinterOrDriverErrorCode = (int?)info.GetValue(nameof(PrinterOrDriverErrorCode), typeof(int?));
            }
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets optional printer or driver error code.
        /// </summary>
        public int? PrinterOrDriverErrorCode
        {
            get; set;
        }

        #endregion

        #region OVERRIDES

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            if (info != null)
            {
                info.AddValue(nameof(PrinterOrDriverErrorCode), PrinterOrDriverErrorCode);
            }
        }

        #endregion
    }
}
