using System.ComponentModel;
using System.Runtime.Serialization;

namespace ServerService.Web.Api
{
    /// <summary>
    /// Represents web api validation error.
    /// </summary>
    [DataContract()]
    public class WebApiValidationError : WebApiError
    {
        #region CONSTRUCTOR
        public WebApiValidationError(string propertyName, string errorMessage) : base(errorMessage)
        {
            PropertyName = propertyName;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Property name.
        /// </summary>
        [DefaultValue(null)]
        [DataMember(EmitDefaultValue = false)]
        public string PropertyName
        {
            get; protected set;
        } 
        #endregion
    }
}
