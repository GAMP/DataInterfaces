namespace ServerService
{
    /// <summary>
    /// Order status error codes.
    /// </summary>
    public enum OrderStatusErrorCode
    {
        /// <summary>
        /// Unspecified.
        /// </summary>
        Unspecified = 0,
        /// <summary>
        /// Already completed.
        /// </summary>
        AlreadyCompleted = 1,
        /// <summary>
        /// Already canceled.
        /// </summary>
        AlreadyCanceled = 2,
        /// <summary>
        /// Already accepted.
        /// </summary>
        AlreadyAccepted = 3,
        /// <summary>
        /// Already invocied.
        /// </summary>
        AlreadyInvoiced = 4,
    }
}
