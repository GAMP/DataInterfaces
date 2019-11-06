using System;

namespace ServerService
{
    /// <summary>
    /// Log service.
    /// </summary>
    public interface ILogService
    {
        #region EVENTS
        /// <summary>
        /// Occurs on log change.
        /// </summary>
        event EventHandler<LogChangeEventArgs> LogChange; 
        #endregion
    }
}
