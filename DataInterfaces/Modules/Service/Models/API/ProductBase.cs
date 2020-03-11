using ProtoBuf;
using SharedLib;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Product base entity.
    /// </summary>
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class ProductBase : ModifiableByUserBase
    {
        #region ProductBase

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        [DataMember()]
        [Required()]
        [StringLength(45)]
        [ProtoMember(1)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets description.
        /// </summary>
        [StringLength(65535)]
        [DataMember()]
        [ProtoMember(2)]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets price.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets cost.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public decimal? Cost { get; set; }

        /// <summary>
        /// Gets or sets order options.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public OrderOptionType OrderOptions { get; set; }

        /// <summary>
        /// Gets or sets purchase options.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        public PurchaseOptionType PurchaseOptions { get; set; }

        /// <summary>
        /// Gets or sets points.
        /// </summary>
        [DataMember()]
        [ProtoMember(7)]
        public int? Points { get; set; }

        /// <summary>
        /// Gets or sets price points.
        /// </summary>
        [DataMember()]
        [ProtoMember(8)]
        public int? PointsPrice { get; set; }

        /// <summary>
        /// Gets or sets barcode.
        /// </summary>
        [DataMember()]
        [StringLength(255)]
        [ProtoMember(9)]
        public string Barcode { get; set; }

        /// <summary>
        /// Gets or sets stock options.
        /// </summary>
        [DataMember()]
        [ProtoMember(10)]
        public StockOptionType StockOptions
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets stock alert.
        /// </summary>
        [DataMember()]
        [ProtoMember(11)]
        public decimal StockAlert
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets stock product id.
        /// </summary>
        [DataMember()]
        [ProtoMember(12)]
        public int? StockProductId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets stock product amount.
        /// </summary>
        [DataMember()]
        [ProtoMember(13)]
        public decimal StockProductAmount
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets is deleted.
        /// </summary>
        [DataMember()]
        [ProtoMember(14)]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets product group id.
        /// </summary>
        [DataMember()]
        [ProtoMember(15)]
        public int ProductGroupId { get; set; }

        /// <summary>
        /// Gets or sets display order.
        /// </summary>
        [DataMember()]
        [ProtoMember(16)]
        public int DisplayOrder
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets entity guid.
        /// </summary>
        [DataMember()]
        [ProtoMember(17)]
        public Guid Guid
        {
            get; set;
        }

        #endregion

    }
}
