using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Shift summary report model.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class ShiftSummaryReport
    {
        #region FIELDS
        private Dictionary<int, PaymentSummary> payments;
        private Dictionary<int, PaymentSummary> deposits;
        private Dictionary<int, PaymentSummary> refunds;
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
        /// Start cash.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public decimal StartCash
        {
            get; set;
        }

        /// <summary>
        /// Total pay ins.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public decimal PayIns
        {
            get; set;
        }

        /// <summary>
        /// Total pay outs.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public decimal PayOuts
        {
            get; set;
        }

        /// <summary>
        /// Total withdrawals.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public decimal Withdrawals
        {
            get; set;
        }

        /// <summary>
        /// Payments.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        public Dictionary<int, PaymentSummary> Payments
        {
            get
            {
                if (payments == null)
                    payments = new Dictionary<int, PaymentSummary>();
                return payments;
            }
            set
            {
                this.payments = value;
            }
        }

        /// <summary>
        /// Deposit payments.
        /// </summary>
        [DataMember()]
        [ProtoMember(7)]
        public Dictionary<int, PaymentSummary> DepositPayments
        {
            get
            {
                if (deposits == null)
                    deposits = new Dictionary<int, PaymentSummary>();
                return deposits;
            }
            set
            {
                this.deposits = value;
            }
        }

        /// <summary>
        /// Refunds.
        /// </summary>
        [DataMember()]
        [ProtoMember(8)]
        public Dictionary<int,PaymentSummary> Refunds
        {
            get
            {
                if (refunds == null)
                    refunds = new Dictionary<int, PaymentSummary>();
                return refunds;
            }
            set
            {
                refunds = value;
            }
        }

        #endregion
    }
}
