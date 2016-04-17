using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Services
{
    /// <summary>
    /// Localization service.
    /// </summary>
    public interface ILocalizationService
    {
        #region FUNCTIONS

        /// <summary>
        /// Gets localized string value.
        /// </summary>
        /// <param name="key">String key.</param>
        /// <returns>Localized string value or null.</returns>
        string Loc(string key);

        /// <summary>
        /// Gets upper localized string value.
        /// </summary>
        /// <param name="key">String value key.</param>
        /// <returns>Localized string value or null.</returns>
        string LocUpper(string key);

        /// <summary>
        /// Gets localized object value.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="key">Object key.</param>
        /// <returns>Localized object value or null.</returns>
        T Loc<T>(string key);

        /// <summary>
        /// Gets localized object value.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="key">Object key.</param>
        /// <param name="culture">Culture.</param>
        /// <returns>Localized object value or null.</returns>
        T Loc<T>(string key, CultureInfo culture);

        /// <summary>
        /// Gets localized enum value.
        /// </summary>
        /// <param name="enumValue">Enum value.</param>
        /// <returns>Localized string.</returns>
        string Loc(Enum enumValue); 

        #endregion
    }
}
