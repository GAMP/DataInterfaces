using ProtoBuf;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Creates new instance.
    /// </summary>
    public class InvoiceLineProduct : InvoiceLineExtended
    {
        #region InvoiceLineProduct

        /// <summary>
        /// Gets or set order line.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int OrderLineId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets product id.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public int ProductId
        {
            get; set;
        }

        #endregion
    }
}
