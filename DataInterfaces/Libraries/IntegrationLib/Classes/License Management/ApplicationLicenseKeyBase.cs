using SharedLib;
using System;
using System.ComponentModel.DataAnnotations;
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
        private string value;

        /// <summary>
        /// Gets or sets keys string value.
        /// </summary>
        [IgnoreDataMember()]
        [Name("Value")]
        public virtual string Value
        {
            get { return value; }
            set
            {
                this.value = value;
                RaisePropertyChanged("Value");
                RaisePropertyChanged("KeyString");
            }
        }

        /// <summary>
        /// When overridden should return key string representation.
        /// </summary>
        [DataMember()]
        public virtual string KeyString
        {
            get { return Value; }
        }

        /// <summary>
        /// When overridden returns if current key is valid.
        /// </summary>
        [IgnoreDataMember()]
        public virtual bool IsValid
        {
            get { return !string.IsNullOrWhiteSpace(Value); }
        }
    }
}
