using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Shift count summary model.
    /// </summary>
    [ProtoContract()]
    [Serializable()]
    [DataContract()]
    public class ShiftCountSummary
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        public ShiftCountSummary()
        { }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Shift id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int ShiftId
        {
            get; set;
        }

        /// <summary>
        /// Payment method id.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public int PaymentMethodId
        {
            get; set;
        }

        /// <summary>
        /// Start cash.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public decimal StartCash
        {
            get; set;
        }

        /// <summary>
        /// Total sales sum.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public decimal Sales
        {
            get; set;
        }

        /// <summary>
        /// Total deposits sum.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public decimal Deposits
        {
            get; set;
        }

        /// <summary>
        /// Pay-in's.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        public decimal PayIns
        {
            get; set;
        }

        /// <summary>
        /// Total withdrawals sum.
        /// </summary>
        [DataMember()]
        [ProtoMember(7)]
        public decimal Withdrawals
        {
            get; set;
        }

        /// <summary>
        /// Pay-out's.
        /// </summary>
        [DataMember()]
        [ProtoMember(8)]
        public decimal PayOuts
        {
            get; set;
        }

        /// <summary>
        /// Total refunds sum.
        /// </summary>
        [DataMember()]
        [ProtoMember(9)]
        public decimal Refunds
        {
            get; set;
        }

        /// <summary>
        /// Total voids sum.
        /// </summary>
        [DataMember()]
        [ProtoMember(10)]
        public decimal Voids
        {
            get;set;
        }       

        /// <summary>
        /// Total expected.
        /// </summary>
        [DataMember()]
        [ProtoMember(11)]
        public decimal Expected
        {
            get; set;
        }

        /// <summary>
        /// Actual.
        /// </summary>
        [DataMember()]
        [ProtoMember(12)]
        public decimal Actual
        {
            get; set;
        }

        /// <summary>
        /// Difference.
        /// </summary>
        [DataMember()]
        [ProtoMember(13)]
        public decimal Difference
        {
            get; set;
        }

        /// <summary>
        /// Note.
        /// </summary>
        [DataMember()]
        [ProtoMember(14)]
        public string Note
        {
            get; set;
        }

        /// <summary>
        /// Count payment method name.
        /// </summary>
        [DataMember()]
        [ProtoMember(15)]
        public string PaymentMethodName
        {
            get;set;
        }

        #endregion
    }
}
