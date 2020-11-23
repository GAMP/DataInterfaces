using System;

namespace ServerService
{
    /// <summary>
    /// Service license V2 interface.
    /// </summary>
    public interface ILicenseV2
    {
        #region PROPERTIES

        /// <summary>
        /// Gets license issued time.
        /// </summary>
        DateTime IssueDate { get; }

        /// <summary>
        /// Gets hardware id.
        /// </summary>
        string HardwareId { get; }

        public SubscriptionHardwareIdStatus HardwareIdStatus { get; }

        /// <summary>
        /// Gets trial count.
        /// </summary>
        int TrialLicensesCount { get; }

        /// <summary>
        /// Gets trial creation date.
        /// </summary>
        DateTime TrialCreationDate { get; }

        /// <summary>
        /// Gets trial expiration date.
        /// </summary>
        DateTime TrialExpirationDate { get; }

        /// <summary>
        /// Gets if trial expired on server.
        /// </summary>
        bool IsServerTrialExpired { get; }

        /// <summary>
        /// Gets total licenses count.
        /// </summary>
        int TotalLicensesCount { get; }

        /// <summary>
        /// Gets total count.
        /// </summary>
        int LicensesAssigned { get; }

        /// <summary>
        /// Gets expiration date.
        /// </summary>
        DateTime ExpirationDate { get; }

        /// <summary>
        /// Gets if license expired on server.
        /// </summary>
        bool IsServerExpired { get; }

        /// <summary>
        /// Gets if subscription is recurring.
        /// </summary>
        bool IsRecurring { get; }

        public SubscriptionWarnings SubscriptionWarnings { get; }

        public bool IsAdvancedMode { get; }

        /// <summary>
        /// Gets license expiration date.
        /// </summary>
        DateTime LicenseExpirationDate { get; }


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
        /// Gets if license was acquired locally.
        /// </summary>
        bool Local { get; }

        /// <summary>
        /// Gets if user authorization failed.
        /// </summary>
        bool Unauthorized { get; }

        #endregion
    }
}