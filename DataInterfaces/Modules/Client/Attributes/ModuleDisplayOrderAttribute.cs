using System;
using System.ComponentModel.Composition;

namespace Client
{
    /// <summary>
    /// Display order attribute.
    /// </summary>
    [MetadataAttribute(), AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ModuleDisplayOrderAttribute : Attribute
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="order">Display order.</param>
        public ModuleDisplayOrderAttribute(int order)
        {
            DisplayOrder = order;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets display order.
        /// </summary>
        public int DisplayOrder
        {
            get;
            private set;
        }

        #endregion
    }
}
