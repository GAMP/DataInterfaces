using ProtoBuf;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// Reservation user info.
    /// </summary>
    [DataContract()]
    [ProtoContract()]
    public class ReservationUserInfo
    {
        #region PROPERTIES

        /// <summary>
        /// Gets or sets user id.
        /// </summary>
        [ProtoMember(1)]
        [DataMember()]
        public int UserId
        {
            get; set;
        }

        #endregion
    }
}
