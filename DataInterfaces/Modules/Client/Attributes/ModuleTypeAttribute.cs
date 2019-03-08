using System;
using System.ComponentModel.Composition;

namespace Client
{
    [MetadataAttribute(), AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ModuleTypeAttribute : Attribute
    {
        #region CONSTRUCTOR

        public ModuleTypeAttribute(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentNullException(nameof(type));

            Type = Type.GetType(type);
        }

        public ModuleTypeAttribute(Type type)
        {
            Type = type;
        }

        #endregion

        #region PROPERTIES
        
        /// <summary>
        /// Gets module type.
        /// </summary>
        public Type Type
        {
            get; protected set;
        } 

        #endregion
    }
}
