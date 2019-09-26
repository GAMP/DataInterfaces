using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Products
{
    [Serializable]
    [DataContract]
    public class ProductReportDTO : ReportBaseDTO
    {
        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public List<UserGroupProductsSoldDTO> UserGroups { get; set; }

        [DataMember]
        public List<ChartRecordDTO> SalesChart { get; set; } = new List<ChartRecordDTO>();

        [DataMember]
        public List<ChartRecordDTO> SalesChartPerDay { get; set; } = new List<ChartRecordDTO>();

        [DataMember]
        public List<ChartRecordDTO> SalesChartPerHour { get; set; } = new List<ChartRecordDTO>();

        [DataMember]
        public List<ChartRecordDTO> StockChartMin { get; set; } = new List<ChartRecordDTO>();

        [DataMember]
        public List<ChartRecordDTO> StockChartMax { get; set; } = new List<ChartRecordDTO>();

        [DataMember]
        public List<TimeUsageChartRecordDTO> TimeUsageChart { get; set; } = new List<TimeUsageChartRecordDTO>();

    }
}