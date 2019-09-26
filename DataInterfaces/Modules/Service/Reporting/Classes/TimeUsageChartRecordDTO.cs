using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    [Serializable]
    [DataContract]
    public class TimeUsageChartRecordDTO : ChartRecordDTO
    {
        [DataMember]
        public int Voids { get; set; }

    }
}
