using SharedLib;
using System;
using System.Runtime.Serialization;

namespace IntegrationLib
{
    /// <summary>
    /// License Key Base Class.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public abstract class ApplicationLicenseKeyBase : PropertyChangedNotificator,
        IApplicationLicenseKey
    {
        #region FIELDS
        private string value;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets keys string value.
        /// </summary>
        [IgnoreDataMember()]
        public string Value
        {
            get { return this.value; }
            set
            {
                this.value = value;
                this.RaisePropertyChanged("Value");
                this.RaisePropertyChanged("KeyString");
            }
        }

        /// <summary>
        /// When overriden should return key string representation.
        /// </summary>
        [DataMember()]
        public virtual string KeyString
        {
            get { return this.Value; }
        }

        /// <summary>
        /// When ovveriden returns if current key is valid.
        /// </summary>
        [IgnoreDataMember()]
        public virtual bool IsValid
        {
            get { return !String.IsNullOrWhiteSpace(this.Value); }
        }

        #endregion
    }
}
