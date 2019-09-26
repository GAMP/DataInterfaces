using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    [Serializable]
    [DataContract]
    public class ReportBaseDTO : NamedInstanceDTO
    {
        [DataMember]
        public DateTime DateFrom { get; set; }

        [DataMember]
        public DateTime DateTo { get; set; }

        [DataMember]
        public string CompanyName { get; set; }

    }
}