namespace Manager.ViewModels
{
    /// <summary>
    /// Invoice filter enumeration.,
    /// </summary>
    public enum InvoiceFilterStatus
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,
        /// <summary>
        /// Paid.
        /// </summary>
        Paid = 1,
        /// <summary>
        /// Unpaid.
        /// </summary>
        Unpaid = 2,
        /// <summary>
        /// Partially paid.
        /// </summary>
        PartialyPaid = 4,
        /// <summary>
        /// None.
        /// </summary>
        Any = ~None,
    }
}
