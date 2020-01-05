using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// Invoice payment information.
    /// </summary>
    [Serializable]
    [DataContract]
    public class InvoicePaymentDTO// : InvoicesInfoDTO
    {
        /// <summary>
        /// The time that invoice payment was created.
        /// </summary>
        [DataMember]
        public DateTime CreatedTime { get; set; }

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

        /// <summary>
        /// Amount of the invoice payment.
        /// </summary>
        [DataMember]
        public decimal Amount { get; set; }

        /// <summary>
        /// Refunded amount of the invoice payment.
        /// </summary>
        [DataMember]
        public decimal RefundedAmount { get; set; }

        /// <summary>
        /// Refunded status of the invoice payment.
        /// </summary>
        [DataMember]
        public RefundStatus RefundStatus { get; set; }

        /// <summary>
        /// Refund method Id of the invoice payment.
        /// </summary>
        [DataMember]
        public int RefundMethodId { get; set; }

        /// <summary>
        /// The Id of the operator that performed the invoice payment.
        /// </summary>
        [DataMember]
        public int? OperatorId { get; set; }

        /// <summary>
        /// The name of the operator that performed the invoice payment.
        /// </summary>
        [DataMember]
        public string OperatorName { get; set; }

        /// <summary>
        /// The Id of the register on which the invoice payment was performed.
        /// </summary>
        [DataMember]
        public int? RegisterId { get; set; }

        /// <summary>
        /// The name of the register on which the invoice payment was performed.
        /// </summary>
        [DataMember]
        public string RegisterName { get; set; }

        /// <summary>
        /// The Id of the shift that the invoice payment belongs.
        /// </summary>
        [DataMember]
        public int? ShiftId { get; set; }

        /// <summary>
        /// The Id of the user group that the user belongs.
        /// </summary>
        [DataMember]
        public int UserGroupId { get; set; }

        /// <summary>
        /// The user is guest.
        /// </summary>
        [DataMember]
        public bool IsGuest { get; set; }

        /// <summary>
        /// Invoice total amount.
        /// </summary>
        [DataMember]
        public decimal InvoiceTotal { get; set; }

        /// <summary>
        /// Invoice amount outstanding.
        /// </summary>
        [DataMember]
        public decimal InvoiceOutstanding { get; set; }

        /// <summary>
        /// The invoice is voided.
        /// </summary>
        [DataMember]
        public bool InvoiceIsVoided { get; set; }

        /// <summary>
        /// The time the invoice related to the order was voided, null if not voided.
        /// </summary>
        [DataMember]
        public DateTime? VoidCreatedTime { get; set; }

        /// <summary>
        /// The Id of the operator that performed the void.
        /// </summary>
        [DataMember]
        public int? VoidOperatorId { get; set; }
    }
}