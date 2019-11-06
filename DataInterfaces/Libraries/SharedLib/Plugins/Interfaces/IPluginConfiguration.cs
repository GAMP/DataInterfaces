namespace SharedLib.Plugins
{
    /// <summary>
    /// Plugin dll file configuration interface.
    /// </summary>
    public interface IPluginConfiguration
    {
        #region PROPERTIES

        /// <summary>
        /// Plugin dll file name.
        /// </summary>
        string FileName { get; set; }

        /// <summary>
        /// File path.
        /// </summary>
        string FilePath { get; set; }

        /// <summary>
        /// Gets or sets if editable.
        /// </summary>
        bool IsEditable { get; set; }

        /// <summary>
        /// Gets or sets if plugin dll should be loaded.
        /// </summary>
        bool Load { get; set; }

        /// <summary>
        /// Scope.
        /// </summary>
        ModuleScopes Scope { get; set; } 

        #endregion
    }
}
