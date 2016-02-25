using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace IntegrationLib
{
    #region PluginMetadataAttribute
    /// <summary>
    /// Metadata attribute for plugins.
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class PluginMetadataAttribute : ExportAttribute, IPluginMetadata
    {
        #region Constructor

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

        public PluginMetadataAttribute(string name, string version, string description, string icon)
            : this(name, version, description)
        {
            #region Validation
            if (String.IsNullOrWhiteSpace(icon))
                throw new ArgumentNullException("Icon");
            #endregion

            IconResource = icon;
        }

        #endregion

        #region Properties

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
    #endregion
}
