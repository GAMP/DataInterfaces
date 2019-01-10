using System;

namespace CoreLib
{
    /// <summary>
    /// String extension class.
    /// </summary>
    public static class StringExtensions
    {
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
        public static bool Compare(this string source, string strB , bool ignoreCase)
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
    }
}
