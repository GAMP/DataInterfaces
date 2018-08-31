using System;

namespace ServerService
{
    #region ILogService
    public interface ILogService
    {
        #region EVENTS
        /// <summary>
        /// Occurs on log change.
        /// </summary>
        event EventHandler<LogChangeEventArgs> LogChange; 
        #endregion
    }
    #endregion
}
