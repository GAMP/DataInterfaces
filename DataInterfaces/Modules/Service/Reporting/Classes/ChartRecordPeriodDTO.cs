using ServerService.Reporting;
using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    [Serializable]
    [DataContract]
    public class ChartRecordPeriodDTO
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public DateTime From { get; set; }

        [DataMember]
        public DateTime To { get; set; }

    }
}
