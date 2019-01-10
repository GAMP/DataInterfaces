using SharedLib.Dispatcher;
using System;
using System.Threading.Tasks;

namespace SharedLib
{
    public interface IRemoteService
    {
        #region EVENTS
        
        /// <summary>
        /// Occurs when service connection state changed.
        /// </summary>
        event EventHandler<DispatcherStateEventArgs> ConnectionStateChange; 

        #endregion

        #region PROPERTIES
        
        /// <summary>
        /// Gets if service is currently connected.
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// Gets message dispatcher.
        /// </summary>
        IMessageDispatcher Dispatcher { get; }

        /// <summary>
        /// Gets total bytes sent.
        /// </summary>
        ulong BytesSent { get; }

        /// <summary>
        /// Gets total bytes received.
        /// </summary>
        ulong BytesReceived { get; }

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Connects to service.
        /// </summary>
        void Connect();

        /// <summary>
        /// Connects to service asynchronously.
        /// </summary>
        Task ConnectAsync();

        /// <summary>
        /// Disconnects from service.
        /// </summary>
        void Disconnect();

        /// <summary>
        /// Disconnects from service asynchronously.
        /// </summary>
        Task DisconnectAsync();

        #endregion
    }
}
