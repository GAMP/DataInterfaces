using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Invoice line time entity.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class InvoiceLineTime : InvoiceLineExtended
    {
        #region InvoiceLineTime

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
        /// Gets or sets product time id.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public int ProductTimeId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets if product is depleted.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public bool IsDepleted
        {
            get; set;
        }

        #endregion
    }
}