using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntegrationLib
{
    #region IApplicationLicenseKey
    /// <summary>
    /// License Key interface.
    /// </summary>
    public interface IApplicationLicenseKey    
    {
        /// <summary>
        /// Gets the keys string representation.
        /// </summary>
        string KeyString { get; }
        /// <summary>
        /// Returns if the key value is valid.
        /// </summary>
        bool IsValid { get; }
    }
    #endregion
}
