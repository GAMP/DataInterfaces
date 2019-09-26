using Gizmo.Shared.Exceptions;
using System;
using System.Runtime.Serialization;

namespace ServerService.Exceptions
{
    #region INVOICEEXCEPTION
    [DataContract()]
    [Serializable()]
    public class InvoiceException : ErrorCodeExceptionBase<InvoiceErrorCode>
    {
        #region CONSTRUCTOR

        public InvoiceException(InvoiceErrorCode errorCode) : base(errorCode)
        {
        }

        protected InvoiceException(SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        { }

        #endregion
    }
    #endregion
}
