using ProtoBuf;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// User product time DTO.
    /// </summary>
    [NotMapped()]
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    [ProtoInclude(500,typeof(UserProductTimeExtended))]
    public class UserProductTime
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        public UserProductTime()
        { }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Invoice id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int InvoiceId
        {
            get; set;
        }

        /// <summary>
        /// Invoice line id.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public int InvoiceLineId
        {
            get; set;
        }

        /// <summary>
        /// Product name.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public string ProductName
        {
            get; set;
        }

        /// <summary>
        /// Purchase date.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public DateTime PurchaseDate
        {
            get; set;
        }

        /// <summary>
        /// Total seconds in time product.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public double TotalSeconds
        {
            get; set;
        }

        /// <summary>
        /// Total used seconds.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        public double UsedSeconds
        {
            get; set;
        }

        /// <summary>
        /// Indicates if product expires at logout.
        /// </summary>
        [DataMember()]
        [ProtoMember(7)]
        public bool ExpiresAtLogout
        {
            get; set;
        }

        /// <summary>
        /// Expiry date.
        /// </summary>
        [DataMember()]
        [ProtoMember(8)]
        public DateTime? ExpiryDate
        {
            get; set;
        }

        /// <summary>
        /// Indicates if product is fully paid.
        /// </summary>
        [DataMember()]
        [ProtoMember(9)]
        public bool IsPaid
        {
            get; set;
        }

        /// <summary>
        /// Indicates if product is depelted.
        /// </summary>
        [DataMember()]
        [ProtoMember(10)]
        public bool IsDepleted
        {
            get; set;
        }

        /// <summary>
        /// Indicates if product is deleted.
        /// </summary>
        [DataMember()]
        [ProtoMember(11)]
        public bool IsDeleted
        {
            get; set;
        }

        /// <summary>
        /// Indicates if product is voided.
        /// </summary>
        [DataMember()]
        [ProtoMember(12)]
        public bool IsVoided
        {
            get; set;
        }

        /// <summary>
        /// Indicates if product expired.
        /// </summary>
        [DataMember()]
        [ProtoMember(13)]
        public bool IsExpired
        {
            get; set;
        }

        /// <summary>
        /// Time product type.
        /// </summary>
        [DataMember()]
        [ProtoMember(14)]
        public UserProductTimeType Type
        {
            get; set;
        }

        #region COMPUTED

        /// <summary>
        /// Gets seconds left.
        /// </summary>
        [DataMember()]
        [ProtoIgnore()]
        public double SecondsLeft
        {
            get { return TotalSeconds - UsedSeconds; }
        }

        #endregion

        #endregion
    }
}
