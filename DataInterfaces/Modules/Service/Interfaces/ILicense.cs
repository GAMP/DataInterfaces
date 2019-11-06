using System;

namespace ServerService
{
    /// <summary>
    /// Service license interface.
    /// </summary>
    public interface ILicense
    {
        #region PROPERTIES

        /// <summary>
        /// Gets total count.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Gets expiration date.
        /// </summary>
        DateTime Expires { get; }

        /// <summary>
        /// Gets hardware id.
        /// </summary>
        string HardwareId { get; }

        /// <summary>
        /// Gets if valid licenses present.
        /// </summary>
        bool HasValidLicenses { get; }

        /// <summary>
        /// Gets if valid trial licenses present.
        /// </summary>
        bool HasValidTrialLicenses { get; }

        /// <summary>
        /// Gets if license expired locally.
        /// </summary>
        bool IsLocalExpired { get; }

        /// <summary>
        /// Gets if trial license expired locally.
        /// </summary>
        bool IsLocalTrialExpired { get; }

        /// <summary>
        /// Gets if license expired on server.
        /// </summary>
        bool IsServerExpired { get; }

        /// <summary>
        /// Gets if trial expired on server.
        /// </summary>
        bool IsServerTrialExpired { get; }

        /// <summary>
        /// Gets license issued time.
        /// </summary>
        DateTime Issued { get; }

        /// <summary>
        /// Gets if license was acquired locally.
        /// </summary>
        bool Local { get; }

        /// <summary>
        /// Gets total count.
        /// </summary>
        int TotalCount { get; }

        /// <summary>
        /// Gets trial count.
        /// </summary>
        int TrialCount { get; }

        /// <summary>
        /// Gets trial expiration date.
        /// </summary>
        DateTime TrialExpires { get; }   

        #endregion
    }
}
