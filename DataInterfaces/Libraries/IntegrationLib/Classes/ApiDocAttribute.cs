using System;

namespace IntegrationLib
{
    /// <summary>
    /// Attribute used to describe API functions.
    /// </summary>
    [Obsolete("Will be replaced with Swagger in the fututre")]
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class ApiDocAttribute : Attribute
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="doc"></param>
        public ApiDocAttribute(string doc)
        {
            if (string.IsNullOrWhiteSpace(doc))
                throw new ArgumentNullException(nameof(doc));

            Documentation = doc;
        } 
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets documentation.
        /// </summary>
        public string Documentation { get; set; } 

        #endregion
    }
}
