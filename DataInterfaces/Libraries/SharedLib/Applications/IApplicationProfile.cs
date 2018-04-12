namespace SharedLib.Applications
{
    /// <summary>
    /// Application profile interface.
    /// </summary>
    public interface IApplicationProfile
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets application id.
        /// </summary>
        int ID { get; }

        /// <summary>
        /// Gets publisher name.
        /// </summary>
        string PublisherName { get; }

        /// <summary>
        /// Gets developer name.
        /// </summary>
        string DeveloperName { get; }

        /// <summary>
        /// Gets title.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Gets age rating.
        /// </summary>
        int AgeRating { get; }

        /// <summary>
        /// Gets if execution should halt on error.
        /// </summary>
        bool HaltOnError { get; } 

        #endregion
    }
}
