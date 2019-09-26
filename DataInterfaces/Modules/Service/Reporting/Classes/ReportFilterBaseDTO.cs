using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    [Serializable]
    [DataContract]
    public class ReportFilterBaseDTO
    {
        [DataMember]
        public DateTime DateFrom { get; set; }

        [DataMember]
        public DateTime DateTo { get; set; }
        
        [DataMember]
        public string BusinessStartWeekDay { get; set; }
        
        [DataMember]
        public string BusinessDayStart { get; set; }

        [DataMember]
        public string PeriodType { get; set; }

        [DataMember]
        public bool? Pdf { get; set; }

        [DataMember]
        public bool? Partial { get; set; }
    }
}
