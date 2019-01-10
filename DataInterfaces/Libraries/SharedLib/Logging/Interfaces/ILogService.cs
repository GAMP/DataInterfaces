using System;

namespace SharedLib.Logging
{
    #region ILogService
    public interface ILogService
    {
        /// <summary>
        /// Adds message to the log.
        /// </summary>
        /// <param name="message">Log message.</param>
        void LogAdd(string message);

        /// <summary>
        /// Adds message to the log.
        /// </summary>
        /// <param name="message">String message.</param>
        /// <param name="category">Log category.</param>
        void LogAdd(string message, LogCategories category);

        /// <summary>
        /// Adds message to the log.
        /// </summary>
        /// <param name="messgae">String message.</param>
        /// <param name="ex">Exception.</param>
        /// <param name="category">Log category.</param>
        void LogAddError(string messgae, Exception ex, LogCategories category);

    }
    #endregion
}
