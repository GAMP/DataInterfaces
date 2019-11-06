using Localization;

namespace ServerService
{
    /// <summary>
    /// Invoice payment error code.
    /// </summary>
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
}
