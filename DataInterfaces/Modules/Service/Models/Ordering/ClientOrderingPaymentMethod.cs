using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Client ordering payment method model.
    /// </summary>
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class ClientOrderingPaymentMethod
    {
        #region PROPERTIES

        /// <summary>
        /// Payment method id.
        /// </summary>
        [ProtoMember(1)]
        public int PaymentMethodId
        {
            get; set;
        }

        /// <summary>
        /// Payment method name.
        /// </summary>
        [ProtoMember(2)]
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// Payment method description.
        /// </summary>
        [ProtoMember(3)]
        public string Description
        {
            get; set;
        }

        /// <summary>
        /// Payment method display order.
        /// </summary>
        [ProtoMember(4)]
        public int DisplayOrder
        {
            get;set;
        }

        #endregion
    }
}
