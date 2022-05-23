using System;
using System.Runtime.Serialization;

namespace IntegrationLib
{
    [Serializable()]
    [DataContract()]
    public sealed class ApplicationLicense : ApplicationLicenseBase
    {
        #region CONSTRUCTOR

        /// <summary>
        /// Creates new ApplicationLicense instance.
        /// </summary>
        public ApplicationLicense()
        { }

        /// <summary>
        /// Creates new ApplicationLicense instance.
        /// </summary>
        /// <param name="key">License key.</param>
        public ApplicationLicense(IApplicationLicenseKey key)
        {
            if (key != null)
            {
                this.Key = key;
            }
            else
            {
                throw new ArgumentNullException("Key", "License key may not be null.");
            }
        }

        #endregion
    }
}
