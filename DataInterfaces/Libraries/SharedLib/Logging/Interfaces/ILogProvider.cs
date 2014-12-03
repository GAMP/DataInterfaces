using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedLib.Logging
{
    #region ILog
    /// <summary>
    /// Log class interface.
    /// <remarks>Applied to a class that handles log messages.</remarks>
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// Adds message to the log.
        /// </summary>
        /// <param name="message">Log message.</param>
        void AddMessage(ILogMessage message);

        /// <summary>
        /// Adds specified string message to the log.
        /// </summary>
        /// <param name="message">String message.</param>
        /// <param name="category">Log category.</param>
        void AddInformation(string message, LogCategories category);

        /// <summary>
        /// Adds excpetion message to the log.
        /// </summary>
        /// <param name="messgae">String message.</param>
        /// <param name="ex">Exception.</param>
        /// <param name="category">Log category.</param>
        void AddError(string messgae, Exception ex, LogCategories category);

        /// <summary>
        /// Gets Cache log provider.
        /// </summary>
        ILogProvider CacheLogProvider { get; }

        /// <summary>
        /// Gets base log provider.
        /// </summary>
        ILogProvider BaseLogProvider { get; }
    }
    #endregion

    #region ILogProvider
    /// <summary>
    /// Generic log provider interface.
    /// </summary>
    public interface ILogProvider
    {
        void Open();
        void Close();
        bool IsAvailable { get; }
        void AddMessage(ILogMessage messege);
        bool IsOpened { get; }
    }
    #endregion

    #region ILogMessage
    public interface ILogMessage
    {
        /// <summary>
        /// Gets the log message id.
        /// </summary>
        int ID { get; }

        /// <summary>
        /// Gets or sets log message HostName.
        /// </summary>
        string Host { get; }

        /// <summary>
        /// Gets logs message.
        /// </summary>
        string Message { get; }

        /// <summary>
        /// Gets logs message Date Time.
        /// </summary>
        DateTime Time { get; }
    }
    #endregion

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
        void LogAdd(string messgae, Exception ex, LogCategories category);
    } 
    #endregion
}
