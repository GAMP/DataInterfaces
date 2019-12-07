using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Products
{
    /// <summary>
    /// Product Report.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ProductReportDTO : ReportBaseDTO
    {
        /// <summary>
        /// Filtered Product Id.
        /// </summary>
        [DataMember]
        public int ProductId { get; set; }

        /// <summary>
        /// Filtered Product Name.
        /// </summary>
        [DataMember]
        public string ProductName { get; set; }

        /// <summary>
        /// Filtered User Id.
        /// </summary>
        [DataMember]
        public int? UserId { get; set; }

        /// <summary>
        /// Filtered User Name.
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// List of product sales per user group.
        /// </summary>
        [DataMember]
        public List<UserGroupProductsSoldDTO> UserGroups { get; set; }

        /// <summary>
        /// List of records for the general sales chart.
        /// </summary>
        public List<ChartRecordDTO> SalesChart { get; set; } = new List<ChartRecordDTO>();

        /// <summary>
        /// List of records for the sales per day chart.
        /// </summary>
        public List<ChartRecordDTO> SalesChartPerDay { get; set; } = new List<ChartRecordDTO>();

        /// <summary>
        /// List of records for the sales per hour chart.
        /// </summary>
        public List<ChartRecordDTO> SalesChartPerHour { get; set; } = new List<ChartRecordDTO>();

        /// <summary>
        /// List of records with minimum values for the stock chart.
        /// </summary>
        public List<ChartRecordDTO> StockChartMin { get; set; } = new List<ChartRecordDTO>();

        /// <summary>
        /// List of records with maximum values for the stock chart.
        /// </summary>
        public List<ChartRecordDTO> StockChartMax { get; set; } = new List<ChartRecordDTO>();

        /// <summary>
        /// List of records for the time usage chart.
        /// </summary>
        public List<TimeUsageChartRecordDTO> TimeUsageChart { get; set; } = new List<TimeUsageChartRecordDTO>();

    }
}