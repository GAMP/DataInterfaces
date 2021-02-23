namespace ServerService
{
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
        /// <summary>
        /// Set when we try to perform an action on a void invoice.
        /// </summary>
        Void,
    }
}
