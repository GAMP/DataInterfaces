namespace ServerService.Reporting
{
    /// <summary>
    /// Specifies the data type of the field.
    /// </summary>
    public enum ExportFieldTypes : short
    {
        /// <summary>
        /// The field is boolean.
        /// </summary>
        Boolean = 1,

        /// <summary>
        /// The field is numeric integer.
        /// </summary>
        NumericInteger = 2,

        /// <summary>
        /// The field is numeric decimal.
        /// </summary>
        NumericDecimal = 3,

        /// <summary>
        /// The field is a date.
        /// </summary>
        Date = 4,

        /// <summary>
        /// The field is date with time.
        /// </summary>
        Datetime = 5,

        /// <summary>
        /// The field is text.
        /// </summary>
        Text = 6,

        /// <summary>
        /// The field is a lookup.
        /// </summary>
        Lookup = 7,
    }
}