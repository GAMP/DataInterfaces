using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Invoice line time fixed entity.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class InvoiceLineTimeFixed : InvoiceLine
    {
        #region InvoiceLineTimeFixed

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
        /// Gets or sets if product is depleted.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public bool IsDepleted
        {
            get; set;
        }

        #endregion
    }
}