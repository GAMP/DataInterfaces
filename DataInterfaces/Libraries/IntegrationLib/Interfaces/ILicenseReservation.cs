using System.Collections.Generic;

namespace IntegrationLib
{
    /// <summary>
    /// License reservation implementation interface.
    /// </summary>
    public interface ILicenseReservation
    {
        #region PROPERTIES

        /// <summary>
        /// Gets reserved licenses.
        /// </summary>
        Dictionary<int, IApplicationLicense> Licenses { get; }

        /// <summary>
        /// Gets or sets license reservation id.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets executable.
        /// </summary>
        string Executable
        {
            get;
        }

        /// <summary>
        /// Gets appliaction.
        /// </summary>
        string Application
        {
            get;
        }

        /// <summary>
        /// Gets host id.
        /// </summary>
        int HostId
        {
            get;
        }

        #endregion
    }
}
