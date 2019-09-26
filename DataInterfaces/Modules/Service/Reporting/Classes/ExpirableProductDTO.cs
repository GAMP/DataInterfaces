using SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerService.Reporting
{
    [Serializable]
    [DataContract]
    public class ExpirableProductDTO
    {
        /// <summary>
        /// Gets or sets if invoice is voided.
        /// </summary>
        [DataMember()]
        public bool IsVoided
        {
            get; set;
        }

        [DataMember()]
        public int UsedSeconds
        {
            get; set;
        }

        [DataMember()]
        public int TotalSeconds
        {
            get; set;
        }

        [DataMember()]
        public decimal UsedPercentage
        {
            get; set;
        }

        [DataMember]
        public DateTime CreatedTime { get; set; }

        [DataMember]
        public bool IsExpired = false;

        [DataMember]
        public DateTime? ExpiryDate = null;

        [DataMember]
        public bool ExpiresAtLogout = false;

        /// <summary>
        /// Gets or sets expire after days.
        /// </summary>
        [DataMember()]
        public int ExpiresAfter
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets expiration options.
        /// </summary>
        [DataMember()]
        public ProductTimeExpirationOptionType ExpirationOptions
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets expire from options.
        /// </summary>
        [DataMember()]
        public ExpireFromOptionType ExpireFromOptions
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets expire after type.
        /// </summary>
        [DataMember()]
        public ExpireAfterType ExpireAfterType
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets expire at day time minute.
        /// </summary>
        [DataMember()]
        public int ExpireAtDayTimeMinute
        {
            get; set;
        }

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