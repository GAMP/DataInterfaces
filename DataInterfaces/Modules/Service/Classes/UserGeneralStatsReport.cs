using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class UserGeneralReport
    {
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
        /// Gets or sets user creation date.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public DateTime Created
        {
            get;set;
        }

        /// <summary>
        /// Gets total amount of points earned.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public int TotalPoints
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets total points redeemed.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public int TotalPointsRedeemed
        {
            get; set;
        }

        /// <summary>
        /// Gets total amount of deposits.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public decimal TotalDeposits
        {
            get;set;
        }

        /// <summary>
        /// Gets total amount of withdrawals.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        public decimal TotalWitdrawals
        {
            get;set;
        }

        /// <summary>
        /// Gets total spent.
        /// </summary>
        [DataMember()]
        [ProtoMember(7)]
        public decimal TotalSpent
        {
            get;set;
        }

        /// <summary>
        /// Gets total spent on products.
        /// </summary>
        [DataMember()]
        [ProtoMember(8)]
        public decimal TotalProductSpent
        {
            get;set;
        }

        /// <summary>
        /// Gets total amount spent on session.
        /// </summary>
        [DataMember()]
        [ProtoMember(9)]
        public decimal TotalSessionSpent
        {
            get;set;
        }

        /// <summary>
        /// Gets total amount spent on time products.
        /// </summary>
        [DataMember()]
        [ProtoMember(10)]
        public decimal TotalTimeProductSpent
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets total login sessions.
        /// </summary>
        [DataMember()]
        [ProtoMember(11)]
        public int TotalSessions
        {
            get;set;
        }

        /// <summary>
        /// Gets or sets total session time.
        /// </summary>
        [DataMember()]
        [ProtoMember(12)]
        public double TotalSessionTime
        {
            get;set;
        }

        /// <summary>
        /// Gets timespan representing membership duration.
        /// </summary>
        [IgnoreDataMember()]
        [ProtoIgnore()]
        public TimeSpan MembershipDuration
        {
            get
            {
                return DateTime.Now.Subtract(Created);
            }
        }
    }
}
