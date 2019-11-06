namespace ServerService.Reporting
{
    /// <summary>
    /// Defines report types.
    /// </summary>
    public enum ReportTypes : short
    {
        /// <summary>
        /// Report for a single application.
        /// </summary>
        ApplicationReport = 1,

        /// <summary>
        /// Report for all applications.
        /// </summary>
        ApplicationsReport = 2,

        /// <summary>
        /// Log of asset transactions.
        /// </summary>
        AssetsLogReport = 3,

        /// <summary>
        /// Financial report.
        /// </summary>
        FinancialReport = 4,

        /// <summary>
        /// Host usage report.
        /// </summary>
        HostUsageReport = 5,

        /// <summary>
        /// Report for a single invoice.
        /// </summary>
        InvoiceReport = 6,

        /// <summary>
        /// Log of invoices.
        /// </summary>
        InvoicesLogReport = 7,

        /// <summary>
        /// Report for a single license.
        /// </summary>
        LicenseReport = 8,

        /// <summary>
        /// Report for all licenses.
        /// </summary>
        LicensesReport = 9,

        /// <summary>
        /// Overview Report.
        /// </summary>
        OverviewReport = 10,

        /// <summary>
        /// Report for a single product.
        /// </summary>
        ProductReport = 11,

        /// <summary>
        /// Report for all products.
        /// </summary>
        ProductsReport = 12,

        /// <summary>
        /// Log of product transactions.
        /// </summary>
        ProductsLogReport = 13,

        /// <summary>
        /// Log of sessions.
        /// </summary>
        SessionsLogReport = 14,

        /// <summary>
        /// Log of shifts.
        /// </summary>
        ShiftsLogReport = 15,

        /// <summary>
        /// Stock report.
        /// </summary>
        StockReport = 16,

        /// <summary>
        /// Report of top users.
        /// </summary>
        TopUsersReport = 17,

        /// <summary>
        /// Log of operators financial transactions.
        /// </summary>
        TransactionsLogReport = 18,

        /// <summary>
        /// Report for a single user.
        /// </summary>
        UserReport = 19,

        /// <summary>
        /// Report for all users.
        /// </summary>
        UsersReport = 20,

        /// <summary>
        /// Log of Zs.
        /// </summary>
        ZLogReport = 21,

        /// <summary>
        /// Report for a single Z.
        /// </summary>
        ZReport = 22,

        /// <summary>
        /// Log of orders.
        /// </summary>
        OrdersLogReport = 23
    }
}