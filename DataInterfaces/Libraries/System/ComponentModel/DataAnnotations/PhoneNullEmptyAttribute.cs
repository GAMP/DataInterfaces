using System.Text.RegularExpressions;

namespace System.ComponentModel.DataAnnotations
{
    #region PhoneNullEmptyAttribute
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class PhoneNullEmptyAttribute : DataTypeAttribute
    {
        private static Regex _regex;

        static PhoneNullEmptyAttribute()
        {
            PhoneNullEmptyAttribute._regex = new Regex("^(\\+\\s?)?((?<!\\+.*)\\(\\+?\\d+([\\s\\-\\.]?\\d+)?\\)|\\d+)([\\s\\-\\.]?(\\(\\d+([\\s\\-\\.]?\\d+)?\\)|\\d+))*(\\s?(x|ext\\.?)\\s?\\d+)?$", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled);
        }

        public PhoneNullEmptyAttribute()
            : base(DataType.PhoneNumber)
        {

        }

        public override bool IsValid(object value)
        {
            string stringPhone = value as string;
            return string.IsNullOrWhiteSpace(stringPhone) || PhoneNullEmptyAttribute._regex.Match(stringPhone).Length > 0;
        }
    }
    #endregion
}
