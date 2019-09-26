using System.ComponentModel;
using System.Runtime.Serialization;

namespace ServerService.Web.Api
{
    [DataContract()]
    public class WebApiResponse<T> : WebApiResponseBase
    {
        #region CONSTRUCTOR

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
            get;protected set;
        }

        /// <summary>
        /// Gets response message.
        /// </summary>
        [DefaultValue(null)]
        [DataMember(EmitDefaultValue = false, IsRequired = false)]
        public string Message
        {
            get; protected set;
        }

        /// <summary>
        /// Gets response result.
        /// </summary>
        [DefaultValue(null)]
        [DataMember(EmitDefaultValue = false, IsRequired = false)]
        public T Result
        {
            get; protected set;
        } 

        #endregion
    }
}
