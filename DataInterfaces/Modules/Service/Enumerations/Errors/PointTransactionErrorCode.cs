namespace ServerService
{
    #region PointTransactionErrorCode
    public enum PointTransactionErrorCode
    {
        Unspecified = 0,
        /// <summary>
        /// Set when we try to execute transaction with zero amount.
        /// </summary>
        AmountZeroOrLess = 1,
        /// <summary>
        /// Set when user has no funds to execute the transaction.
        /// </summary>
        InsufficientFunds = 2,
        /// <summary>
        /// Transaction type not supporeted.
        /// </summary>
        TransactionTypeNotSupported = 3,
    }
    #endregion
}
