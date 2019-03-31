using ProtoBuf;
using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    [Serializable()]
    [DataContract()]
    public class DepositTransactionInfo
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets user id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int UserId
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets username.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public string Username
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets current user balance.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public decimal CurrentBalance
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets previous user balance.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public decimal PreviousBalance
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets current transaction id.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public int CurrentTransactionId
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets last transaction date.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        public DateTime CurrentTransactionDate
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets previous transaction id.
        /// </summary>
        [DataMember()]
        [ProtoMember(7)]
        public int? PreviousTransactionId
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets previous transaction date.
        /// </summary>
        [DataMember()]
        [ProtoMember(8)]
        public DateTime? PreviousTransactionDate
        {
            get; set;
        }

        /// <summary>
        /// Gets current transaction type.
        /// </summary>
        [DataMember()]
        [ProtoMember(9)]
        public DepositTransactionType CurrentTransactionType
        {
            get;set;
        }

        /// <summary>
        /// Gets previous transaction type.
        /// </summary>
        [DataMember()]
        [ProtoMember(10)]
        public DepositTransactionType? PreviousTransactionType
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets amount.
        /// </summary>
        [DataMember()]
        [ProtoMember(11)]
        public decimal Amount
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets payment method id.
        /// </summary>
        [DataMember()]
        [ProtoMember(12)]
        public int? PaymentMethodId
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets payment method name.
        /// </summary>
        [DataMember()]
        [ProtoMember(13)]
        public string PaymentMethodName
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets created by id.
        /// </summary>
        [DataMember()]
        [ProtoMember(14)]
        public int? CreatedById
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets creaded by username.
        /// </summary>
        [DataMember()]
        [ProtoMember(15)]
        public string CreatedByUsername
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets register id.
        /// </summary>
        [DataMember()]
        [ProtoMember(16)]
        public int? RegisterId
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets register name.
        /// </summary>
        [DataMember()]
        [ProtoMember(17)]
        public string RegisterName
        {
            get; set;
        }
        
        #endregion
    }
}
