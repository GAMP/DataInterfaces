using System;

namespace NetLib
{
    public class ConnectionChangedArgs : EventArgs
    {
        #region CONSTUCTOR
        public ConnectionChangedArgs(IConnection oldConnection, IConnection newConnection)
        {
            this.OldConnection = oldConnection;
            this.NewConnection = newConnection;
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
