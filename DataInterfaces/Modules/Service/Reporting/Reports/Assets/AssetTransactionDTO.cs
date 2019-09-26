using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Assets
{
    [Serializable]
    [DataContract]
    public class AssetTransactionDTO
    {
        [DataMember]
        public string AssetType { get; set; }

        [DataMember]
        public string AssetName { get; set; }

        [DataMember]
        public string Customer { get; set; }
        
        [DataMember]
        public DateTime CheckOutTime { get; set; }

        [DataMember]
        public string CheckOutOperator { get; set; }

        [DataMember]
        public DateTime? CheckInTime { get; set; }

        [DataMember]
        public string CheckInOperator { get; set; }

        [DataMember]
        public string LeaseDuration { get; set; }
        
    }
}