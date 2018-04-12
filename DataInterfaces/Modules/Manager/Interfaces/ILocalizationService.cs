using System;
using System.Globalization;

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
        /// Gets lower localized string value.
        /// </summary>
        /// <param name="key">String value key.</param>
        /// <returns>Localized string value or null.</returns>
        string LocLower(string key);

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

        /// <summary>
        /// Updates localization dicrionary.
        /// </summary>
        /// <param name="assemblyName">Assembly name.</param>
        /// <param name="resourceDictionary">Resource dictionary name.</param>
        /// <returns>True for success otherwise false.</returns>
        bool UpdateDictionary(string assemblyName,string resourceDictionary);

        /// <summary>
        /// Gets localized value by fully qualified name.
        /// </summary>
        /// <typeparam name="T">Localized type.</typeparam>
        /// <param name="fqn">Fully qualified name.</param>
        /// <returns>Localized value.</returns>
        T LocFQN<T>(string fqn);

        /// <summary>
        /// Formats values to fully qualified name.
        /// </summary>
        /// <param name="assemblyName">Assembly name.</param>
        /// <param name="resourceDictionary">Resource dictionary name.</param>
        /// <param name="key">Resource key.</param>
        /// <returns>Fully qualified string.</returns>
        string FormatFQN(string assemblyName, string resourceDictionary, string key);

        #endregion
    }
}
