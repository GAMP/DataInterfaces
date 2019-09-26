using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Reservation update parameters.
    /// </summary>
    [DataContract()]
    [ProtoContract()]
    public class ReservationUpdateParameters : ReservationAddParameters
    {
        #region PROPERTIES
        /// <summary>
        /// Reservation id.
        /// </summary>
        [Required()]
        [ProtoMember(1)]
        [DataMember()]
        public int Id
        {
            get; set;
        }
        #endregion
    }
}
