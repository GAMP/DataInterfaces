using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Products
{
    /// <summary>
    /// Chart record for the usage of time products.
    /// </summary>
    [Serializable]
    [DataContract]
    public class TimeUsageChartRecordDTO : ChartRecordDTO
    {
        /// <summary>
        /// Number of products that was used before void. 
        /// </summary>
        [DataMember]
        public int Voids { get; set; }

    }
}
