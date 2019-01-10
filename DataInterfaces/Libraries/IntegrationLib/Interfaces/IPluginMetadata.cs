namespace IntegrationLib
{
    /// <summary>
    /// Plugin metadata interface.
    /// </summary>
    public interface IPluginMetadata
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets the name of plugin.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the version of the plugin.
        /// </summary>
        string Version { get; }

        /// <summary>
        /// Gets the description of plugin.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets if icon resource is set.
        /// </summary>
        bool HasIconResource { get; }

        /// <summary>
        /// Gets icon resource name.
        /// </summary>
        string IconResource { get; } 

        #endregion
    }
}
