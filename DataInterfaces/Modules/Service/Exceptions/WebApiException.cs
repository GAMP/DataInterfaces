using Gizmo.Shared.Exceptions;
using System;
using System.Runtime.Serialization;

namespace ServerService.Exceptions
{
    /// <summary>
    /// Web api exception.
    /// </summary>
    [DataContract()]
    [Serializable()]
    public class WebApiException : ErrorCodeExceptionBase<WebApiErrorCode>
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="errorCode">Error code.</param>
        public WebApiException(WebApiErrorCode errorCode) : base(errorCode)
        {
        }

        /// <summary>
        /// Serialization constructor.
        /// </summary>
        /// <param name="info">Serialization info.</param>
        /// <param name="context">Serialization context.</param>
        protected WebApiException(SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        { }

        #endregion
    }
}
