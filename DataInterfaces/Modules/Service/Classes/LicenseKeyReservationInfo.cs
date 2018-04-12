using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
        /// Gets or sets application name.
        /// </summary>
        [DataMember(Order = 1)]
        [ProtoMember(1)]
        public string Application
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets executable name.
        /// </summary>
        [DataMember(Order = 2)]
        [ProtoMember(2)]
        public string Executable
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets license key id.
        /// </summary>
        [DataMember(Order = 6)]
        [ProtoMember(3)]
        public int LicenseKeyId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets license key.
        /// </summary>
        [DataMember(Order = 5)]
        [ProtoMember(4)]
        public string LicenseKey
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets host id.
        /// </summary>
        [DataMember(Order = 8)]
        [ProtoMember(5)]
        public int HostId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets host name.
        /// </summary>
        [DataMember(Order = 4)]
        [ProtoMember(6)]
        public string Hostname
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets user id.
        /// </summary>
        [DataMember(Order = 7)]
        [ProtoMember(7)]
        public int? UserId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets user name.
        /// </summary>
        [DataMember(Order = 3)]
        [ProtoMember(8)]
        public string Username
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets reservation id.
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
