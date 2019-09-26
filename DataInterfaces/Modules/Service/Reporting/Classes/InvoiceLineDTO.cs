using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    [Serializable]
    [DataContract]
    public class InvoiceLineDTO
    {
        [DataMember]
        public int InvoiceLineId { get; set; }

        [DataMember]
        public DateTime CreatedTime { get; set; }

        [DataMember]
        public int PointsAward { get; set; }

        [DataMember]
        public bool IsVoided { get; set; }

        [DataMember]
        public DateTime? VoidCreatedTime { get; set; }

        [DataMember]
        public bool IsTimeOffer { get; set; }

        [DataMember]
        public bool IsFixedTime { get; set; }

        [DataMember]
        public bool IsSession { get; set; }
        
        [DataMember]
        public bool IsProduct { get; set; }

        [DataMember]
        public bool IsExtended { get; set; }

        /// <summary>
        /// True if item is a bundle.
        /// </summary>
        [DataMember]
        public bool IsBundle { get; set; }

        /// <summary>
        /// True if item is part of a bundle.
        /// </summary>
        [DataMember]
        public bool IsInBundle { get; set; }

        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public decimal UnitPrice { get; set; }

        [DataMember]
        public decimal Quantity { get; set; }

        [DataMember]
        public decimal Value { get; set; }

        [DataMember]
        public decimal TaxRate { get; set; }

        [DataMember]
        public decimal Tax { get; set; }

        [DataMember]
        public string UserGroup { get; set; }

        [DataMember]
        public int? Operator { get; set; }

        [DataMember]
        public int? Shift { get; set; }
        
    }
}
