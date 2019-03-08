using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerService
{
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class ClientOrderingData
    {
        #region PROPERTIES

        [ProtoMember(1)]
        public IEnumerable<UserProductGroupDTO> ProductGroups { get; set; }

        [ProtoMember(2)]
        public IEnumerable<UserProductDTO> Products { get; set; }

        [ProtoMember(3)]
        public IEnumerable<UserPaymentMethodDTO> PaymentMethods
        {
            get;set;
        }

        #endregion
    }
}
