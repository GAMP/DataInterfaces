using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ServerService.Web.Api.Controllers.Models
{
    /// <summary>
    /// Reservation user parameter.
    /// </summary>
    [DataContract()]
    public class ReservationUserParameter
    {
        #region PROPERTIES
        /// <summary>
        /// User id.
        /// </summary>
        [Required()]
        [DataMember()]
        public int UserId
        {
            get; set;
        } 
        #endregion
    }
}
