using System.IO;

namespace System.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Path invalid characters validation attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class PathInvalidCharactersValidationAttribute : ValidationAttribute
    {
        #region FIELDS
        private static readonly char[] INVALID_PATH_NAME_CHARACTERS = Path.GetInvalidPathChars();
        #endregion

        #region PROPERTIES
        
        /// <summary>
        /// Gets or sets if wild cards should be allowed in paths.
        /// </summary>
        public bool AllowWildCard
        {
            get; set;
        }

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

                if (!AllowWildCard)
                {
                    //path contains wild card or asterisk
                    if (PATH_STRING.IndexOf('*') >= 0)
                        return false;
                }

                //ensure no invalid characters in path
                return PATH_STRING.IndexOfAny(INVALID_PATH_NAME_CHARACTERS) < 0;
            }

            //not a string ? valid then ?
            return true;
        } 

        #endregion
    }
}
