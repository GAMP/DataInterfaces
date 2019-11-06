namespace SharedLib.Logging
{
    #region ILogProvider
    /// <summary>
    /// Generic log provider interface.
    /// </summary>
    public interface ILogProvider
    {
        #region PROPERTIES
        /// <summary>
        /// Gets if available.
        /// </summary>
        bool IsAvailable { get; }

        /// <summary>
        /// Gets if provider is open.
        /// </summary>
        bool IsOpened { get; }
        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Opens log provider.
        /// </summary>
        void Open();

        /// <summary>
        /// Closes log provider.
        /// </summary>
        void Close();

        /// <summary>
        /// Adds log message.
        /// </summary>
        /// <param name="messege">Message.</param>
        void AddMessage(ILogMessage messege);

        #endregion
    }
    #endregion
}
