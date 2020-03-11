using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CoreLib
{
    /// <summary>
    /// String extension class.
    /// </summary>
    public static class StringExtensions
    {
        #region FUNCTIONS
        
        /// <summary>
        /// Replaces a string value.
        /// </summary>
        /// <param name="source">Source string.</param>
        /// <param name="oldValue">Previous string value.</param>
        /// <param name="newValue">New string value.</param>
        /// <param name="comparisonType">Comparison type.</param>
        /// <returns>New string.</returns>
        public static string Replace(this string source, string oldValue, string newValue, StringComparison comparisonType)
        {
            int startIndex = 0;
            while (true)
            {
                startIndex = source.IndexOf(oldValue, startIndex, comparisonType);
                if (startIndex == -1)
                    break;

                source = source.Substring(0, startIndex) + newValue + source.Substring(startIndex + oldValue.Length);

                startIndex += newValue.Length;
            }
            return source;
        }

        /// <summary>
        /// Compares two strings.
        /// </summary>
        /// <param name="source">Source string.</param>
        /// <param name="strB">Compare string.</param>
        /// <param name="ignoreCase">Ignore case.</param>
        /// <returns>True if string equals , otherwise false.</returns>
        public static bool Compare(this string source, string strB, bool ignoreCase)
        {
            if (string.IsNullOrWhiteSpace(source))
                throw new ArgumentException("String may not be null or empty", nameof(source));

            if (string.IsNullOrWhiteSpace(strB))
                throw new ArgumentException("String may not be null or empty", nameof(strB));

            return string.Compare(source, strB, ignoreCase) == 0;
        }

        /// <summary>
        /// Truncates the string to max length.
        /// </summary>
        /// <param name="value">String value.</param>
        /// <param name="maxLength">Max length.</param>
        /// <returns>Truncated string.</returns>
        public static string WithMaxLength(this string value, int maxLength)
        {
            return value?.Substring(0, Math.Min(value.Length, maxLength));
        }

        /// <summary>
        /// Truncates the string to max length.
        /// </summary>
        /// <param name="value">String value.</param>
        /// <param name="maxLength">Max length.</param>
        /// <param name="notNull">Indicates if specified <paramref name="value"/> should be checked for null or emptines.</param>
        /// <returns>Truncated string.</returns>
        /// <exception cref="ArgumentNullException">thrown if specified <paramref name="value"/> is null or empty string and <paramref name="notNull"/> is set to true.</exception>
        public static string WithMaxLength(this string value, int maxLength, bool notNull = false)
        {
            if (notNull)
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(value));
            }

            return value?.Length > maxLength ? value.Substring(0, maxLength) : value;
        }

        /// <summary>
        /// Formats string with named parameters.
        /// </summary>
        /// <param name="str">String.</param>
        /// <param name="args">Arguments.</param>
        /// <returns>Formatted string.</returns>
        public static string Format(this string str, params Expression<Func<string, object>>[] args)
        {
            var parameters = args.ToDictionary(e => string.Format("{{{0}}}", e.Parameters[0].Name), e => e.Compile()(e.Parameters[0].Name));

            var sb = new StringBuilder(str);
            foreach (var kv in parameters)
            {
                sb.Replace(kv.Key, kv.Value != null ? kv.Value.ToString() : "");
            }

            return sb.ToString();
        } 

        #endregion
    }
}
