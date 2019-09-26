using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    [Serializable]
    [DataContract]
    public class DateUtilizationChartDTO : ChartRecordDTO
    {
        [DataMember]
        public int TotalSeconds { get; set; }

        [DataMember]
        public int UsedSeconds { get; set; }

    }
}
