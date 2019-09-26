using System;
using System.Runtime.Serialization;

namespace ServerService
{
    #region ORDEREVENTARGSBASE
    [Serializable()]
    [DataContract()]
    public abstract class OrderEventArgsBase : UserIdEventArgsBase
    {
        #region CONSTRUCTOR
        public OrderEventArgsBase(int userId, int orderId) : base(userId)
        {
            OrderId = orderId;
        }
        #endregion

        #region PROPERTIES

        [DataMember()]
        public int OrderId
        {
            get; protected set;
        }

        #endregion
    }
    #endregion
}
