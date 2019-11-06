using System;

namespace SharedLib.Dispatcher
{
    /// <summary>
    /// Dispatcher state event args.
    /// </summary>
    public class DispatcherStateEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="isConnected">Indicates if dispatcher is connected.</param>
        public DispatcherStateEventArgs(bool isConnected)
        {
            IsConnected = isConnected;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets if dispatcher is connected.
        /// </summary>
        public bool IsConnected
        {
            get; protected set;
        }

        #endregion
    }
}
