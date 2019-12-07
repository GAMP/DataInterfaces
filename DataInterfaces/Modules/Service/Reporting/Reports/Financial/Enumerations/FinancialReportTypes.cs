namespace ServerService.Reporting.Reports.Financial
{
    /// <summary>
    /// Specifies the type of the financial report.
    /// </summary>
    public enum FinancialReportTypes : short
    {
        /// <summary>
        /// Only the sum of each category are displayed.
        /// </summary>
        Simple = 1,

        /// <summary>
        /// Categories are grouped by user group.
        /// </summary>
        GroupByUserGroup = 2,

        /// <summary>
        /// All records are displayed.
        /// </summary>
        Detailed = 3
    }
}
