using Localization;

namespace ServerService
{
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
        InvalidPaymentMethod = 4,
    }
}
