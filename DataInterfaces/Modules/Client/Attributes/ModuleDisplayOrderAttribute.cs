using System;
using System.ComponentModel.Composition;

namespace Client
{
    #region ModuleDisplayOrderAttribute
    /// <summary>
    /// Display order attribute.
    /// </summary>
    [MetadataAttribute(), AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ModuleDisplayOrderAttribute : Attribute
    {
        #region CONSTRUCTOR
        public ModuleDisplayOrderAttribute(int order)
        {
            DiaplayOrder = order;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets display order.
        /// </summary>
        public int DiaplayOrder
        {
            get;
            private set;
        }

        #endregion
    }
    #endregion
}
