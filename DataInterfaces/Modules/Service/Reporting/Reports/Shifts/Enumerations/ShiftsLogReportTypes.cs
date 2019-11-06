namespace ServerService.Reporting.Reports.Shifts
{
    /// <summary>
    /// Specifies the report type of the shift log report.
    /// </summary>
    public enum ShiftsLogReportTypes : short
    {
        /// <summary>
        /// Only the sum of each shift are displayed.
        /// </summary>
        Simple = 1,

        /// <summary>
        /// Amounts are grouped by payment method.
        /// </summary>
        Detailed = 2
    }
}
