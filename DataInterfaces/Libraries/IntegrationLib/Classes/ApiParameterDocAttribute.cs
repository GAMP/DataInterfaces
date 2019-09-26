using System;

namespace IntegrationLib
{
    /// <summary>
    /// Attribute used to describe API function parameters.
    /// </summary>
    [Obsolete("Will be replaced with Swagger in the fututre")]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class ApiParameterDocAttribute : Attribute
    {
        #region CONSTRUCTOR
        public ApiParameterDocAttribute(string param, string doc)
        {
            Parameter = param;
            Documentation = doc;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or set parameter name.
        /// </summary>
        public string Parameter { get; set; }

        /// <summary>
        /// Gets or sets documentation.
        /// </summary>
        public string Documentation { get; set; } 
        
        #endregion
    }
}
