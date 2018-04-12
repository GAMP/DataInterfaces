using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerService
{
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
        /// Gets or sets shift id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int ShiftId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets shift operator id.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public int OperatorId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets register id.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public int RegisterId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets operator username.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public string Operator
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets register number.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public int RegisterNumber
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets register name.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        public string RegisterName
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets shift start time.
        /// </summary>
        [DataMember()]
        [ProtoMember(7)]
        public DateTime ShiftStart
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets shift start cash.
        /// </summary>
        [DataMember()]
        [ProtoMember(8)]
        public decimal StartCash
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets shift is currently ending.
        /// </summary>
        [DataMember()]
        [ProtoMember(9)]
        public bool IsEnding
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets ended by id.
        /// </summary>
        [DataMember()]
        [ProtoMember(10)]
        public int? EndedById
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets ended by operator name.
        /// </summary>
        [DataMember()]
        [ProtoMember(11)]
        public string EndedBy
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if shift is active.
        /// </summary>
        [DataMember()]
        [ProtoMember(12)]
        public bool IsActive
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets created by id.
        /// </summary>
        [DataMember()]
        [ProtoMember(13)]
        public int? CreatedById
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets created by.
        /// </summary>
        [DataMember()]
        [ProtoMember(14)]
        public string CreatedBy
        {
            get; set;
        }

        [DataMember()]
        [ProtoMember(15)]
        public decimal PayIns
        {
            get; set;
        }

        [DataMember()]
        [ProtoMember(16)]
        public decimal PayOuts
        {
            get; set;
        }

        [DataMember()]
        [ProtoMember(17)]
        public decimal Withdrawals
        {
            get; set;
        }

        [DataMember()]
        [ProtoMember(18)]
        public Dictionary<int, PaymentSummary> Payments
        {
            get
            {
                if (this.payments == null)
                    this.payments = new Dictionary<int, PaymentSummary>();
                return this.payments;
            }
            set
            {
                this.payments = value;
            }
        }

        [DataMember()]
        [ProtoMember(19)]
        public Dictionary<int, PaymentSummary> DepositPayments
        {
            get
            {
                if (this.deposits == null)
                    this.deposits = new Dictionary<int, PaymentSummary>();
                return this.deposits;
            }
            set
            {
                this.deposits = value;
            }
        }

        [DataMember()]
        [ProtoMember(20)]
        public Dictionary<int, ShiftCountSummary> Counts
        {
            get
            {
                if (this.counts == null)
                    this.counts = new Dictionary<int, ShiftCountSummary>();
                return this.counts;
            }
            set
            {
                this.counts = value;
            }
        }

        [DataMember()]
        [ProtoMember(22)]
        public Dictionary<int,PaymentSummary> Refunds
        {
            get
            {
                if (this.refunds == null)
                    this.refunds = new Dictionary<int, PaymentSummary>();
                return this.refunds;
            }
            set { this.refunds = value; }
        }

        [DataMember()]
        [ProtoMember(21)]
        public DateTime? ShiftEnd
        {
            get;set;
        }

        #endregion
    }
}
