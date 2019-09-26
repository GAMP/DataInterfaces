using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Shift report model.
    /// </summary>
    [ProtoContract()]
    [Serializable()]
    [DataContract()]
    public class ShiftReport
    {
        #region FIELDS
        private Dictionary<int, PaymentSummary> payments;
        private Dictionary<int, PaymentSummary> deposits;
        private Dictionary<int, PaymentSummary> refunds;
        private Dictionary<int, ShiftCountSummary> counts;
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
        /// Shift operator id.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public int OperatorId
        {
            get; set;
        }

        /// <summary>
        /// Register id.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public int RegisterId
        {
            get; set;
        }

        /// <summary>
        /// Operator user name.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public string Operator
        {
            get; set;
        }

        /// <summary>
        /// Register number.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public int RegisterNumber
        {
            get; set;
        }

        /// <summary>
        /// Register name.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        public string RegisterName
        {
            get; set;
        }

        /// <summary>
        /// Shift start time.
        /// </summary>
        [DataMember()]
        [ProtoMember(7)]
        public DateTime ShiftStart
        {
            get; set;
        }

        /// <summary>
        /// Shift start cash.
        /// </summary>
        [DataMember()]
        [ProtoMember(8)]
        public decimal StartCash
        {
            get; set;
        }

        /// <summary>
        /// Indicates if shift is currently ending.
        /// </summary>
        [DataMember()]
        [ProtoMember(9)]
        public bool IsEnding
        {
            get; set;
        }

        /// <summary>
        /// Ended by id.
        /// </summary>
        [DataMember()]
        [ProtoMember(10)]
        public int? EndedById
        {
            get; set;
        }

        /// <summary>
        /// Ended by operator user name.
        /// </summary>
        [DataMember()]
        [ProtoMember(11)]
        public string EndedBy
        {
            get; set;
        }

        /// <summary>
        /// Indicates if shift is active.
        /// </summary>
        [DataMember()]
        [ProtoMember(12)]
        public bool IsActive
        {
            get; set;
        }

        /// <summary>
        /// Created by id.
        /// </summary>
        [DataMember()]
        [ProtoMember(13)]
        public int? CreatedById
        {
            get; set;
        }

        /// <summary>
        /// Created by operator user name.
        /// </summary>
        [DataMember()]
        [ProtoMember(14)]
        public string CreatedBy
        {
            get; set;
        }

        /// <summary>
        /// Total pay-in's.
        /// </summary>
        [DataMember()]
        [ProtoMember(15)]
        public decimal PayIns
        {
            get; set;
        }

        /// <summary>
        /// Total pay-out's.
        /// </summary>
        [DataMember()]
        [ProtoMember(16)]
        public decimal PayOuts
        {
            get; set;
        }

        /// <summary>
        /// Total withdrawals.
        /// </summary>
        [DataMember()]
        [ProtoMember(17)]
        public decimal Withdrawals
        {
            get; set;
        }

        /// <summary>
        /// Payments.
        /// </summary>
        [DataMember()]
        [ProtoMember(18)]
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
                payments = value;
            }
        }

        /// <summary>
        /// Deposit payments.
        /// </summary>
        [DataMember()]
        [ProtoMember(19)]
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
                deposits = value;
            }
        }

        /// <summary>
        /// Counts.
        /// </summary>
        [DataMember()]
        [ProtoMember(20)]
        public Dictionary<int, ShiftCountSummary> Counts
        {
            get
            {
                if (counts == null)
                    counts = new Dictionary<int, ShiftCountSummary>();
                return counts;
            }
            set
            {
                this.counts = value;
            }
        }

        /// <summary>
        /// Refunds.
        /// </summary>
        [DataMember()]
        [ProtoMember(22)]
        public Dictionary<int,PaymentSummary> Refunds
        {
            get
            {
                if (refunds == null)
                    refunds = new Dictionary<int, PaymentSummary>();
                return refunds;
            }
            set { refunds = value; }
        }

        /// <summary>
        /// Shift end time.
        /// </summary>
        [DataMember()]
        [ProtoMember(21)]
        public DateTime? ShiftEnd
        {
            get;set;
        }

        #endregion
    }
}
