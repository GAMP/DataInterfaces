namespace SharedLib.Configuration
{
    /// <summary>
    /// Application module implementation interface.
    /// </summary>
    public interface IApplicationModule
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets file name.
        /// </summary>
        string FileName { get; set; }

        /// <summary>
        /// Gets module type.
        /// </summary>
        ModuleEnum ModuleType { get; set; }

        /// <summary>
        /// Gets module version.
        /// </summary>
        string ModuleVersion { get; set; }

        #endregion

        #region FUNCTIONS
        
        /// <summary>
        /// Gets module string.
        /// </summary>
        /// <returns>Module string.</returns>
        string ToString(); 

        #endregion
    }
}
