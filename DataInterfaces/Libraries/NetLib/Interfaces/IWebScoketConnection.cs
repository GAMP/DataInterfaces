using System.Net.WebSockets;

namespace NetLib
{
    /// <summary>
    /// Web socket connection inteface.
    /// </summary>
    public interface IWebScoketConnection : IConnection
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets associated web socket.
        /// </summary>
        WebSocket Socket { get; } 

        #endregion
    }
}
