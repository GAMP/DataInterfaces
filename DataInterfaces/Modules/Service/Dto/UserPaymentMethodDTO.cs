using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class UserPaymentMethodDTO
    {
        #region PROPERTIES

        [ProtoMember(1)]
        public int PaymentMethodId
        {
            get; set;
        }

        [ProtoMember(2)]
        public string Name
        {
            get; set;
        }

        [ProtoMember(3)]
        public string Description
        {
            get; set;
        }

        [ProtoMember(4)]
        public int DisplayOrder
        {
            get;set;
        }

        #endregion
    }
}
