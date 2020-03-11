using ProtoBuf;
using SharedLib;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Invoice line entity.
    /// </summary>
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class InvoiceLine : ModifiableByWithRequiredUserMemberBase
    {
        #region InvoiceLine

        /// <summary>
        /// Gets or sets invoice id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int InvoiceId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets product name.
        /// </summary>
        [DataMember()]
        [Required()]
        [StringLength(45)]
        [ProtoMember(2)]
        public string ProductName
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets quantity.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public decimal Quantity
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets unit price.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public decimal UnitPrice
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets unit list price.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public decimal UnitListPrice
        {
            get; set;
        }

        /// <summary>
        /// Gets or set total price.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        public decimal Total
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets total points price.
        /// </summary>
        [DataMember()]
        [ProtoMember(7)]
        public int PointsTotal
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets product points.
        /// </summary>
        [DataMember()]
        [ProtoMember(8)]
        public int? Points
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets points award for the invoice line.
        /// </summary>
        [DataMember()]
        [ProtoMember(9)]
        public int PointsAward
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets tax rate.
        /// </summary>
        [DataMember()]
        [ProtoMember(10)]
        public decimal TaxRate
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets total amount of tax.
        /// </summary>
        [DataMember()]
        [ProtoMember(11)]
        public decimal TaxTotal
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets total pre taxed price.
        /// </summary>
        [DataMember()]
        [ProtoMember(12)]
        public decimal PreTaxTotal
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets points transaction id.
        /// </summary>
        [DataMember()]
        [ProtoMember(13)]
        public int? PointsTransactionId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if line is deleted.
        /// </summary>
        [DataMember()]
        [ProtoMember(14)]
        public bool IsDeleted
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if line is voided.
        /// </summary>
        [DataMember()]
        [ProtoMember(15)]
        public bool IsVoided
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets shift id.
        /// </summary>
        [DataMember()]
        [ProtoMember(16)]
        public int? ShiftId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets register id.
        /// </summary>
        [DataMember()]
        [ProtoMember(17)]
        public int? RegisterId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets points unit price.
        /// </summary>
        [DataMember()]
        [ProtoMember(18)]
        public int UnitPointsPrice
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets unit list price.
        /// </summary>
        [DataMember()]
        [ProtoMember(19)]
        public int? UnitPointsListPrice
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets pay type.
        /// </summary>
        [DataMember()]
        [ProtoMember(20)]
        public OrderLinePayType PayType
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets unit cost.
        /// </summary>
        [DataMember()]
        [ProtoMember(21)]
        public decimal? UnitCost
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets cost.
        /// </summary>
        [DataMember()]
        [ProtoMember(22)]
        public decimal? Cost
        {
            get; set;
        }

        #endregion
    }
}
