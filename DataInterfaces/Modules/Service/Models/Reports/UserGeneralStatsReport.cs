using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// User general report model.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class UserGeneralReport
    {
        #region PROPERTIES

        /// <summary>
        /// User id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int UserId
        {
            get; set;
        }

        /// <summary>
        /// User creation date.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public DateTime Created
        {
            get; set;
        }

        /// <summary>
        /// Total amount of points earned.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public int TotalPoints
        {
            get; set;
        }

        /// <summary>
        /// Total points redeemed.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public int TotalPointsRedeemed
        {
            get; set;
        }

        /// <summary>
        /// Total amount of deposits.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public decimal TotalDeposits
        {
            get; set;
        }

        /// <summary>
        /// Total amount of withdrawals.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        public decimal TotalWitdrawals
        {
            get; set;
        }

        /// <summary>
        /// Total spent.
        /// </summary>
        [DataMember()]
        [ProtoMember(7)]
        public decimal TotalSpent
        {
            get; set;
        }

        /// <summary>
        /// Total spent on products.
        /// </summary>
        [DataMember()]
        [ProtoMember(8)]
        public decimal TotalProductSpent
        {
            get; set;
        }

        /// <summary>
        /// Total amount spent on session.
        /// </summary>
        [DataMember()]
        [ProtoMember(9)]
        public decimal TotalSessionSpent
        {
            get; set;
        }

        /// <summary>
        /// Total amount spent on time products.
        /// </summary>
        [DataMember()]
        [ProtoMember(10)]
        public decimal TotalTimeProductSpent
        {
            get; set;
        }

        /// <summary>
        /// Total login sessions.
        /// </summary>
        [DataMember()]
        [ProtoMember(11)]
        public int TotalSessions
        {
            get; set;
        }

        /// <summary>
        /// Total session time.
        /// </summary>
        [DataMember()]
        [ProtoMember(12)]
        public double TotalSessionTime
        {
            get; set;
        }

        /// <summary>
        /// Total amount sepnt on fixed time.
        /// </summary>
        [DataMember()]
        [ProtoMember(13)]
        public decimal TotalFixedTimeSpent
        {
            get; set;
        }

        /// <summary>
        /// Timespan representing membership duration.
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
        
        /// <summary>
        /// Total amount spent on time.
        /// </summary>
        [IgnoreDataMember()]
        [ProtoIgnore()]
        public decimal TotalTimeSpent
        {
            get { return TotalFixedTimeSpent + TotalSessionSpent + TotalTimeProductSpent; }
        }

        #endregion
    }
}
