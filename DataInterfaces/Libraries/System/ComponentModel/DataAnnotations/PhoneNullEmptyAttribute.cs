using System.Text.RegularExpressions;

namespace System.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Phone null or empty validation attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class PhoneNullEmptyAttribute : DataTypeAttribute
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Static constructor.
        /// </summary>
        static PhoneNullEmptyAttribute()
        {
            PhoneNullEmptyAttribute._regex = new Regex("^(\\+\\s?)?((?<!\\+.*)\\(\\+?\\d+([\\s\\-\\.]?\\d+)?\\)|\\d+)([\\s\\-\\.]?(\\(\\d+([\\s\\-\\.]?\\d+)?\\)|\\d+))*(\\s?(x|ext\\.?)\\s?\\d+)?$", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled);
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        public PhoneNullEmptyAttribute()
            : base(DataType.PhoneNumber)
        {

        }

        #endregion

        #region STATIC FIELDS
        private static Regex _regex;
        #endregion

        #region OVERRIDES
        
        /// <summary>
        /// Gets if value is valid.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <returns>True or false.</returns>
        public override bool IsValid(object value)
        {
            string stringPhone = value as string;
            return string.IsNullOrWhiteSpace(stringPhone) || PhoneNullEmptyAttribute._regex.Match(stringPhone).Length > 0;
        } 

        #endregion
    }
}
