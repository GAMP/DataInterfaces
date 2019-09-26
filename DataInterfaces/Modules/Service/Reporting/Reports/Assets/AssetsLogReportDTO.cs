using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Assets
{
    [Serializable]
    [DataContract]
    public class AssetsLogReportDTO : ReportBaseDTO
    {
        [DataMember]
        public int? AssetTypeId { get; set; }

        [DataMember]
        public string AssetTypeName { get; set; }

        [DataMember]
        public int? AssetId { get; set; }

        [DataMember]
        public string AssetName { get; set; }

        [DataMember]
        public int? CheckOutOperatorId { get; set; }

        [DataMember]
        public string CheckOutOperatorName { get; set; }

        [DataMember]
        public int? CheckInOperatorId { get; set; }

        [DataMember]
        public string CheckInOperatorName { get; set; }

        [DataMember]
        public List<AssetTransactionDTO> AssetTransactions { get; set; }
    }
}