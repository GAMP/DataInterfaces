using System;
using System.Runtime.Serialization;

namespace Client
{
    /// <summary>
    /// Language change event args.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class LanguageChangeEventArgs : EventArgs
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="settingsLanguage">Settings language.</param>
        /// <param name="preferedUILanguage">Prefered UI language.</param>
        public LanguageChangeEventArgs(string settingsLanguage, string preferedUILanguage)
        {
            SettingsLanguage = settingsLanguage;
            PreferedUILanguage = preferedUILanguage;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Current settings language.
        /// </summary>
        [DataMember()]
        public string SettingsLanguage
        {
            get; protected set;
        }

        /// <summary>
        /// Current user prefered language.
        /// </summary>
        [DataMember()]
        public string PreferedUILanguage
        {
            get; protected set;
        }

        #endregion
    }
}
