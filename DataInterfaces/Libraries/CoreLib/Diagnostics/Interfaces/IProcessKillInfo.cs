namespace CoreLib.Diagnostics
{
    /// <summary>
    /// Core process kill info interface.
    /// </summary>
    public interface ICoreProcessKillInfo
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets or sets module path.
        /// </summary>
        string ModulePath { get; set; }

        /// <summary>
        /// Gets or sets process id.
        /// </summary>
        int ProcessId { get; set; }

        /// <summary>
        /// Gets or sets process name.
        /// </summary>
        string ProcessName { get; set; }

        /// <summary>
        /// Gets or sets if recursive termination should be done.
        /// </summary>
        bool Recurse { get; set; }

        /// <summary>
        /// Gets or sets if module path should be respected when terminating matching process.
        /// </summary>
        bool RespectPath { get; set; }

        /// <summary>
        /// Gets or sets if tree termination should be done.
        /// </summary>
        bool Tree { get; set; } 

        #endregion
    } 
}
