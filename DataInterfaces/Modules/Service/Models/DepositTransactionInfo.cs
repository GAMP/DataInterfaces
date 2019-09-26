using ProtoBuf;
using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Deposit transaction info model.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class DepositTransactionInfo
    {
        #region PROPERTIES

        /// <summary>
        /// User id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int UserId
        {
            get;set;
        }

        /// <summary>
        /// Username.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public string Username
        {
            get; set;
        }

        /// <summary>
        /// Current user deposits balance.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public decimal CurrentBalance
        {
            get; set;
        }

        /// <summary>
        /// Previous user desposits balance.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public decimal PreviousBalance
        {
            get; set;
        }

        /// <summary>
        /// Current transaction id.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public int CurrentTransactionId
        {
            get;set;
        }

        /// <summary>
        /// Last transaction date.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        public DateTime CurrentTransactionDate
        {
            get; set;
        }

        /// <summary>
        /// Previous transaction id.
        /// </summary>
        [DataMember()]
        [ProtoMember(7)]
        public int? PreviousTransactionId
        {
            get;set;
        }

        /// <summary>
        /// Previous transaction date.
        /// </summary>
        [DataMember()]
        [ProtoMember(8)]
        public DateTime? PreviousTransactionDate
        {
            get; set;
        }

        /// <summary>
        /// Current transaction type.
        /// </summary>
        [DataMember()]
        [ProtoMember(9)]
        public DepositTransactionType CurrentTransactionType
        {
            get;set;
        }

        /// <summary>
        /// Previous transaction type.
        /// </summary>
        [DataMember()]
        [ProtoMember(10)]
        public DepositTransactionType? PreviousTransactionType
        {
            get; set;
        }

        /// <summary>
        /// Amount.
        /// </summary>
        [DataMember()]
        [ProtoMember(11)]
        public decimal Amount
        {
            get;set;
        }

        /// <summary>
        /// Payment method id.
        /// </summary>
        [DataMember()]
        [ProtoMember(12)]
        public int? PaymentMethodId
        {
            get;set;
        }

        /// <summary>
        /// Payment method name.
        /// </summary>
        [DataMember()]
        [ProtoMember(13)]
        public string PaymentMethodName
        {
            get; set;
        }

        /// <summary>
        /// Created by id.
        /// </summary>
        [DataMember()]
        [ProtoMember(14)]
        public int? CreatedById
        {
            get;set;
        }

        /// <summary>
        /// Creaded by username.
        /// </summary>
        [DataMember()]
        [ProtoMember(15)]
        public string CreatedByUsername
        {
            get; set;
        }

        /// <summary>
        /// Register id.
        /// </summary>
        [DataMember()]
        [ProtoMember(16)]
        public int? RegisterId
        {
            get;set;
        }

        /// <summary>
        /// Register name.
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
