using SharedLib;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService.Reporting.Reports.Financial
{
    /// <summary>
    /// Orders Log Report Filter.
    /// </summary>
    [Serializable]
    [DataContract]
    public class OrdersReportFilterDTO : DateRangeReportFilterBaseDTO
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
        /// Filter User Id.
        /// </summary>
        [DataMember]
        public int? UserId { get; set; }

        /// <summary>
        /// Filter User Name.
        /// </summary>
        public string UserName { get; set; }

    }
}
