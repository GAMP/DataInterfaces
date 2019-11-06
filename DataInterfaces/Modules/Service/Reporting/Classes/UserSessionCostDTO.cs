using System;
using System.Runtime.Serialization;

namespace ServerService.Reporting
{
    /// <summary>
    /// User Session Cost.
    /// </summary>
    [Serializable]
    [DataContract]
    public class UserSessionCostDTO : UserSessionDTO
    {
        /// <summary>
        /// Packet minutes.
        /// </summary>
        [DataMember]
        public decimal Quantity { get; set; }

        /// <summary>
        /// Packet cost.
        /// </summary>
        [DataMember]
        public decimal Value { get; set; }

    }
}
