using System;

namespace NetLib
{
    /// <summary>
    /// Connection changed event args.
    /// </summary>
    public class ConnectionChangedArgs : EventArgs
    {
        #region CONSTUCTOR
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
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets old connection.
        /// <remarks>
        /// This value can be null if no connection previously existed.
        /// </remarks>
        /// </summary>
        public IConnection OldConnection
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets new connection.
        /// </summary>
        public IConnection NewConnection
        {
            get;
            protected set;
        }

        #endregion
    }
}
