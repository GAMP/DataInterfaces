namespace ServerService.Reporting
{
    /// <summary>
    /// Specifies the period type of the report.
    /// </summary>
    public enum ReportPeriodTypes
    {
        /// <summary>
        /// Daily report.
        /// </summary>
        Daily = 1,

        /// <summary>
        /// Weekly report.
        /// </summary>
        Weekly = 2,

        /// <summary>
        /// Monthly report.
        /// </summary>
        Monthly = 4,

        /// <summary>
        /// Yearly report.
        /// </summary>
        Yearly = 8,

        /// <summary>
        /// Custom report.
        /// </summary>
        Custom = 16
    }
}