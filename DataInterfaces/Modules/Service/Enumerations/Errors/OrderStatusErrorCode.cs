namespace ServerService
{
    #region OrderStatusErrorCode
    /// <summary>
    /// Order status error codes.
    /// </summary>
    public enum OrderStatusErrorCode
    {
        Unspecified = 0,
        AlreadyCompleted = 1,
        AlreadyCanceled = 2,
        AlreadyAccepted = 3,
        AlreadyInvoiced = 4,
    }
    #endregion
}
