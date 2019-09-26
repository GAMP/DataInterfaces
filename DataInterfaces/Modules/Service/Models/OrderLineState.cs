using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class OrderLineState
    {
        #region PROPERTIES

        [ProtoMember(1)]
        public int OrderLineId
        {
            get; set;
        }       

        [ProtoMember(2)]
        public bool IsDelivered
        {
            get; set;
        }

        [ProtoMember(3)]
        public decimal DeliveredQuantity
        {
            get; set;
        }

        [ProtoMember(4)]
        public DateTime? DeliverTime
        {
            get; set;
        } 

        #endregion
    }
}
