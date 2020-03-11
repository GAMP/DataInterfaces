using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Invoice line usage session entity.
    /// </summary>
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class InvoiceLineSession : InvoiceLine
    {
        #region InvoiceLineSession

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
        /// Gets or sets session id.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public int UsageSessionId
        {
            get; set;
        }

        #endregion
    }
}
