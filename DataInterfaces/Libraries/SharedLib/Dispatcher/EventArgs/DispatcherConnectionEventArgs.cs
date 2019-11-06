using NetLib;
using System;

namespace SharedLib.Dispatcher
{
    /// <summary>
    /// Dispatcher connection event args.
    /// </summary>
    public class DispatcherConnectionEventArgs : EventArgs
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="connection">Connection.</param>
        public DispatcherConnectionEventArgs(IConnection connection)
        {
            Connection = connection ?? throw new ArgumentException(nameof(connection));
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets associated connection.
        /// </summary>
        public IConnection Connection
        {
            get; protected set;
        }

        #endregion
    }
}
