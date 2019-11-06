namespace ServerService.Reporting
{
    /// <summary>
    /// Specifies the period type of the report.
    /// </summary>
    public enum ReportPeriodTypes : short
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
        Monthly = 3,

        /// <summary>
        /// Yearly report.
        /// </summary>
        Yearly = 4,

        /// <summary>
        /// Custom report.
        /// </summary>
        Custom = 5
    }
}