using System;
using System.ComponentModel.Composition;

namespace IntegrationLib
{
    /// <summary>
    /// Metadata attribute for plugins.
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class PluginMetadataAttribute : ExportAttribute, IPluginMetadata
    {
        #region CONSTRUCTOR

        public PluginMetadataAttribute()
        { }

        public PluginMetadataAttribute(string name, string version)
            : base(typeof(IPlugin))
        {
            Name = name;
            Version = version;
        }

        public PluginMetadataAttribute(string name, string version, string description)
            : this(name, version)
        {
            Name = name;
            Version = version;
            Description = description;
        }

        public PluginMetadataAttribute(string name, string version, string description, string iconResource)
            : this(name, version, description)
        {
            if (string.IsNullOrWhiteSpace(iconResource))
                throw new ArgumentNullException(nameof(iconResource));

            IconResource = iconResource;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets plugin name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets plugin version string.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets plugin description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets icon resource name.
        /// </summary>
        public string IconResource
        {
            get;
            set;
        }

        /// <summary>
        /// Gets if icon resource is set.
        /// </summary>
        public bool HasIconResource
        {
            get { return !string.IsNullOrWhiteSpace(this.IconResource); }
        }

        #endregion
    }
}
