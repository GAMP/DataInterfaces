using ProtoBuf;
using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Client product order entry.
    /// </summary>
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class ClientProductOrderEntry
    {
        #region PROPERTIES

        /// <summary>
        /// Product id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int ProductId
        {
            get; set;
        }

        /// <summary>
        /// Product quantity.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public decimal Quantity
        {
            get; set;
        }

        /// <summary>
        /// Prefered payment type.
        /// </summary>
        [DataMember()]
        [ProtoMember(3)]
        public OrderLinePayType PayType
        {
            get; set;
        } 

        #endregion
    }
}
