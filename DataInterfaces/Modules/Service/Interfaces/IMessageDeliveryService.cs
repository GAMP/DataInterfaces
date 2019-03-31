namespace ServerService.Services
{
    /// <summary>
    /// Generic message delivery service interface.
    /// </summary>
    public interface IMessageDeliveryService
    {
        #region PROPERTIES

        /// <summary>
        /// Gets if service can dispatch messages.
        /// </summary>
        bool CanDispatch { get; }

        #endregion
    }
}
