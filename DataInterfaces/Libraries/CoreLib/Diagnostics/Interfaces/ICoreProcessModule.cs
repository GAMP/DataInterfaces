namespace CoreLib.Diagnostics
{
    /// <summary>
    /// Core process module interface.
    /// </summary>
    public interface ICoreProcessModule
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets company name.
        /// </summary>
        string CompanyName { get; }

        /// <summary>
        /// Gets description.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets module name.
        /// </summary>
        string ModuleName { get; }

        /// <summary>
        /// Gets file name.
        /// </summary>
        string FileName { get; }

        /// <summary>
        /// Gets file version.
        /// </summary>
        string FileVersion { get; }

        /// <summary>
        /// Gets icon data.
        /// </summary>
        byte[] IconData { get; } 

        #endregion
    }
}
