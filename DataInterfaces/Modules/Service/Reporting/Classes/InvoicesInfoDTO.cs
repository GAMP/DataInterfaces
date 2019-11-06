using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// Invoice Information.
    /// </summary>
    [Serializable]
    [DataContract]
    public class InvoicesInfoDTO
    {
        /// <summary>
        /// Invoice Id.
        /// </summary>
        [DataMember]
        public int InvoiceId { get; set; }

        /// <summary>
        /// Payment method Id.
        /// </summary>
        [DataMember]
        public int PaymentMethodId { get; set; }

        /// <summary>
        /// Payment method name.
        /// </summary>
        [DataMember]
        public string PaymentMethodName { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public decimal Value { get; set; }

        [DataMember]
        public bool InvoiceIsVoided { get; set; }
    }
}
