using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// Expirable Product Information.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ExpirableProductDTO
    {
        /// <summary>
        /// The invoice is voided.
        /// </summary>
        [DataMember()]
        public bool IsVoided { get; set; }

        /// <summary>
        /// The number of second the product was used.
        /// </summary>
        [DataMember()]
        public int UsedSeconds { get; set; }

        /// <summary>
        /// The total number of seconds available in the product.
        /// </summary>
        [DataMember()]
        public int TotalSeconds { get; set; }

        /// <summary>
        /// The percentage of the product used.
        /// </summary>
        [DataMember()]
        public decimal UsedPercentage { get; set; }

        /// <summary>
        /// The creation time of the product.
        /// </summary>
        [DataMember]
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// The product is expired.
        /// </summary>
        [DataMember]
        public bool IsExpired = false;

        /// <summary>
        /// The time the product expires.
        /// </summary>
        [DataMember]
        public DateTime? ExpiryDate = null;

        /// <summary>
        /// The product expires at logout.
        /// </summary>
        [DataMember]
        public bool ExpiresAtLogout = false;

        /// <summary>
        /// The product expires after days.
        /// </summary>
        [DataMember()]
        public int ExpiresAfter { get; set; }

        /// <summary>
        /// Expiration options.
        /// </summary>
        [DataMember()]
        public ProductTimeExpirationOptionType ExpirationOptions { get; set; }

        /// <summary>
        /// The product expires from options.
        /// </summary>
        [DataMember()]
        public ExpireFromOptionType ExpireFromOptions { get; set; }

        /// <summary>
        /// Gets or sets expire after type.
        /// </summary>
        [DataMember()]
        public ExpireAfterType ExpireAfterType { get; set; }

        /// <summary>
        /// Gets or sets expire at day time minute.
        /// </summary>
        [DataMember()]
        public int ExpireAtDayTimeMinute { get; set; }

        /// <summary>
        /// The time the product was used for the first time.
        /// </summary>
        [DataMember()]
        public DateTime? FirstUsageDate { get; set; }

        [DataMember()]
        public bool IsUsedOnMultipleSessions { get; set; }

        [DataMember()]
        public DateTime? UsePeriodStart { get; set; }

        [DataMember()]
        public DateTime? UsePeriodEnd { get; set; }

        [DataMember()]
        public PeriodOptionType UsePeriodOptions { get; set; }
    }
}