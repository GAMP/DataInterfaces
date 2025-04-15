using System;

namespace NetLib
{
    /// <summary>
    /// Connection changed event args.
    /// </summary>
    public sealed class ConnectionChangedArgs : EventArgs
    {
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="oldConnection">Old connection.</param>
        /// <param name="newConnection">New connection.</param>
        public ConnectionChangedArgs(IConnection oldConnection, IConnection newConnection)
        {
            OldConnection = oldConnection;
            NewConnection = newConnection;
        }

        /// <summary>
        /// Gets old connection.
        /// <remarks>
        /// This value can be null if no connection previously existed.
        /// </remarks>
        /// </summary>
        public IConnection OldConnection
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets new connection.
        /// </summary>
        public IConnection NewConnection
        {
            get;
            private set;
        }
    }
}
