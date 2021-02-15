using System.IO;
using System.Linq;

namespace System.ComponentModel.DataAnnotations
{
    /// <summary>
    /// File invalid characters validation attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class FileInvalidCharactersValidationAttribute : ValidationAttribute
    {
        #region FIELDS
        private static readonly char[] INVALID_FILE_NAME_CHARACTERS = Path.GetInvalidFileNameChars();
        private static readonly string[] RESERVED_FILE_NAMES = new string[] { "CON", "PRN", "AUX", "NUL", "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9" };
        #endregion

        #region OVERRIDES

        /// <summary>
        /// Gets if value is valid.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <returns>True or false.</returns>
        public override bool IsValid(object value)
        {
            if (value is string PATH_STRING)
            {
                //null or empty strings dont have any invalid characters
                if (string.IsNullOrWhiteSpace(PATH_STRING))
                    return true;

                //ensure no invalid characters in path
                if (PATH_STRING.IndexOfAny(INVALID_FILE_NAME_CHARACTERS) >= 0)
                    return false;

                if (PATH_STRING.EndsWith(" ") || PATH_STRING.EndsWith("."))
                    return false;

                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(PATH_STRING);

                if (RESERVED_FILE_NAMES.Any(a => a.Equals(PATH_STRING, StringComparison.OrdinalIgnoreCase) ||
                    a.Equals(fileNameWithoutExtension, StringComparison.OrdinalIgnoreCase)))
                {
                    return false;
                }

                return true;
            }

            //not a string ? valid then ?
            return true;
        } 

        #endregion
    }
}
