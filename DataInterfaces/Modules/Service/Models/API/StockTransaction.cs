using ProtoBuf;
using SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Stock transaction entity.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class StockTransaction : ModifiableByUserBase
    {
        #region StockTransaction

        /// <summary>
        /// Gets or sets product id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int ProductId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets source product id.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public int? SourceProductId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets stock transaction type.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public StockTransactionType Type
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets transaction amount.
        /// </summary>
        [DataMember()]
        [ProtoMember(4)]
        public decimal Amount
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets on hand stock amount.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public decimal OnHand
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets amount of source product.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        public decimal? SourceProductAmount
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets amount of source product on hand.
        /// </summary>
        [DataMember()]
        [ProtoMember(7)]
        public decimal? SourceProductOnHand
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if voided.
        /// </summary>
        [DataMember()]
        [ProtoMember(8)]
        public bool IsVoided
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets shift id.
        /// </summary>
        [DataMember()]
        [ProtoMember(9)]
        public int? ShiftId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets register id.
        /// </summary>
        [DataMember()]
        [ProtoMember(10)]
        public int? RegisterId
        {
            get; set;
        }

        #endregion

    }
}
