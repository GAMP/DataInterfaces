using ProtoBuf;
using SharedLib;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Product time entity.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class ProductTime : ProductBase
    {
        #region ProductTime

        /// <summary>
        /// Gets or sets minutes.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int Minutes
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets weekday maximum minutes.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        [Range(1, 7200)]
        public int? WeekDayMaxMinutes
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets weekend maximum minutes.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        [Range(1, 2880)]
        public int? WeekEndMaxMinutes
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets app profile id.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public int? AppGroupId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets expire after days.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public int ExpiresAfter
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets expiration options.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        public ProductTimeExpirationOptionType ExpirationOptions
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets expire from options.
        /// </summary>
        [DataMember()]
        [ProtoMember(7)]
        public ExpireFromOptionType ExpireFromOptions
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets usage options.
        /// </summary>
        [DataMember()]
        [ProtoMember(8)]
        public ProductTimeUsageOptionType UsageOptions
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets use order.
        /// </summary>
        [DataMember()]
        [ProtoMember(9)]
        public int UseOrder
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets expire after type.
        /// </summary>
        [DataMember()]
        [ProtoMember(12)]
        public ExpireAfterType ExpireAfterType
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets expire at day time minute.
        /// </summary>
        [DataMember()]
        [ProtoMember(13)]
        public int ExpireAtDayTimeMinute
        {
            get; set;
        }

        #endregion

    }
}