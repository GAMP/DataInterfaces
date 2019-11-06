using System;
using System.ComponentModel.Composition;

namespace Client
{
    /// <summary>
    /// Module type attribute.
    /// </summary>
    [MetadataAttribute(), AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ModuleTypeAttribute : Attribute
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="type">Type.</param>
        public ModuleTypeAttribute(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentNullException(nameof(type));

            Type = Type.GetType(type);
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="type">Type.</param>
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
