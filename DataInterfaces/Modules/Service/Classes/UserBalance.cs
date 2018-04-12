using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// User balance class.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class UserBalance
    {
        #region CONSTRUCTOR

        public UserBalance()
        { }

        public UserBalance(int userId,
            decimal deposits,
            int points,
            decimal onInvoices,
            decimal onInvoicedUsage,
            decimal onActiveUsage,
            double? totalUserTime,
            double? totalCreditedTime,
            double timeProduct,
            double timeFixed)
        {
            this.UserId = userId;

            this.Deposits = deposits;
            this.Points = points;

            this.OnInvoices = onInvoices;
            this.OnInvoicedUsage = onInvoicedUsage;
            this.OnUninvoicedUsage = onActiveUsage;

            this.AvailableTime = totalUserTime;
            this.AvailableCreditedTime = totalCreditedTime;
            this.TimeProduct = timeProduct;
            this.TimeFixed = timeFixed;
        }

        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets user id.
        /// </summary>
        [DataMember(Order = 0)]
        [ProtoMember(1)]
        public int UserId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets total user deposits.
        /// </summary>
        [DataMember(Order = 1)]
        [ProtoMember(2)]
        public decimal Deposits
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets total user points.
        /// </summary>
        [DataMember(Order = 2)]
        [ProtoMember(3)]
        public int Points
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets total outstanding amount on invoices.
        /// </summary>
        [DataMember(Order = 3)]
        [ProtoMember(4)]
        public decimal OnInvoices
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets total outstanding amount on invoiced usage sessions.
        /// </summary>
        [DataMember(Order = 4)]
        [ProtoMember(5)]
        public decimal OnInvoicedUsage
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets total outstanding amount on current active usage session.
        /// </summary>
        [DataMember(Order = 5)]
        [ProtoMember(6)]
        public decimal OnUninvoicedUsage
        {
            get;
            set;
        }

        /// <summary>
        /// Gets total amount of time on time product purchases.
        /// </summary>
        [DataMember(Order = 6)]
        [ProtoMember(7)]
        public double TimeProduct
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets total amount of time on fixed time purchases.
        /// </summary>
        [DataMember(Order = 7)]
        [ProtoMember(8)]
        public double TimeFixed
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets total time based on user deposits and time products.
        /// </summary>
        [DataMember(Order = 8)]
        [ProtoMember(9)]
        public double? AvailableTime
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets total time based on user deposits and time products.
        /// This value also includes time based on credit limit.
        /// </summary>
        [DataMember(Order = 9)]
        [ProtoMember(10)]
        public double? AvailableCreditedTime
        {
            get; set;
        }

        #region COMPUTED

        /// <summary>
        /// Gets current balance.
        /// </summary>
        [DataMember(Order = 10)]
        [ProtoIgnore()]
        public decimal Balance
        {
            get { return this.Deposits - this.OnInvoices - this.OnUninvoicedUsage; }
        }

        /// <summary>
        /// Gets time balance on product time.
        /// </summary>
        [DataMember(Order = 11)]
        [ProtoIgnore()]
        public double TimeProductBalance
        {
            get { return this.TimeProduct + this.TimeFixed; }
        }

        /// <summary>
        /// Gets usage session balance.
        /// </summary>
        /// <remarks>
        /// This balance is represented by sum of invoiced and active usage. 
        /// </remarks>
        [DataMember(Order = 12)]
        [ProtoIgnore()]
        public decimal UsageBalance
        {
            get { return this.OnInvoicedUsage + this.OnUninvoicedUsage; }
        }

        /// <summary>
        /// Gets total outstanding.
        /// </summary>
        [DataMember(Order = 13)]
        [ProtoIgnore()]
        public decimal TotalOutstanding
        {
            get { return this.OnInvoices + this.OnUninvoicedUsage; }
        }

        #endregion

        #endregion
    }
}
