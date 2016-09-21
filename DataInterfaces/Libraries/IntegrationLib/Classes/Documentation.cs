using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLib
{
    #region ApiDocAttribute
    /// <summary>
    /// Attribute used to describe API functions.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class ApiDocAttribute : Attribute
    {
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

        /// <summary>
        /// Gets or sets documentation.
        /// </summary>
        public string Documentation { get; set; }
    }
    #endregion

    #region ApiParameterDocAttribute
    /// <summary>
    /// Attribute used to describe API function parameters.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class ApiParameterDocAttribute : Attribute
    {
        public ApiParameterDocAttribute(string param, string doc)
        {
            Parameter = param;
            Documentation = doc;
        }

        /// <summary>
        /// Gets or set parameter name.
        /// </summary>
        public string Parameter { get; set; }

        /// <summary>
        /// Gets or sets documentation.
        /// </summary>
        public string Documentation { get; set; }
    }
    #endregion

    public class ApiExampleDocAttribute :Attribute
    {
        public ApiExampleDocAttribute(string example)
        {
            if (string.IsNullOrWhiteSpace(example))
                throw new ArgumentNullException(nameof(example));

            this.Example = example;
        }

        public string Example
        {
            get;protected set;
        }
    }
}
