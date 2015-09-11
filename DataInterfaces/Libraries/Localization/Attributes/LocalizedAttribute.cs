using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Localization
{
    /// <summary>
    /// Localized object attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class LocalizedAttribute : Attribute
    {
        #region Constructor
     
        /// <summary>
        /// Creates new instance of attribute.
        /// </summary>
        /// <param name="resource_key">Resource key.</param>
        public LocalizedAttribute(string resource_key,bool localize=true)
        {
            if (String.IsNullOrWhiteSpace(resource_key))
            {
                throw new ArgumentNullException("ResourceKey", "Resource key may not be null or empty.");
            }
            this.ResourceKey = resource_key;
            this.Localize = localize;
        } 

        #endregion

        #region Properties

        /// <summary>
        /// Gets the resource key for this attribute.
        /// </summary>
        public string ResourceKey
        {
            get;
            protected set;
        }
       
        /// <summary>
        /// Gets if value should be localized.
        /// </summary>
        public bool Localize
        {
            get;
            protected set;
        }

        #endregion
    }
}
