using ProtoBuf;
using System;
using System.Runtime.Serialization;

namespace ServerService
{
    /// <summary>
    /// License key reservation info class.
    /// </summary>
    [Serializable()]
    [DataContract()]
    [ProtoContract()]
    public class LicenseKeyReservationInfo
    {
        #region PROPERTIES

        /// <summary>
        /// Application name.
        /// </summary>
        [DataMember(Order = 1)]
        [ProtoMember(1)]
        public string Application
        {
            get; set;
        }

        /// <summary>
        /// Executable name.
        /// </summary>
        [DataMember(Order = 2)]
        [ProtoMember(2)]
        public string Executable
        {
            get; set;
        }

        /// <summary>
        /// License key id.
        /// </summary>
        [DataMember(Order = 6)]
        [ProtoMember(3)]
        public int LicenseKeyId
        {
            get; set;
        }

        /// <summary>
        /// License key value.
        /// </summary>
        [DataMember(Order = 5)]
        [ProtoMember(4)]
        public string LicenseKey
        {
            get; set;
        }

        /// <summary>
        /// Host id.
        /// </summary>
        [DataMember(Order = 8)]
        [ProtoMember(5)]
        public int HostId
        {
            get; set;
        }

        /// <summary>
        /// Host name.
        /// </summary>
        [DataMember(Order = 4)]
        [ProtoMember(6)]
        public string Hostname
        {
            get; set;
        }

        /// <summary>
        /// User id.
        /// </summary>
        [DataMember(Order = 7)]
        [ProtoMember(7)]
        public int? UserId
        {
            get; set;
        }

        /// <summary>
        /// User name.
        /// </summary>
        [DataMember(Order = 3)]
        [ProtoMember(8)]
        public string Username
        {
            get; set;
        }

        /// <summary>
        /// Reservation id.
        /// </summary>
        [DataMember(Order = 9)]
        [ProtoMember(9)]
        public int ReservationId
        {
            get; set;
        }

        #endregion
    }
}
