using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Assets
{
    [Serializable]
    [DataContract]
    public class AssetsLogReportFilterDTO : ReportFilterBaseDTO
    {
        [DataMember]
        public List<ListItemDTO> AssetTypes { get; set; }

        [DataMember]
        public int? AssetTypeId { get; set; }

        [DataMember]
        public List<ListItemDTO> Assets { get; set; }

        [DataMember]
        public int? AssetId { get; set; }

        [DataMember]
        public List<ListItemDTO> Operators { get; set; }

        [DataMember]
        public int? CheckOutOperatorId { get; set; }

        [DataMember]
        public int? CheckInOperatorId { get; set; }
    }
}
