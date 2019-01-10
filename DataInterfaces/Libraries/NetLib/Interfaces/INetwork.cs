using System;

namespace NetLib
{
    #region INetwork
    public interface INetwork
    {
        #region EVENTS
        /// <summary>
        /// Occours when one of network connections is changed.
        /// </summary>
        event EventHandler<ConnectionChangedArgs> ConnectionChanged;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets stream connection.
        /// </summary>
        IConnection StreamConnection
        {
            get;
        }

        /// <summary>
        /// Gets datagram connection.
        /// </summary>
        IConnection DataGramConnection
        {
            get;
        }
        
        #endregion
    } 
    #endregion
}
