using System;
using System.Runtime.Serialization;

namespace Client
{
    [Serializable()]
    [DataContract()]
    public class LanguageChangeEventArgs : EventArgs
    {
        #region CONSTRUCTOR
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
