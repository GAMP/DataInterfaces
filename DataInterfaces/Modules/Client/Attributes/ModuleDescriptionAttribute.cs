using System;
using System.ComponentModel.Composition;

namespace Client
{
    [MetadataAttribute(), AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ModuleDescriptionAttribute : Attribute
    {
        #region CONSTRUCTOR

        public ModuleDescriptionAttribute(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException(nameof(title));

            Title = title;
        }

        public ModuleDescriptionAttribute(string title, string description) : this(title)
        { }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets display title.
        /// </summary>
        public string Title
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets display description.
        /// </summary>
        public string Description
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets if description and title represented by localization keys.
        /// </summary>
        public bool IsLocalized
        {
            get; set;
        }

        #endregion
    }
}
