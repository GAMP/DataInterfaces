using System.Collections.Generic;
using SharedLib.Commands;
using NetLib;
using System;
using System.Security.Principal;

namespace SharedLib.Dispatcher
{
    #region INTERFACES
    /// <summary>
    /// Message dispatcher interface.
    /// </summary>
    public interface IMessageDispatcher : CyClone.Core.IBufferManager
    {
        #region PROPERTIES

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
        /// Checks if this dispatcher has an active connection thus is valid.
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

        /// <summary>
        /// Gets compression level.
        /// </summary>
        int CompressionLevel
        {
            get;
        }

        /// <summary>
        /// Gets if compression is enabled.
        /// </summary>
        bool IsCompressionEnabled
        {
            get;
        }

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Sets current thread principal.
        /// </summary>
        /// <param name="principal">Thread principal to use for spawned tasks threads.</param>
        void SetPrincipal(IPrincipal principal);

        /// <summary>
        /// Sets compression level.
        /// </summary>
        /// <param name="level">Level.</param>
        /// <returns>True for scuccess otherwise false.</returns>
        bool SetCompressionLevel(int level);

        /// <summary>
        /// Sets protocol version.
        /// </summary>
        /// <param name="version">Version.</param>
        /// <returns>True for scuccess otherwise false.</returns>
        bool SetProtocolVersion(int version);

        /// <summary>
        /// Tires to send command.
        /// </summary>
        /// <param name="cmd">Command instance.</param>
        /// <returns>True for sucess otherwise false.</returns>
        bool TrySend(IDispatcherCommand cmd);

        /// <summary>
        /// Sends the command.
        /// </summary>
        /// <param name="cmd">Command instance.</param>
        void Send(IDispatcherCommand cmd);

        /// <summary>
        /// Sends the command.
        /// </summary>
        /// <param name="cmd">Command instance.</param>
        /// <param name="parameterBuffer">Parameter buffer.</param>
        /// <param name="parameterOffset">Prameter start offset.</param>
        /// <param name="parameterCount">Parameter buffer count.</param>
        void Send(IDispatcherCommand cmd, byte[] parameterBuffer, int parameterOffset, int parameterCount);

        /// <summary>
        /// Resetd the dispatcher and aborts the active operations.
        /// </summary>
        void Reset();

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

        /// <summary>
        /// Gets a new instance of request command.
        /// </summary>
        /// <param name="cmdtype">Command type.</param>
        /// <param name="resstates">Respond states that this command should send back.</param>
        /// <param name="parameters">Command parameters.</param>
        /// <returns>Command instance.</returns>
        IDispatcherCommand GetRequestCommand(CommandType cmdtype, CommandStates resstates, params object[] parameters);

        /// <summary>
        /// Gets new instance of response command.
        /// </summary>
        /// <param name="cmd">Source command.</param>
        /// <param name="resstates">Response states.</param>
        /// <param name="parameters">Parameters.</param>
        /// <returns>Command instance.</returns>
        IDispatcherCommand GetResponseCommand(IDispatcherCommand cmd, CommandStates resstates, params object[] parameters);

        /// <summary>
        /// Gets new instance of response command with single parameters.
        /// </summary>
        /// <param name="cmd">Source command.</param>
        /// <param name="responseStates">Response states.</param>
        /// <param name="parameters">Parameters.</param>
        /// <returns>Command instance.</returns>
        IDispatcherCommand GetResponseCommandWithParam(IDispatcherCommand cmd, CommandStates responseStates, object parameters);

        #region SYNC OPERATION

        /// <summary>
        /// Creates sync operation with single parameter.
        /// </summary>
        /// <param name="cmdType">Operation type.</param>
        /// <param name="timeout">Operation timeout.</param>
        /// <param name="parameters">Operation parameters.</param>
        ISyncOperation CreateSyncOperationWithParam(CommandType cmdType, int timeout, object parameters = null);

        /// <summary>
        /// Creates sync operation with single parameters.
        /// </summary>
        /// <param name="cmdType">Operation type.</param>
        /// <param name="parameters">Operation parameters.</param>
        ISyncOperation CreateSyncOperationWithParam(CommandType cmdType, object parameters = null);

        /// <summary>
        /// Creates sync operation with multiple parameters.
        /// </summary>
        /// <param name="cmdType">Operation type.</param>
        /// <param name="timeout">Operation timeout.</param>
        /// <param name="parameters">Operation parameters.</param>
        ISyncOperation CreateSyncOperation(CommandType cmdType, int timeout, params object[] parameters);

        /// <summary>
        /// Creates sync operation with multiple parameters.
        /// </summary>
        /// <param name="cmdType">Operation type.</param>
        /// <param name="parameters">Operation parameters.</param>
        ISyncOperation CreateSyncOperation(CommandType cmdType, params object[] parameters);

        #endregion

        #endregion

        #region EVENTS

        /// <summary>
        /// Occurs when connection attached to this command dispatcher.
        /// </summary>
        event EventHandler<DispatcherConnectionEventArgs> ConnectionAttached;

        /// <summary>
        /// Occurs when connection detached from this dispatcher.
        /// </summary>
        event EventHandler<DispatcherConnectionEventArgs> ConnectionDetached;

        /// <summary>
        /// Occurs when state of the connection attached to this dispatcher changes.
        /// </summary>
        event EventHandler<DispatcherStateEventArgs> ConnectionStateChanged;

        /// <summary>
        /// Occurs on dispatcher exception.
        /// </summary>
        event EventHandler<DispatcherExceptionEventArgs> DispatcherException;

        #endregion
    }
    #endregion  
}
