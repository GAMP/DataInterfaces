using System;

namespace Localization
{
    /// <summary>
    /// Localized object attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class LocalizedAttribute : Attribute
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance of attribute.
        /// </summary>
        /// <param name="resourceKey">Resource key.</param>
        /// <param name="localize">Indicates if value should be localized.</param>
        public LocalizedAttribute(string resourceKey,bool localize=true)
        {
            if (string.IsNullOrWhiteSpace(resourceKey))
                throw new ArgumentNullException("ResourceKey", "Resource key may not be null or empty.");
        
            ResourceKey = resourceKey;
            Localize = localize;
        } 

        #endregion

        #region PROPERTIES

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
