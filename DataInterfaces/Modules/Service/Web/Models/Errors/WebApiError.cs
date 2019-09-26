using System.Runtime.Serialization;

namespace ServerService.Web.Api
{
    /// <summary>
    /// Represents web api error.
    /// </summary>
    [DataContract()]
    public class WebApiError
    {
        #region CONSTRUCTOR
        public WebApiError(string message)
        {
            Message = message;
        }
        #endregion

        #region PROPERTIES
        
        /// <summary>
        /// Error message.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string Message
        {
            get; protected set;
        } 

        #endregion
    }
}
