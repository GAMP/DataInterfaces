using System;
using System.ComponentModel.Composition;

namespace Client
{
    /// <summary>
    /// Used tot add material design icon to module.
    /// </summary>
    [MetadataAttribute(), AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ModuleIconAttribute : Attribute
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="iconResource">Icon resource.</param>
        public ModuleIconAttribute(string iconResource)
        {
            if (string.IsNullOrWhiteSpace(iconResource))
                throw new ArgumentNullException(nameof(iconResource));

            IconResource = iconResource;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets icon resource.
        /// </summary>
        public string IconResource
        {
            get;
            private set;
        }

        #endregion
    }
}
