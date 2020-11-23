using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.v2.Models
{
    /// <summary>
    /// Time product.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class TimeProduct
    {
        /// <summary>
        /// Gets or sets minutes.
        /// </summary>
        [DataMember()]
        public int Minutes
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets weekday maximum minutes.
        /// </summary>
        [DataMember()]
        //TODO: A [Range(1, 7200)]
        public int? WeekDayMaxMinutes
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets weekend maximum minutes.
        /// </summary>
        [DataMember()]
        //TODO: A [Range(1, 2880)]
        public int? WeekEndMaxMinutes
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets app profile id.
        /// </summary>
        [DataMember()]
        public int? AppGroupId
        {
            get;
            set;
        }

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
        /// Gets or sets usage options.
        /// </summary>
        [DataMember()]
        public ProductTimeUsageOptionType UsageOptions
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets use order.
        /// </summary>
        [DataMember()]
        public int UseOrder
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
    }
}