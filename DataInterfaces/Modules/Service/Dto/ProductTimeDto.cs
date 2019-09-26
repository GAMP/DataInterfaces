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
    [ProtoInclude(500,typeof(ProductTimeExtendedDTO))]
    public class ProductTimeDTO
    {
        #region CONSTRUCTOR
        /// <summary>
        /// Creates new instance.
        /// </summary>
        public ProductTimeDTO()
        { }
        #endregion

        #region PROPERTIES

        /// <summary>
        /// Gets or sets invoice id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int InvoiceId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets invoice line id.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public int InvoiceLineId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets product name.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public string ProductName
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets purchase date.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public DateTime PurchaseDate
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets total seconds.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public double TotalSeconds
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets used seconds.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        public double UsedSeconds
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if product expires at logout.
        /// </summary>
        [DataMember()]
        [ProtoMember(7)]
        public bool ExpiresAtLogout
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets expiry date.
        /// </summary>
        [DataMember()]
        [ProtoMember(8)]
        public DateTime? ExpiryDate
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if product is fully paid.
        /// </summary>
        [DataMember()]
        [ProtoMember(9)]
        public bool IsPaid
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if product is depelted.
        /// </summary>
        [DataMember()]
        [ProtoMember(10)]
        public bool IsDepleted
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if purchase is deleted.
        /// </summary>
        [DataMember()]
        [ProtoMember(11)]
        public bool IsDeleted
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if purchase is voided.
        /// </summary>
        [DataMember()]
        [ProtoMember(12)]
        public bool IsVoided
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if specified purchase is expired.
        /// </summary>
        [DataMember()]
        [ProtoMember(13)]
        public bool IsExpired
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets type.
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

    /// <summary>
    /// Extended product time dto.
    /// </summary>
    [NotMapped()]
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class ProductTimeExtendedDTO : ProductTimeDTO
    {
        #region PROPERTIES
        /// <summary>
        /// Gets or sets descirption.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        [ProtoMember(1)]
        public string Description
        {
            get; set;
        } 
        #endregion
    }
}
