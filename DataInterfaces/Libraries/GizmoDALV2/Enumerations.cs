using Localization;

namespace GizmoDALV2
{
    #region EntityEventType
    public enum EntityEventType
    {
        Added,
        Removed,
        Modified,
    }
    #endregion

    #region InvoiceErrorCode
    /// <summary>
    /// Invoice error codes.
    /// </summary>
    public enum InvoiceErrorCode
    {
        /// <summary>
        /// Set when invoice status is already set to paid and we try to execute a payment on it.
        /// </summary>
        AlreadyPaid,
        /// <summary>
        /// Set when we try to fully repay an invoice with amount less than outstanding amount.
        /// </summary>
        AmountLessThanOutstanding,
    }
    #endregion

    #region InvoicePaymentErrorCode
    public enum InvoicePaymentErrorCode
    {
        /// <summary>
        /// Set on unspecified error.
        /// </summary>
        [Localized("UNSPECIFIED")]
        Unspecified = 0,
        /// <summary>
        /// Set when invoice payment amount equals zero.
        /// </summary>
        AmountZeroOrLess,
        /// <summary>
        /// Set when outstanding amount is zero.
        /// </summary>
        OutstandingAmountZero,
        /// <summary>
        /// Set when outstanding amount is less than the payment amount.
        /// </summary>
        OutstandingAmountLess,
    } 
    #endregion

    #region PaymentErrorCode
    /// <summary>
    /// Payment error codes.
    /// </summary>
    public enum PaymentErrorCode
    {
        /// <summary>
        /// Set on unspecified error.
        /// </summary>
        [Localized("UNSPECIFIED")]
        Unspecified = 0,       
        /// <summary>
        /// Set when there are no funds avaliable to execute this payment.
        /// </summary>
        [Localized("PAYMENTERRORCODE_INSUFFICIENT_FUNDS")]
        InsufficientFunds = 1,        
        /// <summary>
        /// Set when payment amount equals zero or less. Zero payments not allowed.
        /// </summary>
        [Localized("PAYMENTERRORCODE_AMOUNT_ZERO_OR_LESS")]
        AmountZeroOrLess = 2,        
        /// <summary>
        /// Set when amount recieved is less than actual payment amount.
        /// </summary>
        [Localized("PAYMENTERRORCODE_AMOUNT_RECEIVED_LESS")]
        AmountReceivedLess = 3,
        /// <summary>
        /// Set when we try to execute a payment with an method that is invalid for payment transaction.
        /// </summary>
        [Localized("PAYMENTERRORCODE_INALID_PAYMENT_METHOD")]
        InvalidPaymentMethod =4,
    }
    #endregion

    #region OrderStatusErrorCode
    /// <summary>
    /// Order status error codes.
    /// </summary>
    public enum OrderStatusErrorCode
    {
        Unspecified = 0,
        AlreadyInvoiced,
        AlreadyCanceled,
        NegativeCost,
    }
    #endregion

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

    #region StockErrorCodes
    public enum StockErrorCodes
    {
        Unspecified = 0,
        /// <summary>
        /// Set when we try to modify stock level of a product that have stock disabled.
        /// </summary>
        StockDisabled=1,
        /// <summary>
        /// Set when we try to create a stock transaction with zero amount.
        /// </summary>
        ZeroAmount=2,
        /// <summary>
        /// Set when we have a TargetDifferentProduct flag on product stock option while not actually targeting specific product.
        /// </summary>
        TargetProductNotSet=3,
    }
    #endregion

    #region ShiftErrorCode
    public enum ShiftErrorCode
    {
        [Localized("SHIFT_ERROR_NO_ACTIVE_SHIFT")]
        NoActiveShift =0,
        [Localized("SHIFT_ERROR_ANOTHER_ACTIVE")]
        AnotherShift =1,
        [Localized("SHIFT_ERROR_ALREADY_ACTIVE")]
        AlreadyActive =2,
        [Localized("SHIFT_ERROR_NO_REGISTER")]
        NoRgister = 3,
        [Localized("SHIFT_ERROR_INVALID_ID")]
        InvalidShiftId = 4,
        [Localized("SHIFT_ERROR_ALREADY_ENDED")]
        AlreadyEnded = 5,
        [Localized("SHIFT_ERROR_DISABLED")]
        ShiftDisabled =6,
        [Localized("SHIFT_ERROR_NO_OPERATOR")]
        NoOperator = 7,
        [Localized("SHIFT_ERROR_ENDING")]
        ShiftEnding= 8,
        [Localized("SHIFT_ERROR_NOT_ENDING")]
        ShiftNotEnding =9,
        [Localized("SHIFT_ERROR_DELETED_REGISTER")]
        DeletedRegister =10,
    }
    #endregion

    #region AssetErrorCode
    public enum AssetErrorCode
    {
        [Localized("ASSET_ERROR_NOT_CHECKED_IN")]
        NotCheckedIn = 0,
        [Localized("ASSET_ERROR_ALREADY_CHECKED_IN")]
        AlreadyCheckedIn = 1,
        [Localized("ASSET_ERROR_DISABLED")]
        AssetDisabled = 2,
    }
    #endregion

    #region WaitingLineErrorCode
    public enum WaitingLineErrorCode
    {
        [Localized("WAITING_LINE_ERROR_ALREADY_IN_WAITING_LINE")]
        AlreadyInWaitingLine = 0,
        [Localized("WAITING_LINE_ERROR_NOT_IN_WAITING_LINE")]
        NotInWaitingLine = 1,
        [Localized("WAITING_LINE_ERROR_DISALLOWED_HOST_GROUP")]
        DisallowedHostGroup = 2,
        [Localized("WAITING_LINE_ERROR_NOT_ACTIVE")]
        NotActive = 3,
        [Localized("WAITING_LINE_ERROR_ALREADY_LOGGED_IN")]
        AlreadyLoggedIn = 4,
    } 
    #endregion
}
