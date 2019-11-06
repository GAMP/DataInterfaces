using System.Globalization;

namespace System.Windows.Data
{
    /// <summary>
    /// Binding that uses current culture.
    /// </summary>
    public class CultureAwareBinding : Binding
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new instance.
        /// </summary>
        public CultureAwareBinding()
        {
            ConverterCulture = CultureInfo.CurrentCulture;
        }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="path">Property path.</param>
        public CultureAwareBinding(string path) : base(path)
        {
            ConverterCulture = CultureInfo.CurrentCulture;
        }

        #endregion
    }
}
