using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Assets
{
    /// <summary>
    /// Assets Log Report.
    /// </summary>
    [Serializable]
    [DataContract]
    public class AssetsLogReportDTO : ReportBaseDTO
    {
        /// <summary>
        /// Filtered Asset Type Id.
        /// </summary>
        [DataMember]
        public int? AssetTypeId { get; set; }

        /// <summary>
        /// Filtered Asset Type Name.
        /// </summary>
        [DataMember]
        public string AssetTypeName { get; set; }

        /// <summary>
        /// Filtered Asset Id.
        /// </summary>
        [DataMember]
        public int? AssetId { get; set; }

        /// <summary>
        /// Filtered Asset Name.
        /// </summary>
        [DataMember]
        public string AssetName { get; set; }

        /// <summary>
        /// Filtered Check Out Operator Id.
        /// </summary>
        [DataMember]
        public int? CheckOutOperatorId { get; set; }

        /// <summary>
        /// Filtered Check Out Operator Name.
        /// </summary>
        [DataMember]
        public string CheckOutOperatorName { get; set; }

        /// <summary>
        /// Filtered Check In Operator Id.
        /// </summary>
        [DataMember]
        public int? CheckInOperatorId { get; set; }

        /// <summary>
        /// Filtered Check In Operator Name.
        /// </summary>
        [DataMember]
        public string CheckInOperatorName { get; set; }

        /// <summary>
        /// Filtered User Id.
        /// </summary>
        [DataMember]
        public int? UserId { get; set; }

        /// <summary>
        /// Filtered User Name.
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// List of asset transactions within the reporting period.
        /// </summary>
        [DataMember]
        public List<AssetTransactionDTO> AssetTransactions { get; set; }
    }
}