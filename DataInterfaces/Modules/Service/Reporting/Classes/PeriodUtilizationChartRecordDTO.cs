using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// Period Utilization Chart Record.
    /// </summary>
    [Serializable]
    [DataContract]
    public class PeriodUtilizationChartRecordDTO : ChartRecordDTO
    {
        /// <summary>
        /// Period total seconds multiplied by the number of available hosts.
        /// </summary>
        [DataMember]
        public int TotalSeconds { get; set; }

        /// <summary>
        /// Period used seconds based on user sessions.
        /// </summary>
        [DataMember]
        public int UsedSeconds { get; set; }

    }
}
