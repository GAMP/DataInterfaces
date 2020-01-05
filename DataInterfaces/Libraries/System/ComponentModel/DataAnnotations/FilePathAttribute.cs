namespace System.ComponentModel.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class FilePathAttribute : ValidationAttribute
    {
        #region OVERRIDES

        /// <summary>
        /// Gets if value is valid.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <returns>True or false.</returns>
        public override bool IsValid(object value)
        {
            string path = Convert.ToString(value);

            if (!string.IsNullOrEmpty(path) && path.IndexOfAny(System.IO.Path.GetInvalidPathChars()) >= 0)
                return false;

            return true;
        }

        #endregion
    }
}