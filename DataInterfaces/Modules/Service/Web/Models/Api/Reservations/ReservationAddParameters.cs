using ProtoBuf;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Reservation add parameters.
    /// </summary>
    [DataContract()]
    [ProtoContract()]
    public class ReservationAddParameters
    {
        #region PROPERTIES

        /// <summary>
        /// Reserving user id.
        /// </summary>
        [DataMember()]
        [ProtoMember(1)]
        public int? UserId
        {
            get; set;
        }

        /// <summary>
        /// Reservation note.
        /// </summary>
        [DataMember()]
        [ProtoMember(2)]
        public string Note
        {
            get; set;
        }

        /// <summary>
        /// Contact phone.
        /// </summary>
        [DataMember()]
        [MaxLength(20)]
        [ProtoMember(3)]
        public string ContactPhone
        {
            get; set;
        }

        /// <summary>
        /// Contact email.
        /// </summary>
        [DataMember()]
        [MaxLength(254)]
        [ProtoMember(4)]
        public string ContactEmail
        {
            get; set;
        }

        /// <summary>
        /// Reservation date.
        /// </summary>
        [DataMember()]
        [ProtoMember(5)]
        public DateTime Date
        {
            get; set;
        }

        /// <summary>
        /// Reservation duration.
        /// </summary>
        [DataMember()]
        [ProtoMember(6)]
        [Range(1, int.MaxValue)]
        public int Duration
        {
            get; set;
        }

        /// <summary>
        /// Reservation users.
        /// </summary>
        [DataMember()]
        [ProtoMember(500)]
        public ReservationUserParameter[] Users { get; set; }

        /// <summary>
        /// Reservation hosts.
        /// </summary>
        [DataMember()]
        [ProtoMember(501)]
        [Required,MinLength(1)]
        public ReservationHostParameter[] Hosts { get; set; }

        #endregion
    }
}
