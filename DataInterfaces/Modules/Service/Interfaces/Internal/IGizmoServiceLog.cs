using SharedLib;
using System;

namespace ServerService
{
    /// <summary>
    /// Gizmo service log interface.
    /// </summary>
    public interface IGizmoServiceLog
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Adds log message.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="category">Category.</param>
        /// <param name="logType">Type.</param>
        void LogAdd(string message, LogCategories category, EventTypes logType);

        /// <summary>
        /// Adds information message.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="category">Category.</param>
        void LogAddInformation(string message, LogCategories category);

        /// <summary>
        /// Adds warning message.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="category">Category.</param>
        void LogAddWarning(string message, LogCategories category);

        /// <summary>
        /// Adds event message.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="category">Category.</param>
        void LogAddEvent(string message, LogCategories category);

        /// <summary>
        /// Adds error message.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="ex">Exception.</param>
        /// <param name="category">Category.</param>
        void LogAddError(string message, Exception ex, LogCategories category);

        /// <summary>
        /// Adds log message.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="category">Category.</param>
        void LogAddError(string message, LogCategories category);

        /// <summary>
        /// Removes all log entries from date time specified by <paramref name="time"/> parameter.
        /// </summary>
        /// <param name="time">Start date time.</param>
        void LogRemove(DateTime time); 

        #endregion
    }
}
