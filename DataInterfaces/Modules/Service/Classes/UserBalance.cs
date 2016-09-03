using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerService
{
    /// <summary>
    /// User balance class.
    /// </summary>
    [Serializable()]
    [DataContract()]
    public class UserBalance
    {
        #region CONSTRUCTOR
        public UserBalance(int userId, decimal deposits, int points,decimal onInvoices,decimal onInvoicedUsage,decimal onActiveUsage,double? timeOnUsageBalance,double timeProduct,double timeFixed)
        {
            this.UserId = userId;

            this.Deposits = deposits;
            this.Points = points;

            this.OnInvoices = onInvoices;
            this.OnInvoicedUsage = onInvoicedUsage;
            this.OnUninvoicedUsage = onActiveUsage;

            this.AvailableTime = timeOnUsageBalance;
            this.TimeProduct = timeProduct;
            this.TimeFixed = timeFixed;
        }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets user id.
        /// </summary>
        [DataMember(Order = 0)]
        public int UserId
        {
            get; protected set;
        }

        /// <summary>
        /// Gets deposits balance.
        /// </summary>
        [DataMember(Order = 1)]
        public decimal Deposits
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets points balance.
        /// </summary>
        [DataMember(Order = 2)]
        public int Points
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets total outstanding amount on invoices.
        /// </summary>
        [DataMember(Order = 3)]
        public decimal OnInvoices
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets total outstanding amount on invoiced usage sessions.
        /// </summary>
        [DataMember(Order = 4)]
        public decimal OnInvoicedUsage
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets total outstanding amount on current active usage session.
        /// </summary>
        [DataMember(Order = 5)]
        public decimal OnUninvoicedUsage
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets total amount of time on time product purchases.
        /// </summary>
        [DataMember(Order =6)]
        public double TimeProduct
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets total amount of time on fixed time purchases.
        /// </summary>
        [DataMember(Order =7)]
        public double TimeFixed
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets total time based on user deposits.
        /// </summary>
        [DataMember(Order =8)]
        public double? AvailableTime
        {
            get;
            protected set;
        }

        #region BALANCES

        /// <summary>
        /// Gets current balance.
        /// </summary>
        [DataMember()]
        public decimal Balance
        {
            get { return this.Deposits - this.OnInvoices - this.OnUninvoicedUsage; }
        }

        /// <summary>
        /// Gets time balance on product time.
        /// </summary>
        [DataMember()]
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
        [DataMember()]
        public decimal UsageBalance
        {
            get { return this.OnInvoicedUsage + this.OnUninvoicedUsage; }
        } 

        #endregion  



        #endregion
    }
}
