using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetLib;

namespace NetLib
{
    #region Delegates
    public delegate void ConnectionChangedDelegate(object sender, ConnectionChangedArgs e);
    #endregion
    #region EventArguments
    public class ConnectionChangedArgs : EventArgs
    {
        public ConnectionChangedArgs(IConnection oldConnection, IConnection newConnection)
        {
            this.oldConnection = oldConnection;
            this.newConnection = newConnection;
        }
        private IConnection oldConnection, newConnection;
        /// <summary>
        /// Gets the instance of old connection.
        /// <remarks>This value can be null if no connection existed.</remarks>
        /// </summary>
        public IConnection OldConnection
        {
            get { return this.oldConnection; }
        }
        /// <summary>
        /// Gets the instance of new connection.
        /// </summary>
        public IConnection NewConnection
        {
            get { return this.newConnection; }
        }
    }
    #endregion
    public interface INetwork
    {
        event ConnectionChangedDelegate ConnectionChanged;
        IConnection StreamConnection
        {
            get;
            set;
        }
        IConnection DataGramConnection
        {
            get;
            set;
        }
    }
}
