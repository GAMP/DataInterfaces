using ProtoBuf;
using SharedLib;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    [DataContract()]
    [Serializable()]
    [ProtoContract()]
    public class ProductOrderResult
    {
        #region CONSTRUCTOR

        public ProductOrderResult()
        { }

        public ProductOrderResult(OrderResult result)
        {
            Result = result;
        }

        public ProductOrderResult(OrderFailReason failReason)
        {
            FailReason = failReason;
            Result = OrderResult.Failed;
        }

        #endregion

        #region PROPERTIES

        [DataMember()]
        [ProtoMember(1)]
        public OrderResult Result
        {
            get; set;
        }

        [DataMember()]
        [ProtoMember(2)]
        public OrderFailReason FailReason
        {
            get; set;
        }

        [DataMember()]
        [ProtoMember(3)]
        public string PaymentURL
        {
            get; set;
        }

        #endregion
    }
}
