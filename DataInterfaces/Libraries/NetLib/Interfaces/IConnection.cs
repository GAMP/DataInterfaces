﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using IntegrationLib;

namespace NetLib
{
    #region IConnection
    /// <summary>
    /// Base network connection interface.
    /// </summary>
    public interface IConnection
    {
        #region EVENTS

        event EndpointEventDelegate EndpointBound;
        
        event EndpointEventDelegate EndpointConnected;
        
        event EndpointEventDelegate EndpointConnecting;
        
        event EndpointEventDelegate EndpointConnectionFailed;
        
        event ConnectionEventDelegate EndpointDisconnected;
        
        event ConnectionExceptionDelegate Exception;
        
        event NewConnectionDelegate NewConnection;
        
        event SentRecieveDelegate Received;
        
        event SendingReceivingDelegate Receiving;
        
        event SendingReceivingDelegate Sending;
        
        event SentRecieveDelegate Sent; 
        
        #endregion

        #region PROPERTIES

        bool IsChunckingEnabled { get; set; }

        bool IsChunkingSupported { get; }

        bool IsConnected { get; }

        bool IsConnecting { get; }

        bool IsReceiving { get; }

        bool KeepAlive { get; set; }

        uint KeepAliveInterval { get; set; }

        uint KeepAliveTimeOut { get; set; }

        void Listen(int backlog);

        bool NoDelay { get; set; }

        int ReceiveBufferSize { get; set; }

        uint ReceiveChunkSize { get; set; }

        Socket Socket { get; }

        int SendBufferSize { get; set; }

        uint SendChunkSize { get; set; }

        #endregion

        #region FUNCTIONS
        
        void Bind(System.Net.EndPoint localEP);

        void Bind(System.Net.IPAddress address, int port);

        void Bind(string address, int port);

        ulong BytesReceived { get; }

        ulong BytesSent { get; }

        void Close();

        void Close(int timeOut);

        void Connect(System.Net.EndPoint remoteEP);

        void Connect(System.Net.IPAddress address, int port);

        void Connect(string host, int port);

        void Disconnect(bool reuseSocket);

        void Receive();

        int Receive(byte[] buffer);

        int Receive(byte[] buffer, int offset, int size, System.Net.Sockets.SocketFlags socketFlags);

        int Receive(byte[] buffer, int size, System.Net.Sockets.SocketFlags socketFlags);

        int Send(byte[] buffer);

        int Send(byte[] buffer, int offset, int size, System.Net.Sockets.SocketFlags socketFlags);

        int Send(byte[] buffer, int size, System.Net.Sockets.SocketFlags socketFlags);

        int Send(byte[] buffer, System.Net.Sockets.SocketFlags socketFlags);

        int SendTo(byte[] buffer, ref EndPoint remoteEP);

        void ShutDown(System.Net.Sockets.SocketShutdown how); 

        #endregion        
    } 
    #endregion    

    #region ISmartLaunchConnection
    /// <summary>
    /// Smartlaunch connection interface.
    /// </summary>
    public interface ISmartLaunchConnection : IConnection
    {
        /// <summary>
        /// Gets or sets end of message string.
        /// </summary>
        string EndOfMessageString { get; set; }

        /// <summary>
        /// Sends command over a connection.
        /// </summary>
        /// <param name="data">Command string data.</param>
        /// <param name="useEol">Enables or disables end of line seperator.</param>
        /// <returns>Integer amount of data sent over the connection. Returns 0 in case of disconnection.</returns>
        int Send(string data, bool useEol = true);
        
        /// <summary>
        /// Sends command over a connection.
        /// </summary>
        /// <param name="command">Command.</param>
        /// <param name="arguments">Command parameters.</param>
        /// <returns>Integer amount of data sent over the connection. Returns 0 in case of disconnection.</returns>
        int Send(string command, params string[] arguments);
        
        /// <summary>
        /// Enables or Disables binary data reception.
        /// </summary>
        bool ReceiveBinary { get; set; }
       
        /// <summary>
        /// Occours when a command batch received over a connection.
        /// </summary>
        event CommandsReceivedDelegate CommandsReceived;
    } 
    #endregion
}
