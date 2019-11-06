namespace ServerService.Reporting
{
    /// <summary>
    /// Represents a type used to specify how the report renders.
    /// </summary>
    public interface IReportFilter
    {
        /// <summary>
        /// Export as pdf.
        /// </summary>
        bool? Pdf { get; set; }

        /// <summary>
        /// Render partial view.
        /// </summary>
        bool? Partial { get; set; }
    }
}