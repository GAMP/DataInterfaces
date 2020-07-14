namespace ServerService.Reporting.Reports.Transactions
{
    /// <summary>
    /// Action types included in transactions log report.
    /// </summary>
    public enum TransactionsLogActionTypes : short
    {
        /// <summary>
        /// Only deposits and withdrawals are included.
        /// </summary>
        DepositsWithdrawals = 1,

        /// <summary>
        /// Only invoices are included.
        /// </summary>
        Invoices = 2,

        /// <summary>
        /// Only payments are included.
        /// </summary>
        Payments = 3,

        /// <summary>
        /// Only voids and refunds are included.
        /// </summary>
        VoidsRefunds = 4,

        /// <summary>
        /// Only pay in and pay out transactions are included.
        /// </summary>
        PayInOut = 5,
    }
}
