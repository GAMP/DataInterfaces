using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// Account Transaction.
    /// </summary>
    [Serializable]
    [DataContract]
    public class AccountTransactionDTO
    {
        /// <summary>
        /// The creation time of the account transaction.
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// The type of the transaction.
        /// </summary>
        public DepositTransactionType TransactionType { get; set; }

        /// <summary>
        /// The payment type Id of the transaction.
        /// </summary>
        [DataMember]
        public int PaymentMethodId { get; set; }

        /// <summary>
        /// The payment type name of the transaction.
        /// </summary>
        [DataMember]
        public string PaymentMethodName { get; set; }

        /// <summary>
        /// The amount of the transaction.
        /// </summary>
        [DataMember]
        public decimal Amount { get; set; }

        /// <summary>
        /// The quantity of the transactions with the specific amount, in case of grouped transactions.
        /// </summary>
        [DataMember]
        public int Quantity { get; set; }

        /// <summary>
        /// The total amount of the transactions with the specific amount, in case of grouped transactions.
        /// </summary>
        [DataMember]
        public decimal Total { get; set; }

        /// <summary>
        /// The Id of the operator performed the account transaction.
        /// </summary>
        public int? OperatorId { get; set; }
        
        /// <summary>
        /// The Id of the group to which the user belongs.
        /// </summary>
        public int UserGroupId { get; set; }

        /// <summary>
        /// The user is guest.
        /// </summary>
        public bool IsGuest { get; set; }
    }
}