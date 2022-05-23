using SharedLib;
using System;
using System.Runtime.Serialization;

namespace IntegrationLib
{
    /// <summary>
    /// Application license base class.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public abstract class ApplicationLicenseBase : ItemBase, IApplicationLicense
    {
        #region FILEDS
        [NonSerialized()]
        private bool mboolIsLocal;
        [NonSerialized()]
        private LicenseStatus status;
        [NonSerialized()]
        private string comment;
        private IApplicationLicenseKey key;
        private Guid guid;
        [OptionalField(VersionAdded = 2)]
        private string licenseProfileName;
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or Sets keys local value.
        /// </summary>
        /// <returns>This will be used with multisite license management.</returns>
        [IgnoreDataMember()]
        public virtual bool IsLocal
        {
            get
            {
                return this.mboolIsLocal;
            }
            set
            {
                this.mboolIsLocal = value;
                this.RaisePropertyChanged("IsLocal");
            }
        }

        /// <summary>
        /// Gets or sets license key.
        /// </summary>
        [DataMember()]
        public virtual IApplicationLicenseKey Key
        {
            get { return this.key; }
            set
            {
                this.key = value;
                this.RaisePropertyChanged("Key");
            }
        }

        /// <summary>
        /// Gets or set real time status of license usage.
        /// </summary>
        public LicenseStatus Status
        {
            get { return this.status; }
            set
            {
                this.status = value;
                this.RaisePropertyChanged("Status");
            }
        }

        /// <summary>
        /// Gets or sets licenses comment.
        /// </summary>
        /// <remarks>
        /// This can be an actual serial number if the license object is binary file.
        /// This can help you track individual licenses.
        /// </remarks>
        [DataMember()]
        public string Comment
        {
            get { return this.comment; }
            set
            {
                this.comment = value;
                this.RaisePropertyChanged("Comment");
            }
        }

        /// <summary>
        /// Gets or sets a unique global license identifier.
        /// </summary>
        [IgnoreDataMember()]
        public Guid Guid
        {
            get
            {
                if (this.guid == Guid.Empty)
                {
                    this.guid = Guid.NewGuid();
                }
                return this.guid;
            }
            set
            {
                this.guid = value;
                this.RaisePropertyChanged("Guid");
            }
        }

        /// <summary>
        /// Gets or sets license profile name.
        /// </summary>
        [DataMember()]
        public string LicenseProfileName
        {
            get { return this.licenseProfileName; }
            set { this.licenseProfileName = value; }
        }

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Returns key instance as specified T type.
        /// </summary>
        public T KeyAs<T>()
        {
            return (T)this.Key;
        }

        #endregion
    }
}
