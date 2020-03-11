using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Invoice void entity.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class VoidInvoice : EntityWithShift
    {
        #region VoidInvoice

        /// <summary>
        /// Gets or sets invoice id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int InvoiceId
        {
            get; set;
        }

        #endregion
    }
}
