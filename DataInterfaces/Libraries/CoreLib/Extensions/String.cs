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
    }
}
