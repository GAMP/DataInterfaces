using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Reservation host parameter.
    /// </summary>
    [DataContract()]
    public class ReservationHostParameter
    {
        #region PROPERTIES

        /// <summary>
        /// Host id.
        /// </summary>
        [Required()]
        [DataMember()]
        public int HostId
        {
            get; set;
        }

        /// <summary>
        /// Prefered user id.
        /// </summary>
        [DataMember()]
        public int? PreferedUserId
        {
            get; set;
        } 

        #endregion
    }
}
