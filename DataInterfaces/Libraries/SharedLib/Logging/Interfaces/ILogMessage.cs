using System;

namespace SharedLib.Logging
{
    #region ILogMessage
    /// <summary>
    /// Defines base log message.
    /// </summary>
    public interface ILogMessage
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets logs message.
        /// </summary>
        string Message { get; }

        /// <summary>
        /// Gets logs message Date Time.
        /// </summary>
        DateTime Time { get; } 

        #endregion
    }
    #endregion
}
