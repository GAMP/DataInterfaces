using System;
using SharedLib;

namespace IntegrationLib
{
    /// <summary>
    /// Application license interface.
    /// </summary>
    public interface IApplicationLicense
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets licenses id.
        /// </summary>
        int ID
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets if license is local.
        /// </summary>
        bool IsLocal
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets licenses key.
        /// </summary>
        IApplicationLicenseKey Key
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the status of the license.
        /// </summary>
        LicenseStatus Status
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets licenses comment.
        /// </summary>
        string Comment
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the GUID.
        /// </summary>
        Guid Guid
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets license profile name.
        /// </summary>
        string LicenseProfileName
        {
            get; set;
        }

        #endregion

        #region FUNCTIONS

        /// <summary>
        /// Casts the license key to specified class type.
        /// </summary>
        /// <typeparam name="T">Class type.</typeparam>
        /// <returns>T Class cast.</returns>
        T KeyAs<T>();

        #endregion
    }
}
