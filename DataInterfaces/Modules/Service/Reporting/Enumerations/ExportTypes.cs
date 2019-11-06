namespace ServerService.Reporting
{
    /// <summary>
    /// Specifies how the export will be returned.
    /// </summary>
    public enum ExportTypes : short
    {
        /// <summary>
        /// The export will be displayed in a grid.
        /// </summary>
        Preview = 1,

        /// <summary>
        /// The export will be returned as a file.
        /// </summary>
        Export = 2,
    }
}