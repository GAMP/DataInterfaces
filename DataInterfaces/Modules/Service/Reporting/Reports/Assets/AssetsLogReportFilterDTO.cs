using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Assets
{
    /// <summary>
    /// Assets Log Report Filter.
    /// </summary>
    [Serializable]
    [DataContract]
    public class AssetsLogReportFilterDTO : DateRangeReportFilterBaseDTO
    {
        /// <summary>
        /// Filter Asset Type Id.
        /// </summary>
        [DataMember]
        public int? AssetTypeId { get; set; }

        /// <summary>
        /// Filter Asset Id.
        /// </summary>
        [DataMember]
        public int? AssetId { get; set; }

        /// <summary>
        /// Filter Check Out Operator Id.
        /// </summary>
        [DataMember]
        public int? CheckOutOperatorId { get; set; }

        /// <summary>
        /// Filter Check In Operator Id.
        /// </summary>
        [DataMember]
        public int? CheckInOperatorId { get; set; }

        /// <summary>
        /// Filter User Id.
        /// </summary>
        [DataMember]
        public int? UserId { get; set; }
    }
}