namespace Client.ViewModels
{
    /// <summary>
    /// Client app executable view model interface.
    /// </summary>
    public interface IAppExeViewModel
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets caption.
        /// </summary>
        string Caption { get; }

        /// <summary>
        /// Gets executable id.
        /// </summary>
        int ExeId { get; }

        /// <summary>
        /// Gets display order.
        /// </summary>
        int DisplayOrder { get; }

        /// <summary>
        /// Gets if currently active.
        /// </summary>
        bool IsActive { get; }

        /// <summary>
        /// Gets if ready for execution.
        /// </summary>
        bool IsReady { get; }

        /// <summary>
        /// Gets if progress is indeterminate.
        /// </summary>
        bool IsIndeterminate { get; }

        /// <summary>
        /// Gets current progress.
        /// </summary>
        double Progress { get; } 

        #endregion
    } 
}
