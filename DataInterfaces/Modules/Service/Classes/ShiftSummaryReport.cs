using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService
{
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

        [DataMember()]
        [ProtoMember(1)]
        public int ShiftId
        {
            get; set;
        }

        [DataMember()]
        [ProtoMember(2)]
        public decimal StartCash
        {
            get; set;
        }

        [DataMember()]
        [ProtoMember(3)]
        public decimal PayIns
        {
            get; set;
        }

        [DataMember()]
        [ProtoMember(4)]
        public decimal PayOuts
        {
            get; set;
        }

        [DataMember()]
        [ProtoMember(5)]
        public decimal Withdrawals
        {
            get; set;
        }

        [DataMember()]
        [ProtoMember(6)]
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
        [ProtoMember(7)]
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
        [ProtoMember(8)]
        public Dictionary<int,PaymentSummary> Refunds
        {
            get
            {
                if (this.refunds == null)
                    this.refunds = new Dictionary<int, PaymentSummary>();
                return this.refunds;
            }
            set
            {
                this.refunds = value;
            }
        }

        #endregion
    }
}
