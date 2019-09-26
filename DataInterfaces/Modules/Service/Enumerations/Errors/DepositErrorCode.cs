namespace ServerService
{
    #region DepositErrorCode
    /// <summary>
    /// Deposit transactions error codes.
    /// </summary>
    public enum DepositErrorCode
    {
        Unspecified = 0,
        /// <summary>
        /// Set when we try to execute deposit transaction with zero amount.
        /// </summary>
        AmountZeroOrLess,
        /// <summary>
        /// Set when user has no funds to execute the transaction.
        /// </summary>
        InsufficientFunds,
        /// <summary>
        /// Set when deposit transaction would cause user into negative balance.
        /// </summary>
        NegativeBalanceNotAllowed,
    }
    #endregion
}
