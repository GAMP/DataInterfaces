namespace ServerService.Reporting.Reports.Financial
{
    /// <summary>
    /// Specifies the payment status of the invoices to display.
    /// </summary>
    public enum InvoicesLogPaymentStatusTypes : short
    {
        /// <summary>
        /// Only paid invoices are displayed.
        /// </summary>
        Paid = 1,

        /// <summary>
        /// Only unpaid invoices are displayed.
        /// </summary>
        Unpaid = 2
    }
}
