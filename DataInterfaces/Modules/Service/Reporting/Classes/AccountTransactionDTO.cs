using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    [Serializable]
    [DataContract]
    public class AccountTransactionDTO
    {
        [DataMember]
        public DateTime CreatedTime { get; set; }

        [DataMember]
        public DepositTransactionType Type { get; set; }

        /// <summary>
        /// Gets or sets the payment type id of the transaction.
        /// </summary>
        [DataMember]
        public int PaymentMethodId { get; set; }

        /// <summary>
        /// Gets or sets the payment type name of the transaction.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the amount of the transaction.
        /// </summary>
        [DataMember]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the transactions with the specific amount.
        /// </summary>
        [DataMember]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the total amount of the transactions with the specific amount.
        /// </summary>
        [DataMember]
        public decimal Total { get; set; }

        [DataMember]
        public int? Operator { get; set; }

        [DataMember]
        public int? ShiftId { get; set; }

        [DataMember]
        public int UserGroupId { get; set; }

        [DataMember]
        public bool IsGuest { get; set; }
    }
}