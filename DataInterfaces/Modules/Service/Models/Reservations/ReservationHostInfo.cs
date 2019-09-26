using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Reservation host info.
    /// </summary>
    [DataContract()]
    [ProtoContract()]
    public class ReservationHostInfo
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets host id.
        /// </summary>
        [Required()]
        [ProtoMember(1)]
        [DataMember()]
        public int HostId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets prefered user id.
        /// </summary>
        [ProtoMember(2)]
        [DataMember(EmitDefaultValue = false)]
        public int? PreferedUserId
        {
            get; set;
        }

        #endregion
    }
}
