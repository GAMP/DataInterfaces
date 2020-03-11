using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Extended invoice line entity.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class InvoiceLineExtended : InvoiceLine
    {
        #region InvoiceLineExtended

        /// <summary>
        /// Gets or sets bundle line id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int? BundleLineId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets stock transaction id.
        /// <remarks>This value is set when order line generates stock transaction.</remarks>
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public int? StockTransactionId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets stock return transaction id.
        /// </summary>
        /// <remarks>
        /// This value is set when order line item is returned to stock.
        /// </remarks>
        [DataMember()]
        [ProtoMember(3)]
        public int? StockReturnTransactionId
        {
            get; set;
        }

        #endregion
    }
}
