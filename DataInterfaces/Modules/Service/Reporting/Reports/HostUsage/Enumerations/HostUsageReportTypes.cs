namespace ServerService.Reporting.Reports.Hosts
{
    /// <summary>
    /// Specifies the type of the host usage report.
    /// </summary>
    public enum HostUsageReportTypes : short
    {
        /// <summary>
        /// Only the sum of each host category are displayed.
        /// </summary>
        Simple = 1,

        /// <summary>
        /// Host categories are grouped by user group.
        /// </summary>
        GroupByUserGroup = 2,

        /// <summary>
        /// All records are displayed.
        /// </summary>
        Detailed = 3
    }
}
