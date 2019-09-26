using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;

namespace ServerService
{
    /// <summary>
    /// Sale report model.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class SaleReport
    {
        #region PROPERTIES

        /// <summary>
        /// Product sales.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public IEnumerable<SaleReportProductEntry> Products
        {
            get; set;
        }

        /// <summary>
        /// Fixed time sales.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public IEnumerable<SaleReportProductEntry> FixedTime
        {
            get;set;
        }

        /// <summary>
        /// Deleted time product.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public IEnumerable<SaleReportProductEntry> DeletedTimeProducts
        {
            get;set;
        }

        /// <summary>
        /// Total session time sold (in seconds).
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public decimal SessionTime
        {
            get; set;
        }

        /// <summary>
        /// Gets total session time.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public decimal SessionTimeTotal
        {
            get; set;
        }

        /// <summary>
        /// Total session time sold (in minutes).
        /// </summary>
        [DataMember()]
        [ProtoIgnore()]
        public int SessionTimeMinutes
        {
            get { return (int)Math.Round(this.SessionTime); }
        }

        /// <summary>
        /// Total product sum.
        /// </summary>
        [DataMember()]
        [ProtoIgnore()]
        public decimal ProductTotal
        {
            get
            {
                return Products?.Sum(product => product.Total) ?? 0;
            }
        }

        /// <summary>
        /// Total fixed time sum.
        /// </summary>
        [DataMember()]
        [ProtoIgnore()]
        public decimal FixedTimeTotal
        {
            get
            {
                return FixedTime?.Sum(product => product.Total) ?? 0;
            }
        }

        /// <summary>
        /// Total time sum.
        /// </summary>
        [DataMember()]
        [ProtoIgnore()]
        public decimal TimeTotal
        {
            get { return FixedTimeTotal + SessionTimeTotal; }
        }

        /// <summary>
        /// Total deleted time (in seconds).
        /// </summary>
        [DataMember()]
        [ProtoIgnore()]
        public decimal DeletedTimeTotal
        {
            get
            {
                return DeletedTimeProducts?.Sum(product => product.Total) ?? 0;
            }
        }

        #endregion
    }
}
