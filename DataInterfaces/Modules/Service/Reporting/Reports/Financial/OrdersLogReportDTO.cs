using SharedLib;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Financial
{
    /// <summary>
    /// Orders Log Report.
    /// </summary>
    [Serializable]
    [DataContract]
    public class OrdersLogReportDTO : ReportBaseDTO
    {
        /// <summary>
        /// Filter Order Source.
        /// </summary>
        [DataMember]
        public OrderSource? OrderSource { get; set; }

        /// <summary>
        /// Filter Order Status.
        /// </summary>
        [DataMember]
        public OrderStatus? OrderStatus { get; set; }

        /// <summary>
        /// Filter Operator Id.
        /// </summary>
        [DataMember]
        public int? OperatorId { get; set; }

        /// <summary>
        /// Filter Operator Name.
        /// </summary>
        [DataMember]
        public string OperatorName { get; set; }

        /// <summary>
        /// Filter User Id.
        /// </summary>
        [DataMember]
        public int? UserId { get; set; }

        /// <summary>
        /// Filter User Name.
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// Filter Group Type.
        /// </summary>
        [DataMember]
        public OrdersLogReportTypes OrdersLogReportType { get; set; }

        /// <summary>
        /// List of orders.
        /// </summary>
        [DataMember]
        public List<OrderDTO> Orders { get; set; } = new List<OrderDTO>();

        /// <summary>
        /// List of records for the average delivery time per operator chart.
        /// </summary>
        [DataMember]
        public List<ChartGroupDTO> OperatorsPerformance { get; set; } = new List<ChartGroupDTO>();

        /// <summary>
        /// List of records for the orders per operator chart.
        /// </summary>
        [DataMember]
        public List<ChartGroupDTO> OrdersChart { get; set; } = new List<ChartGroupDTO>();

    }
}