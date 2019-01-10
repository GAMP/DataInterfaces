using System;
using System.ComponentModel.Composition;

namespace Client
{
    #region ModuleGuidAttribute
    [MetadataAttribute(), AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ModuleGuidAttribute : Attribute
    {
        #region CONSTRUCTOR

        public ModuleGuidAttribute(string guid)
        {
            if (string.IsNullOrWhiteSpace(guid))
                throw new ArgumentNullException(nameof(guid));

            Guid = guid;
        }

        public ModuleGuidAttribute(Guid guid)
        {
            Guid = guid.ToString();
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets guid.
        /// </summary>
        public string Guid
        {
            get;
            private set;
        }

        #endregion
    } 
    #endregion
}
