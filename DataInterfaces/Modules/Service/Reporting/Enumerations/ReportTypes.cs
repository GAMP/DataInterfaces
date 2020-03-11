using Localization;

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
        [Localized("REPORTS_APPLICATION_REPORT_TITLE")]
        [HiddenReport]
        ApplicationReport = 1,

        /// <summary>
        /// Report for all applications.
        /// </summary>
        [Localized("REPORTS_APPLICATIONS_REPORT_TITLE")]
        ApplicationsReport = 2,

        /// <summary>
        /// Log of asset transactions.
        /// </summary>
        [Localized("REPORTS_ASSETS_LOG_REPORT_TITLE")]
        AssetsLogReport = 3,

        /// <summary>
        /// Financial report.
        /// </summary>
        [Localized("REPORTS_FINANCIAL_REPORT_TITLE")]
        FinancialReport = 4,

        /// <summary>
        /// Host usage report.
        /// </summary>
        [Localized("REPORTS_HOST_USAGE_REPORT_TITLE")]
        HostUsageReport = 5,

        /// <summary>
        /// Report for a single invoice.
        /// </summary>
        [Localized("REPORTS_INVOICE_REPORT_TITLE")]
        [HiddenReport]
        InvoiceReport = 6,

        /// <summary>
        /// Log of invoices.
        /// </summary>
        [Localized("REPORTS_INVOICES_LOG_REPORT_TITLE")]
        InvoicesLogReport = 7,

        /// <summary>
        /// Report for a single license.
        /// </summary>
        [Localized("REPORTS_LICENSE_REPORT_TITLE")]
        [HiddenReport]
        LicenseReport = 8,

        /// <summary>
        /// Report for all licenses.
        /// </summary>
        [Localized("REPORTS_LICENSES_REPORT_TITLE")]
        LicensesReport = 9,

        /// <summary>
        /// Overview Report.
        /// </summary>
        [Localized("REPORTS_OVERVIEW_REPORT_TITLE")]
        OverviewReport = 10,

        /// <summary>
        /// Report for a single product.
        /// </summary>
        [Localized("REPORTS_PRODUCT_REPORT_TITLE")]
        [HiddenReport]
        ProductReport = 11,

        /// <summary>
        /// Report for all products.
        /// </summary>
        [Localized("REPORTS_PRODUCTS_REPORT_TITLE")]
        ProductsReport = 12,

        /// <summary>
        /// Log of product transactions.
        /// </summary>
        [Localized("REPORTS_PRODUCTS_LOG_REPORT_TITLE")]
        ProductsLogReport = 13,

        /// <summary>
        /// Log of sessions.
        /// </summary>
        [Localized("REPORTS_SESSIONS_LOG_REPORT_TITLE")]
        SessionsLogReport = 14,

        /// <summary>
        /// Log of shifts.
        /// </summary>
        [Localized("REPORTS_SHIFTS_LOG_REPORT_TITLE")]
        ShiftsLogReport = 15,

        /// <summary>
        /// Stock report.
        /// </summary>
        [Localized("REPORTS_STOCK_REPORT_TITLE")]
        StockReport = 16,

        /// <summary>
        /// Report of top users.
        /// </summary>
        [Localized("REPORTS_TOP_USERS_REPORT_TITLE")]
        TopUsersReport = 17,

        /// <summary>
        /// Log of operators financial transactions.
        /// </summary>
        [Localized("REPORTS_TRANSACTIONS_LOG_REPORT_TITLE")]
        TransactionsLogReport = 18,

        /// <summary>
        /// Report for a single user.
        /// </summary>
        [Localized("REPORTS_USER_REPORT_TITLE")]
        [HiddenReport]
        UserReport = 19,

        /// <summary>
        /// Report for all users.
        /// </summary>
        [Localized("REPORTS_USERS_REPORT_TITLE")]
        [HiddenReport]
        UsersReport = 20,

        /// <summary>
        /// Log of Zs.
        /// </summary>
        [Localized("REPORTS_Z_LOG_REPORT_TITLE")]
        ZLogReport = 21,

        /// <summary>
        /// Report for a single Z.
        /// </summary>
        [Localized("REPORTS_Z_REPORT_TITLE")]
        ZReport = 22,

        /// <summary>
        /// Log of orders.
        /// </summary>
        [Localized("REPORTS_ORDERS_LOG_REPORT_TITLE")]
        OrdersLogReport = 23,

        /// <summary>
        /// Statistics of orders.
        /// </summary>
        [Localized("REPORTS_ORDERS_STATISTICS_REPORT_TITLE")]
        OrdersStatisticsReport = 24

    }
}