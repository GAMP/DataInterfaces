using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Product order accept result.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class ProductOrderAcceptResult
    {
        #region PROPERTIES

        /// <summary>
        /// Product order id.
        /// </summary>
        [ProtoMember(1)]
        public int ProductOrderId
        {
            get; set;
        }

        /// <summary>
        /// Invoice id.
        /// </summary>
        [ProtoMember(2)]
        public int InvoiceId
        {
            get; set;
        } 

        #endregion
    }
}
