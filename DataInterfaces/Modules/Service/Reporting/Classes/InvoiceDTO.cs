using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// Invoice Information.
    /// </summary>
    [Serializable]
    [DataContract]
    public class InvoiceDTO
    {
        /// <summary>
        /// Invoice Id.
        /// </summary>
        [DataMember]
        public int InvoiceId { get; set; }

        /// <summary>
        /// The creation time of the invoice.
        /// </summary>
        [DataMember]
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// The Id of the operator that created the invoice.
        /// </summary>
        [DataMember]
        public int? OperatorId { get; set; }

        /// <summary>
        /// The name of the operator that created the invoice.
        /// </summary>
        [DataMember]
        public string OperatorName { get; set; }

        /// <summary>
        /// The Id of the register on which the invoice was created.
        /// </summary>
        [DataMember]
        public int? RegisterId { get; set; }

        /// <summary>
        /// The name of the register on which the invoice was created.
        /// </summary>
        [DataMember]
        public string RegisterName { get; set; }

        /// <summary>
        /// The Id of the customer for whom the invoice was created.
        /// </summary>
        [DataMember]
        public int? UserId { get; set; }

        /// <summary>
        /// The name of the customer for whom the invoice was created.
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// The Id of the user group the customer belongs to.
        /// </summary>
        [DataMember]
        public int? UserGroupId { get; set; }

        /// <summary>
        /// Order source name.
        /// </summary>
        [DataMember]
        public string OrderSource { get; set; }

        /// <summary>
        /// The number of items in the invoice.
        /// </summary>
        [DataMember]
        public int Quantity { get; set; }

        /// <summary>
        /// The tax amount of the invoice.
        /// </summary>
        [DataMember]
        public decimal Tax { get; set; }

        /// <summary>
        /// The value of the invoice.
        /// </summary>
        [DataMember]
        public decimal Value { get; set; }
        
        /// <summary>
        /// The value in points of the invoice.
        /// </summary>
        [DataMember]
        public decimal PointsValue { get; set; }

        /// <summary>
        /// The points award of the invoice.
        /// </summary>
        [DataMember]
        public int PointsAward { get; set; }

        /// <summary>
        /// Outstanding amount of the invoice. 
        /// </summary>
        [DataMember]
        public decimal Outstanding { get; set; }

        /// <summary>
        /// The invoice is voided.
        /// </summary>
        [DataMember]
        public bool IsVoided { get; set; }

        /// <summary>
        /// Refunded amount of the invoice.
        /// </summary>
        [DataMember]
        public decimal RefundedAmount { get; set; }

    }
}