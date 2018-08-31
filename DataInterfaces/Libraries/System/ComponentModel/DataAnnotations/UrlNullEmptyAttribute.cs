using System.Text.RegularExpressions;

namespace System.ComponentModel.DataAnnotations
{
    #region UrlNullEmptyAttribute
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class UrlNullEmptyAttribute : DataTypeAttribute
    {
        #region STATIC FIELDS
        private readonly static Regex _regex = new Regex("^(https?|ftp):\\/\\/(((([a-z]|\\d|-|\\.|_|~|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])|(%[\\da-f]{2})|[!\\$&'\\(\\)\\*\\+,;=]|:)*@)?(((\\d|[1-9]\\d|1\\d\\d|2[0-4]\\d|25[0-5])\\.(\\d|[1-9]\\d|1\\d\\d|2[0-4]\\d|25[0-5])\\.(\\d|[1-9]\\d|1\\d\\d|2[0-4]\\d|25[0-5])\\.(\\d|[1-9]\\d|1\\d\\d|2[0-4]\\d|25[0-5]))|((([a-z]|\\d|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])|(([a-z]|\\d|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])([a-z]|\\d|-|\\.|_|~|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])*([a-z]|\\d|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])))\\.)+(([a-z]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])|(([a-z]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])([a-z]|\\d|-|\\.|_|~|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])*([a-z]|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])))\\.?)(:\\d*)?)(\\/((([a-z]|\\d|-|\\.|_|~|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])|(%[\\da-f]{2})|[!\\$&'\\(\\)\\*\\+,;=]|:|@)+(\\/(([a-z]|\\d|-|\\.|_|~|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])|(%[\\da-f]{2})|[!\\$&'\\(\\)\\*\\+,;=]|:|@)*)*)?)?(\\?((([a-z]|\\d|-|\\.|_|~|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])|(%[\\da-f]{2})|[!\\$&'\\(\\)\\*\\+,;=]|:|@)|[\\uE000-\\uF8FF]|\\/|\\?)*)?(\\#((([a-z]|\\d|-|\\.|_|~|[\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\uFFEF])|(%[\\da-f]{2})|[!\\$&'\\(\\)\\*\\+,;=]|:|@)|\\/|\\?)*)?$", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled);
        #endregion

        #region CONSTRUCTOR

        public UrlNullEmptyAttribute() : base(DataType.Url)
        {
        }

        #endregion

        #region OVERRIDES

        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            string STRING_VALUE = value as string;

            if (string.IsNullOrWhiteSpace(STRING_VALUE))
                return true;

            return UrlNullEmptyAttribute._regex.Match(STRING_VALUE).Length > 0;
        } 
        
        #endregion
    }
    #endregion
}
