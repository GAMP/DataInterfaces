using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharedLib.Commands;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Windows;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;
using SharedLib.Logging;
using NetLib;
using SharedLib.Dispatcher.Exceptions;

namespace SharedLib.Dispatcher
{
    #region Delegates
    public delegate void ExecuteCommandDelegate(IDispatcherCommand cmd, params object[] parameters);
    public delegate void ConnectionDelegate(IConnection connection);
    public delegate void ConnectionStateDelegate(IMessageDispatcher sender, bool connected);
    public delegate void DispatcherExceptionDelegate(DispatcherException ex, IDispatcherCommand command);
    #endregion

    #region Interfaces
    /// <summary>
    /// Message dispatcher interface.
    /// </summary>
    public interface IMessageDispatcher
    {
        #region Properties
        
        /// <summary>
        /// Gets the list of active outgoing commands.
        /// </summary>
        Dictionary<int, IDispatcherCommand> OutGoingCommands
        {
            get;
        }

        /// <summary>
        /// Gets the list of active incoming commands.
        /// </summary>
        Dictionary<int, IDispatcherCommand> IncomingCommands
        {
            get;
        }

        /// <summary>
        /// Gets or sets the default timeout for newly created commands.
        /// </summary>
        int DefaultTimeout
        {
            get;
            set;
        }

        /// <summary>
        /// Get the connection currently assinged to this dispatcher.
        /// </summary>
        IConnection Connection
        {
            get;
        }

        /// <summary>
        /// Gets list of the command parsers assigned to this dispatcher.
        /// </summary>
        List<ICommandParser> Parsers
        {
            get;
        }

        /// <summary>
        /// Checks if this dispatcher has an active connection.
        /// </summary>
        bool IsValid
        {
            get;
        }

        /// <summary>
        /// Gets the netbios hostname of this connection.
        /// </summary>
        string Hostname
        {
            get;
        }

        /// <summary>
        /// Gets dispatcher id.
        /// </summary>
        int Id
        {
            get;
        }

        int CompressionLevel
        {
            get;
        }

        bool IsCompressionEnabled
        {
            get;
        }

        #endregion

        #region Functions

        bool SetCompressionLevel(int level);

        bool SetProtocolVersion(int version);

        IDispatcherCommand SendRequest(CommandType cmdtype, CommandStates resstates, params  object[] paramarray);

        IDispatcherCommand SendRequest(CommandType cmdtype, params  object[] paramarray);

        bool TrySend(IDispatcherCommand cmd);

        /// <summary>
        /// Sends the command.
        /// </summary>
        /// <param name="cmd"></param>
        void Send(IDispatcherCommand cmd);

        /// <summary>
        /// Gets a new instance of request command.
        /// </summary>
        /// <param name="cmdtype">Command type.</param>
        /// <param name="resstates">Respond states that this command should send back.</param>
        /// <param name="parameters">Command parameters.</param>
        /// <returns>IDispatcherCommand command instance.</returns>
        IDispatcherCommand GetRequestCommand(CommandType cmdtype, CommandStates resstates, params Object[] parameters);      

        IDispatcherCommand GetResponseCommand(IDispatcherCommand cmd, CommandStates resstates, params Object[] parameters);

        ISyncOperation CreateSyncOperation(CommandType cmdType, int timeout, params object[] paramArray);

        ISyncOperation CreateSyncOperation(CommandType cmdType, params object[] paramArray);

        /// <summary>
        /// Resetd the dispatcher and aborts the active operations.
        /// </summary>
        void Reset();

        /// <summary>
        /// Tries to parse the command.
        /// </summary>
        /// <param name="cmd">Command to parse.</param>
        /// <returns></returns>
        bool TryParse(IDispatcherCommand cmd);

        /// <summary>
        /// Ataches a new connection to this dispatcher.
        /// </summary>
        /// <param name="connection"></param>
        void AttachConnection(IConnection connection);

        /// <summary>
        /// Detaches the connection specified from this dispatcher.
        /// </summary>
        /// <param name="connection"></param>
        void DetachConnection(IConnection connection);

        /// <summary>
        /// Detaches current connection if one set.
        /// </summary>
        void DetachCurrent();

        #endregion

        #region Events
        
        /// <summary>
        /// Occours when a connection attached to this command dispatcher.
        /// </summary>
        event ConnectionDelegate ConnectionAttached;

        /// <summary>
        /// Occours when connection detached from this dispatcher.
        /// </summary>
        event ConnectionDelegate ConnectionDetached;

        /// <summary>
        /// Occours when state of the connection attached to this dispatcher is changed.
        /// </summary>
        event ConnectionStateDelegate ConnectionStateChanged;

        /// <summary>
        /// Occours when Unhandeled exception occours in this dispatcher.
        /// </summary>
        event DispatcherExceptionDelegate DispatcherException; 

        #endregion
    }
    #endregion    
}
