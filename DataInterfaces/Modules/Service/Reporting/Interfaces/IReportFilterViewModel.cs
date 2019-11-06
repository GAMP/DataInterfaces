namespace ServerService.Reporting
{
    /// <summary>
    /// Represents a type used to carry default period values to the view.
    /// </summary>
    public interface IReportFilterViewModel
    {
        /// <summary>
        /// Start week day for weekly report default period.
        /// </summary>
        string BusinessStartWeekDay { get; set; }

        /// <summary>
        /// Day start time for default period.
        /// </summary>
        string BusinessDayStart { get; set; }

        /// <summary>
        /// Default period type for report. Available options are: daily, weekly, monthly and yearly.
        /// </summary>
        string PeriodType { get; set; }

    }
}