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

        /// <summary>
        /// Creates new instance.
        /// </summary>
        public UserBalance()
        { }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="userId">User id.</param>
        /// <param name="deposits">Deposits.</param>
        /// <param name="points">Points.</param>
        /// <param name="onInvoices">On invoices.</param>
        /// <param name="onInvoicedUsage">On invoiced usage.</param>
        /// <param name="onActiveUsage">On active usage.</param>
        /// <param name="totalUserTime">Total time.</param>
        /// <param name="totalCreditedTime">Total credited time.</param>
        /// <param name="timeProduct">Total time on time products.</param>
        /// <param name="timeFixed">Total time on fixed time products.</param>
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
            UserId = userId;

            Deposits = deposits;
            Points = points;

            OnInvoices = onInvoices;
            OnInvoicedUsage = onInvoicedUsage;
            OnUninvoicedUsage = onActiveUsage;

            AvailableTime = totalUserTime;
            AvailableCreditedTime = totalCreditedTime;
            TimeProduct = timeProduct;
            TimeFixed = timeFixed;
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
            get { return Deposits - OnInvoices - OnUninvoicedUsage; }
        }

        /// <summary>
        /// Gets time balance on product time.
        /// </summary>
        [DataMember(Order = 11)]
        [ProtoIgnore()]
        public double TimeProductBalance
        {
            get { return TimeProduct + TimeFixed; }
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
            get { return OnInvoicedUsage + OnUninvoicedUsage; }
        }

        /// <summary>
        /// Gets total outstanding.
        /// </summary>
        [DataMember(Order = 13)]
        [ProtoIgnore()]
        public decimal TotalOutstanding
        {
            get { return OnInvoices + OnUninvoicedUsage; }
        }

        #endregion

        #endregion
    }
}
