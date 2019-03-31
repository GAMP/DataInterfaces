using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class ProductOrderAcceptInfo
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets product order id.
        /// </summary>
        [ProtoMember(1)]
        public int ProductOrderId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets invoice id.
        /// </summary>
        [ProtoMember(2)]
        public int InvoiceId
        {
            get; set;
        } 

        #endregion
    }
}
