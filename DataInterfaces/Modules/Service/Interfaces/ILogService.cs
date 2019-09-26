using System;

namespace ServerService
{
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
