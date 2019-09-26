using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace ServerService.Web.Api
{
    /// <summary>
    /// Web api error response mode.
    /// </summary>
    [DataContract()]
    public class WebApiErrorResponse : WebApiResponseBase
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="statusCode">Http status code.</param>
        public WebApiErrorResponse(int statusCode) : base(statusCode,true)
        {
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="statusCode">Http status code.</param>
        /// <param name="errors">Extended errors.</param>
        public WebApiErrorResponse(int statusCode,IEnumerable<WebApiError> errors) : base(statusCode,true)
        {
            Errors = errors ?? Enumerable.Empty<WebApiError>();
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Extended error information.
        /// </summary>
        [DataMember()]
        public IEnumerable<WebApiError> Errors
        {
            get; protected set;
        }

        /// <summary>
        /// Optional error code.
        /// </summary>
        [DataMember(EmitDefaultValue =false)]
        public int? ErrorCode
        {
            get;set;
        }

        /// <summary>
        /// Optional error code in human readable form.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string ErrorCodeReadable
        {
            get;set;
        }

        /// <summary>
        /// Optional error code object type.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string ErrorCodeType
        {
            get;set;
        }

        #endregion

        #region STATIC FUNCTIONS

        public static WebApiErrorResponse Create(int statusCode)
        {
            return new WebApiErrorResponse(statusCode);
        }

        public static WebApiErrorResponse Create(int statusCode, IEnumerable<WebApiError> errors)
        {
            return new WebApiErrorResponse(statusCode, errors);
        }

        public static WebApiErrorResponse Create(int statusCode, string errorMessage)
        {
            return new WebApiErrorResponse(statusCode, new List<WebApiError>() { new WebApiError(errorMessage) });
        }

        public static WebApiErrorResponse CreateBadRequestResponse(string errorMessage, Enum errorCode)
        {
            var response = Create((int)System.Net.HttpStatusCode.BadRequest, errorMessage);
            response.ErrorCode = Convert.ToInt32(errorCode);
            response.ErrorCodeReadable = errorCode.ToString();
            response.ErrorCodeType = errorCode.GetType().FullName;
            return response;
        }

        #endregion
    }
}
