using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;

namespace ServerService
{
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class SaleReport
    {
        #region PROPERTIES

        /// <summary>
        /// Gets product totals.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public IEnumerable<SaleReportProductEntry> Products
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets fixed time sales.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public IEnumerable<SaleReportProductEntry> FixedTime
        {
            get;set;
        }

        /// <summary>
        /// Gets deleted time product.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public IEnumerable<SaleReportProductEntry> DeletedTimeProducts
        {
            get;set;
        }

        /// <summary>
        /// Gets session time seconds sold.
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
        /// Gets total session time minutes.
        /// </summary>
        [DataMember()]
        [ProtoIgnore()]
        public int SessionTimeMinutes
        {
            get { return (int)Math.Round(this.SessionTime / 60,0); }
        }

        /// <summary>
        /// Gets product total.
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
        /// Gets fixed time total.
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
        /// Gets time total.
        /// </summary>
        [DataMember()]
        [ProtoIgnore()]
        public Decimal TimeTotal
        {
            get { return this.FixedTimeTotal + this.SessionTimeTotal; }
        }

        /// <summary>
        /// Gets deleted time total.
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

    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class SaleReportProductEntry
    {
        #region PROPERTIES
        
        /// <summary>
        /// Gets or set product name.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public string ProductName
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets quantity.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public decimal Quantity
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets total.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public decimal Total
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets entry type.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public ReportEntryType Type
        {
            get; set;
        }

        #endregion
    }

    public enum ReportEntryType
    {
        Product,
        TimeOffer,
        FixedTime,
    }
}
