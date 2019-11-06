using System.ComponentModel;
using System.Runtime.Serialization;

namespace ServerService.Web.Api
{
    /// <summary>
    /// Generic web api response with result.
    /// </summary>
    /// <typeparam name="T">Result type.</typeparam>
    [DataContract()]
    public class WebApiResponse<T> : WebApiResponseBase
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        public WebApiResponse() {}

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="result">Result type.</param>
        /// <param name="statusCode">HTTP Status code.</param>
        public WebApiResponse(T result, int statusCode) : base(statusCode)
        {
            Result = result;
        } 

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Get response version.
        /// </summary>
        [DefaultValue(null)]
        [DataMember(EmitDefaultValue = false, IsRequired = false)]
        public string Version
        {
            get;set;
        }

        /// <summary>
        /// Gets response message.
        /// </summary>
        [DefaultValue(null)]
        [DataMember(EmitDefaultValue = false, IsRequired = false)]
        public string Message
        {
            get; set;
        }

        /// <summary>
        /// Gets response result.
        /// </summary>
        [DefaultValue(null)]
        [DataMember(EmitDefaultValue = false, IsRequired = false)]
        public T Result
        {
            get; set;
        } 

        #endregion
    }
}
