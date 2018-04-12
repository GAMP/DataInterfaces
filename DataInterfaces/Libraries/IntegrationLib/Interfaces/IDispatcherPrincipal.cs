using SharedLib.Dispatcher;

namespace IntegrationLib
{
    /// <summary>
    /// Dispatcher principal.
    /// </summary>
    public interface IDispatcherPrincipal
    {
        #region PROPERTIES

        /// <summary>
        /// Gets dispatcher.
        /// </summary>
        IMessageDispatcher Dispacther { get; }

        /// <summary>
        /// Gets user identity.
        /// </summary>
        IUserIdentity UserIdentity { get; }

        #endregion
    }
}
