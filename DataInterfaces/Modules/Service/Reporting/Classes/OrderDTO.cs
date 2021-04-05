using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// Order Information.
    /// </summary>
    [Serializable]
    [DataContract]
    public class OrderDTO
    {
        /// <summary>
        /// Order Id.
        /// </summary>
        [DataMember]
        public int OrderId { get; set; }

        /// <summary>
        /// Creation time of the order.
        /// </summary>
        [DataMember]
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// Order source.
        /// </summary>
        [DataMember]
        public OrderSource OrderSource { get; set; }

        /// <summary>
        /// Order status.
        /// </summary>
        [DataMember]
        public OrderStatus OrderStatus { get; set; }

        /// <summary>
        /// Order source name.
        /// </summary>
        [DataMember]
        public string OrderSourceLiteral { get; set; }

        /// <summary>
        /// Order status name.
        /// </summary>
        [DataMember]
        public string OrderStatusName { get; set; }
        
        /// <summary>
        /// The Id of the operator that handled the order.
        /// </summary>
        [DataMember]
        public int? OperatorId { get; set; }

        /// <summary>
        /// The name of the operator that handled the order.
        /// </summary>
        [DataMember]
        public string OperatorName { get; set; }

        /// <summary>
        /// The Id of the host on which the order was created.
        /// </summary>
        [DataMember]
        public int? HostId { get; set; }

        /// <summary>
        /// The name of the host on which the order was created.
        /// </summary>
        [DataMember]
        public string HostName { get; set; }

        /// <summary>
        /// The Id of the register on which the order was processed.
        /// </summary>
        [DataMember]
        public int? RegisterId { get; set; }

        /// <summary>
        /// The name of the register on which the order was processed.
        /// </summary>
        [DataMember]
        public string RegisterName { get; set; }

        /// <summary>
        /// The Id of the user that created the order.
        /// </summary>
        [DataMember]
        public int? UserId { get; set; }

        /// <summary>
        /// The name of the user that created the order.
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// The time the order was delivered or null if is not delivered yet.
        /// </summary>
        [DataMember]
        public DateTime? DeliveredTime { get; set; }

        /// <summary>
        /// Total seconds between the time the order was created and the time the order was delivered, null if is not delivered yet.
        /// </summary>
        [DataMember]
        public decimal? DeliverySeconds { get; set; }

        /// <summary>
        /// Total time as text between the time the order was created and the time the order was delivered, null if is not delivered yet.
        /// </summary>
        [DataMember]
        public string DeliveryTime { get; set; }

        /// <summary>
        /// Number of items within the order.
        /// </summary>
        public int ItemNumber { get; set; }

        /// <summary>
        /// The Id of the invoice that was created for the order, null if there is no related invoice.
        /// </summary>
        [DataMember]
        public int? InvoiceId { get; set; }

        /// <summary>
        /// User note for the order.
        /// </summary>
        [DataMember]
        public string UserNote { get; set; }

        /// <summary>
        /// The invoice that was created for the order, null if there is no related invoice.
        /// </summary>
        public InvoiceDTO Invoice { get; set; }

    }
}