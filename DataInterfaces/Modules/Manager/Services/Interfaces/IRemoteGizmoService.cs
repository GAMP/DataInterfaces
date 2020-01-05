using GizmoDALV2;
using IntegrationLib;
using ServerService;
using SharedLib;
using SharedLib.Dispatcher;
using System;
using System.Threading.Tasks;

namespace Manager.Services
{
    /// <summary>
    /// Remote Gizmo Service implementation iterface.
    /// </summary>
    public interface IRemoteGizmoService :
        IRemoteService,
        IHostServiceAsync,
        IConfigurableServiceAsync,
        IUserServiceAsync,
        ILogService,
        IReservationService
    {

        /// <summary>
        /// Occurs on user balance change completes.
        /// </summary>
        event EventHandler<UserBalanceEventArgs> UserBalanceChangeCompleted;

        /// <summary>
        /// Occurs when host properties changed completed.
        /// </summary>
        event EventHandler<HostPropertiesChangedEventArgs> HostPropertiesChangeCompleted;

        /// <summary>
        /// Gets if service is authenticated.
        /// </summary>
        bool IsAuthenticated { get; }

        /// <summary>
        /// Gets identity of authenticated user.
        /// </summary>
        IUserIdentity Identity { get; }

        /// <summary>
        /// Occurs on service authentication.
        /// </summary>
        event EventHandler<AuthEventArgs> Authenticated;

        /// <summary>
        /// Occurs on entity event.
        /// </summary>
        event EventHandler<IEntityEventArgs> EntityEvent;

        /// <summary>
        /// Gets proxy dispatcher for specified destination.
        /// </summary>
        /// <param name="destId">Destination dispatcher id.</param>
        /// <returns>Dispatcher instance.</returns>
        IMessageDispatcher ProxyDispatcherGet(int destId);

        /// <summary>
        /// Authenticates user asynchronously.
        /// </summary>
        /// <param name="username">User name.</param>
        /// <param name="password">User password.</param>
        /// <returns>Authentication result.</returns>
        Task<AuthResult> AuthenticateAsync(string username, string password);

        /// <summary>
        /// Authenticates user.
        /// </summary>
        /// <param name="username">User name.</param>
        /// <param name="password">User password.</param>
        /// <returns>Authentication result.</returns>
        AuthResult Authenticate(string username, string password);
    }
}
