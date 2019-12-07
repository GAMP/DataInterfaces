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
        /// Filtered Order Source.
        /// </summary>
        [DataMember]
        public OrderSource? OrderSource { get; set; }

        /// <summary>
        /// Filtered Order Status.
        /// </summary>
        [DataMember]
        public OrderStatus? OrderStatus { get; set; }

        /// <summary>
        /// Filtered Operator Id.
        /// </summary>
        [DataMember]
        public int? OperatorId { get; set; }

        /// <summary>
        /// Filtered Operator Name.
        /// </summary>
        [DataMember]
        public string OperatorName { get; set; }

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
        /// List of orders.
        /// </summary>
        [DataMember]
        public List<OrderDTO> Orders { get; set; } = new List<OrderDTO>();

    }
}