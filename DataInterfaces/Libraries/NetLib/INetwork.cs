using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetLib;

namespace NetLib
{
    #region ConnectionChangedArgs
    public class ConnectionChangedArgs : EventArgs
    {
        #region CONSTUCTOR
        public ConnectionChangedArgs(IConnection oldConnection, IConnection newConnection)
        {
            this.oldConnection = oldConnection;
            this.newConnection = newConnection;
        } 
        #endregion

        #region FIELDS
        private IConnection oldConnection, newConnection; 
        #endregion

        #region PROPERTIES
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
        #endregion
    }
    #endregion

    #region INetwork
    public interface INetwork
    {
        #region EVENTS
        event EventHandler<ConnectionChangedArgs> ConnectionChanged;
        #endregion

        #region PROPERTIES
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
        #endregion
    } 
    #endregion
}
