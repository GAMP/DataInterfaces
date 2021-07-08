using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// Invoice Line Information.
    /// </summary>
    [Serializable]
    [DataContract]
    public class InvoiceLineDTO
    {
        /// <summary>
        /// The Id of the invoice to which the invoice line belongs.
        /// </summary>
        [DataMember]
        public int InvoiceId { get; set; }

        /// <summary>
        /// Invoice Line Id.
        /// </summary>
        [DataMember]
        public int InvoiceLineId { get; set; }

        /// <summary>
        /// Creation time of the invoice.
        /// </summary>
        [DataMember]
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// The cost in points of the product.
        /// </summary>
        [DataMember]
        public int Points { get; set; }

        /// <summary>
        /// Points award of the invoice line.
        /// </summary>
        [DataMember]
        public int PointsAward { get; set; }

        /// <summary>
        /// The invoice is voided.
        /// </summary>
        [DataMember]
        public bool IsVoided { get; set; }

        /// <summary>
        /// The time the invoice was voided, null if not voided.
        /// </summary>
        [DataMember]
        public DateTime? VoidedTime { get; set; }

        /// <summary>
        /// Invoice line refers to a time offer.
        /// </summary>
        [DataMember]
        public bool IsTimeOffer { get; set; }

        /// <summary>
        /// Invoice line refers to fixed time.
        /// </summary>
        [DataMember]
        public bool IsFixedTime { get; set; }

        /// <summary>
        /// Invoice line refers to session time.
        /// </summary>
        [DataMember]
        public bool IsSession { get; set; }

        /// <summary>
        /// Invoice line refers to a product.
        /// </summary>
        [DataMember]
        public bool IsProduct { get; set; }
        
        /// <summary>
        /// Invoice line refers to a bundle.
        /// </summary>
        [DataMember]
        public bool IsBundle { get; set; }

        /// <summary>
        /// Invoice line refers to an item that belongs to a bundle.
        /// </summary>
        [DataMember]
        public bool IsInBundle { get; set; }

        /// <summary>
        /// The Id of the product to which the invoice line refers.
        /// </summary>
        [DataMember]
        public int ProductId { get; set; }

        /// <summary>
        /// The name of the product to which the invoice line refers.
        /// </summary>
        [DataMember]
        public string ProductName { get; set; }

        /// <summary>
        /// Unit price.
        /// </summary>
        [DataMember]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Unit cost.
        /// </summary>
        [DataMember]
        public decimal? UnitCost { get; set; }

        /// <summary>
        /// Quantity.
        /// </summary>
        [DataMember]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Total cost.
        /// </summary>
        [DataMember]
        public decimal? TotalCost { get; set; }

        /// <summary>
        /// The value of the invoice line.
        /// </summary>
        [DataMember]
        public decimal Value { get; set; }

        /// <summary>
        /// The tax rate of the invoice line.
        /// </summary>
        [DataMember]
        public decimal TaxRate { get; set; }

        /// <summary>
        /// The tax amount of the invoice line.
        /// </summary>
        [DataMember]
        public decimal Tax { get; set; }

        /// <summary>
        /// The name of the group to which the customer of the invoice belongs.
        /// </summary>
        [DataMember]
        public string UserGroupName { get; set; }

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
        public int? CustomerId { get; set; }

        /// <summary>
        /// The username of the customer for whom the invoice was created.
        /// </summary>
        [DataMember]
        public string CustomerName { get; set; }

        /// <summary>
        /// The Id of the shift in which the invoice was created.
        /// </summary>
        [DataMember]
        public int? ShiftId { get; set; }

        /// <summary>
        /// The Id of the operator that performed the void.
        /// </summary>
        [DataMember]
        public int? VoidOperatorId { get; set; }
    }
}
